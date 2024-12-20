﻿using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MetaFrm.Razor.Essentials.ComponentModel.DataAnnotations
{
    /// <summary>
    /// CompareAttribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class CompareAttribute : System.ComponentModel.DataAnnotations.CompareAttribute, ICore
    {
        /// <summary>
        /// CompareAttribute
        /// </summary>
        [RequiresUnreferencedCode("The property referenced by 'otherProperty' may be trimmed. Ensure it is preserved.")]
        public CompareAttribute(string otherProperty) : base(otherProperty)
        {
            this.ErrorMessage = "'{0}'과 '{1}'이(가) 일치하지 않습니다.";
        }

        /// <summary>
        /// IsValid
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2072:UnrecognizedReflectionPattern",
            Justification = "The ctor is marked with RequiresUnreferencedCode informing the caller to preserve the other property.")]
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