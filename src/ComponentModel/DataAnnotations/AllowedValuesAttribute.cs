﻿using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;

namespace MetaFrm.Razor.Essentials.ComponentModel.DataAnnotations
{
    /// <summary>
    ///     Specifies a list of values that should be allowed in a property.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class AllowedValuesAttribute : System.ComponentModel.DataAnnotations.AllowedValuesAttribute, ICore
    {
        private IStringLocalizer? StringLocalizer = null;
        private readonly string errorMessageOrg = "{0} 필드가 지정된 값과 동일하지 않습니다.";

        /// <summary>
        ///     Initializes a new instance of the <see cref="AllowedValuesAttribute"/> class.
        /// </summary>
        /// <param name="values">
        ///     A list of values that the validated value should be equal to.
        /// </param>
        public AllowedValuesAttribute(params object?[] values) : base(values)
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
            this.ErrorMessage = validationContext.Localization(this.errorMessageOrg, ref this.StringLocalizer);
            return base.IsValid(value, validationContext);
        }
    }
}