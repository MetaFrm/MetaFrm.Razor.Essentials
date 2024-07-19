﻿using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MetaFrm.Razor.Essentials.ComponentModel.DataAnnotations
{
    /// <summary>
    /// PhoneAttribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
        AllowMultiple = false)]
    public class PhoneAttribute : System.ComponentModel.DataAnnotations.DataTypeAttribute, ICore
    {
        /// <summary>
        /// PhoneAttribute
        /// </summary>
        public PhoneAttribute() : base(DataType.PhoneNumber)
        {
            this.ErrorMessage = "{0} 필드는 올바른 전화 번호가 아닙니다.";
        }

        /// <summary>
        /// IsValid
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object? value)
        {
            if (value == null)
            {
                return true;
            }

            string? valueAsString = value as string;

            // Phone number pattern
            string pattern = @"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$";

            return Regex.IsMatch(valueAsString ?? "", pattern);
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
            Microsoft.Extensions.Localization.IStringLocalizer? stringLocalizer = MetaFrm.Razor.Essentials.Localization.LocalizationManager.Instance;

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