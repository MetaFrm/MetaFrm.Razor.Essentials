using System.ComponentModel.DataAnnotations;

namespace MetaFrm.Razor.Essentials.ComponentModel.DataAnnotations
{
    /// <summary>
    ///     Specifies that a data field value is a well-formed Base64 string.
    /// </summary>
    /// <remarks>
    ///     Recognition of valid Base64 is delegated to the <see cref="Convert"/> class,
    ///     using the <see cref="Convert.TryFromBase64String(string, Span{byte}, out int)"/> method.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class Base64StringAttribute : System.ComponentModel.DataAnnotations.Base64StringAttribute, ICore
    {
        private readonly string errorMessageOrg = "{0} 필드는 올바른 Base64 인코딩이 아닙니다.";

        /// <summary>
        ///     Initializes a new instance of the <see cref="Base64StringAttribute"/> class.
        /// </summary>
        public Base64StringAttribute() : base()
        {
            this.ErrorMessage = this.errorMessageOrg;
        }

        /// <summary>
        ///     Protected virtual method to override and implement validation logic.
        ///     <para>
        ///         Derived classes should override this method instead of <see cref="System.ComponentModel.DataAnnotations.AllowedValuesAttribute.IsValid(object)" />, which is deprecated.
        ///     </para>
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
            this.ErrorMessage = validationContext.Localization(this.errorMessageOrg);
            return base.IsValid(value, validationContext);
        }
    }
}