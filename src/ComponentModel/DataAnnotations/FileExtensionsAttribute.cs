using System.ComponentModel.DataAnnotations;

namespace MetaFrm.Razor.Essentials.ComponentModel.DataAnnotations
{
    /// <summary>
    /// FileExtensionsAttribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
        AllowMultiple = false)]
    public class FileExtensionsAttribute : DataTypeAttribute, ICore
    {
        private readonly string[] _extensions;

        /// <summary>
        /// FileExtensionsAttribute
        /// </summary>
        public FileExtensionsAttribute(string extensions) : base(DataType.Upload)
        {
            this._extensions = extensions.Split(',').Select(x => x.Trim().ToLowerInvariant()).ToArray();
            this.ErrorMessage = "{0} 필드는 다음 확장자가 있는 파일만 허용합니다: ";// + string.Join(", ", _extensions);
        }

        /// <summary>
        /// IsValid
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object? value)
        {
            if (value is string fileName)
            {
                var extension = Path.GetExtension(fileName).TrimStart('.').ToLowerInvariant();
                return this._extensions.Contains(extension);
            }

            return true;
        }

        /// <summary>
        ///     Protected virtual method to override and implement validation logic.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="validationContext">
        ///     A <see cref="ValidationContext" /> instance that provides
        ///     context about the validation operation, such as the object and member being validated.
        /// </param>
        /// <returns>
        ///     When validation is valid, <see cref="ValidationResult.Success" />.
        ///     <para>
        ///         When validation is invalid, an instance of <see cref="ValidationResult" />.
        ///     </para>
        /// </returns>
        /// <exception cref="InvalidOperationException"> is thrown if the current attribute is malformed.</exception>
        /// <exception cref="NotImplementedException">
        ///     is thrown when <see cref="IsValid(object, ValidationContext)" />
        ///     has not been implemented by a derived class.
        /// </exception>
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            Localization.LocalizationManager stringLocalizer = Localization.LocalizationManager.Instance;

            if (validationContext.DisplayName != null)
                validationContext.DisplayName = stringLocalizer[validationContext.DisplayName];

            if (this.ErrorMessage != null)
                this.ErrorMessage = stringLocalizer[this.ErrorMessage];

            ValidationResult? validationResult = base.IsValid(value, validationContext);

            return validationResult;
        }
    }
}