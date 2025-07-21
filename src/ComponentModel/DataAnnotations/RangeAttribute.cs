using System.ComponentModel.DataAnnotations;

namespace MetaFrm.Razor.Essentials.ComponentModel.DataAnnotations
{
    /// <summary>
    ///     Used for specifying a range constraint
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class RangeAttribute : System.ComponentModel.DataAnnotations.RangeAttribute, ICore
    {
        private readonly string errorMessageOrg = "{0} 필드는 {1}에서 {2} 사이여야 합니다.";

        /// <summary>
        ///     Constructor that takes integer minimum and maximum values
        /// </summary>
        /// <param name="minimum">The minimum value, inclusive</param>
        /// <param name="maximum">The maximum value, inclusive</param>
        public RangeAttribute(int minimum, int maximum) : base(minimum, maximum)
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