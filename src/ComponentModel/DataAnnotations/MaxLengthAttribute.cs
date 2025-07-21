using System.ComponentModel.DataAnnotations;

namespace MetaFrm.Razor.Essentials.ComponentModel.DataAnnotations
{
    /// <summary>
    ///     Specifies the maximum length of collection/string data allowed in a property.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class MaxLengthAttribute : System.ComponentModel.DataAnnotations.MaxLengthAttribute, ICore
    {
        private readonly string errorMessageOrg = "{0} 필드는 최대 길이가 '{1}'인 문자열 또는 배열 유형이어야 합니다.";

        /// <summary>
        ///     Initializes a new instance of the <see cref="MaxLengthAttribute" /> class.
        /// </summary>
        /// <param name="length">
        ///     The maximum allowable length of collection/string data.
        ///     Value must be greater than zero.
        /// </param>
        //[RequiresUnreferencedCode(CountPropertyHelper.RequiresUnreferencedCodeMessage)]
        public MaxLengthAttribute(int length) : base(length)
        {
            this.ErrorMessage = this.errorMessageOrg;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="MaxLengthAttribute" /> class.
        ///     The maximum allowable length supported by the database will be used.
        /// </summary>
        //[RequiresUnreferencedCode(CountPropertyHelper.RequiresUnreferencedCodeMessage)]
        public MaxLengthAttribute() : base() { }

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
            this.ErrorMessage = validationContext.Localization(this.errorMessageOrg);
            return base.IsValid(value, validationContext);
        }
    }
}