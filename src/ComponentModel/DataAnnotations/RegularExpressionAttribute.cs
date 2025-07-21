using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MetaFrm.Razor.Essentials.ComponentModel.DataAnnotations
{
    /// <summary>
    ///     Regular expression validation attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class RegularExpressionAttribute : System.ComponentModel.DataAnnotations.RegularExpressionAttribute, ICore
    {
        private readonly string errorMessageOrg = "{0} 필드는 정규식과 일치해야 합니다: '{1}'";

        /// <summary>
        ///     Constructor that accepts the regular expression pattern
        /// </summary>
        /// <param name="pattern">The regular expression to use.  It cannot be null.</param>
        public RegularExpressionAttribute([StringSyntax(StringSyntaxAttribute.Regex)] string pattern) : base(pattern)
        {
            this.ErrorMessage = this.errorMessageOrg;
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
            this.ErrorMessage = validationContext.Localization(this.errorMessageOrg);
            return base.IsValid(value, validationContext);
        }
    }
}