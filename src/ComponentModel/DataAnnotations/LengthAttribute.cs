﻿using System.ComponentModel.DataAnnotations;

namespace MetaFrm.Razor.Essentials.ComponentModel.DataAnnotations
{
    /// <summary>
    ///     Specifies the minimum and maximum length of collection/string data allowed in a property.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class LengthAttribute : System.ComponentModel.DataAnnotations.LengthAttribute, ICore
    {
        /// <summary>
        /// LengthAttribute
        /// </summary>
        /// <param name="minimumLength"></param>
        /// <param name="maximumLength"></param>
        //[RequiresUnreferencedCode(CountPropertyHelper.RequiresUnreferencedCodeMessage)]
        public LengthAttribute(int minimumLength, int maximumLength) : base(minimumLength, maximumLength)
        {
            this.ErrorMessage = "{0} 필드는 유효한 이메일 주소가 아닙니다.";
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