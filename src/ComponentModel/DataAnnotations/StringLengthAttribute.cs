﻿using System.ComponentModel.DataAnnotations;

namespace MetaFrm.Razor.Essentials.ComponentModel.DataAnnotations
{
    /// <summary>
    ///     Validation attribute to assert a string property, field or parameter does not exceed a maximum length
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
        AllowMultiple = false)]
    public class StringLengthAttribute : System.ComponentModel.DataAnnotations.StringLengthAttribute, ICore
    {
        /// <summary>
        ///     Constructor that accepts the maximum length of the string.
        /// </summary>
        /// <param name="maximumLength">The maximum length, inclusive.  It may not be negative.</param>
        public StringLengthAttribute(int maximumLength) : base(maximumLength)
        {
            this.ErrorMessage = "{0} 필드는 최대 길이가 {1}인 문자열이어야 합니다.";
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
            var stringLocalizer = Localization.LocalizationManager.Instance;

            if (stringLocalizer != null)
            {
                if (validationContext.DisplayName != null)
                    validationContext.DisplayName = stringLocalizer[validationContext.DisplayName];

                if (this.ErrorMessage != null)
                    this.ErrorMessage = stringLocalizer[this.ErrorMessage];
            }

            ValidationResult? validationResult = base.IsValid(value, validationContext);

            return validationResult;
        }
    }
}