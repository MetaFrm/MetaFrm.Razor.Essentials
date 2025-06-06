﻿using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace MetaFrm.Razor.Essentials.ComponentModel.DataAnnotations
{
    /// <summary>
    /// UrlAttribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
        AllowMultiple = false)]
    public class UrlAttribute : DataTypeAttribute, ICore
    {
        /// <summary>
        /// UrlAttribute
        /// </summary>
        public UrlAttribute() : base(DataType.Url)
        {
            this.ErrorMessage = "{0} 필드는 올바른 URL이 아닙니다.";
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

            // URL pattern
            string pattern = @"^(http|https)://([\w-]+(\.[\w-]+)+)(/[\w- ./?%&=]*)?$";

            return Regex.IsMatch(valueAsString ?? "", pattern);
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