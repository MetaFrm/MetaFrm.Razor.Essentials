using MetaFrm.Localization;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace MetaFrm.Razor.Essentials
{
    /// <summary>
    /// FieldControl
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "BL0007:Component parameters should be auto properties", Justification = "<보류 중>")]
    public partial class FieldControl : ICore
    {
        private static bool IsLoadAttribute = false;
        private static string? CssClassStatic;
        private static string? CssClassAppendStatic;
        private static string? CssClassLabelStatic;
        private static string? CssClassControlStatic;
        private static string? CssClassControlIsNullStatic;

        string? _CssClass = null;
        string? _CssClassAppend = null;
        string? _CssClassLabel = null;
        string? _CssClassControl = null;
        string? _CssClassControlIsNull = null;

        #region property
        /// <summary>
        /// CssClass
        /// </summary>
        [Parameter]
        public string? CssClass { get { return this._CssClass ?? CssClassStatic; } set { this._CssClass = value; } }

        /// <summary>
        /// CssClassDiv
        /// </summary>
        [Parameter]
        public string? CssClassAppend { get { return this._CssClassAppend ?? CssClassAppendStatic; } set { this._CssClassAppend = value; } }

        /// <summary>
        /// CssClassLabel
        /// </summary>
        [Parameter]
        public string? CssClassLabel { get { return this._CssClassLabel ?? CssClassLabelStatic; } set { this._CssClassLabel = value; } }

        /// <summary>
        /// CssClassControl
        /// </summary>
        [Parameter]
        public string? CssClassControl { get { return this._CssClassControl ?? CssClassControlStatic; } set { this._CssClassControl = value; } }

        /// <summary>
        /// CssClassControlIsNull
        /// </summary>
        [Parameter]
        public string? CssClassControlIsNull { get { return this._CssClassControlIsNull ?? CssClassControlIsNullStatic; } set { this._CssClassControlIsNull = value; } }

        /// <summary>
        /// Label
        /// </summary>
        [Parameter]
        public string? Label { get; set; }

        /// <summary>
        /// Control
        /// </summary>
        [Parameter]
        public RenderFragment? Control { get; set; }
        /// <summary>
        /// Value
        /// </summary>
        [Parameter]
        public object? Value { get; set; }
        /// <summary>
        /// IsColon
        /// </summary>
        [Parameter]
        public bool IsColon { get; set; } = true;

        /// <summary>
        /// Localization
        /// </summary>
        [Inject]
        protected IStringLocalizer Localization { get; set; } = MetaFrm.Localization.DummyLocalizationManager.Instance;
        #endregion

        #region Init
        /// <summary>
        /// FieldControl
        /// </summary>
        public FieldControl()
        {
            if (!IsLoadAttribute)
            {
                CssClassStatic = this.GetAttribute(nameof(this.CssClass));
                CssClassAppendStatic = this.GetAttribute(nameof(this.CssClassAppend));
                CssClassLabelStatic = this.GetAttribute(nameof(this.CssClassLabel));
                CssClassControlStatic = this.GetAttribute(nameof(this.CssClassControl));
                CssClassControlIsNullStatic = this.GetAttribute(nameof(this.CssClassControlIsNull));

                IsLoadAttribute = true;
            }
        }
        #endregion
    }
}