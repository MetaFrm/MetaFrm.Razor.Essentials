﻿using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace MetaFrm.Razor.Essentials.ComponentModel.DataAnnotations
{
    /// <summary>
    /// CompareAttribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class CompareAttribute : System.ComponentModel.DataAnnotations.CompareAttribute, ICore
    {
        private readonly string errorMessageOrg = "'{0}'과 '{1}'이(가) 일치하지 않습니다.";
        private IStringLocalizer? StringLocalizer;

        /// <summary>
        /// CompareAttribute
        /// </summary>
        [RequiresUnreferencedCode("The property referenced by 'otherProperty' may be trimmed. Ensure it is preserved.")]
        public CompareAttribute(string otherProperty) : base(otherProperty)
        {
            this.ErrorMessage = this.errorMessageOrg;
        }

        /// <summary>
        /// FormatErrorMessage
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public override string FormatErrorMessage(string name) => string.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, StringLocalizer == null ? OtherPropertyDisplayName ?? OtherProperty : StringLocalizer[OtherPropertyDisplayName ?? OtherProperty]);

        /// <summary>
        /// IsValid
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2072:UnrecognizedReflectionPattern", Justification = "The ctor is marked with RequiresUnreferencedCode informing the caller to preserve the other property.")]
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            this.ErrorMessage = validationContext.Localization(this.errorMessageOrg, ref this.StringLocalizer);
            return base.IsValid(value, validationContext);
        }
    }
}