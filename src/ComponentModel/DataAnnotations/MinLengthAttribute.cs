﻿using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;

namespace MetaFrm.Razor.Essentials.ComponentModel.DataAnnotations
{
    /// <summary>
    ///     Specifies the minimum length of collection/string data allowed in a property.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class MinLengthAttribute : System.ComponentModel.DataAnnotations.MinLengthAttribute, ICore
    {
        private IStringLocalizer? StringLocalizer = null;
        private readonly string errorMessageOrg = "{0} 필드는 최소 길이가 '{1}'인 문자열 또는 배열 유형이어야 합니다.";

        /// <summary>
        ///     Initializes a new instance of the <see cref="MinLengthAttribute" /> class.
        /// </summary>
        /// <param name="length">
        ///     The minimum allowable length of collection/string data.
        ///     Value must be greater than or equal to zero.
        /// </param>
        //[RequiresUnreferencedCode(CountPropertyHelper.RequiresUnreferencedCodeMessage)]
        public MinLengthAttribute(int length) : base(length)
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
            this.ErrorMessage = validationContext.Localization(this.errorMessageOrg, ref this.StringLocalizer);
            return base.IsValid(value, validationContext);
        }
    }
}