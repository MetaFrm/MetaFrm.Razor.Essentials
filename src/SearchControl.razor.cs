using Microsoft.AspNetCore.Components;

namespace MetaFrm.Razor.Essentials
{
    /// <summary>
    /// SearchControl
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "BL0007:Component parameters should be auto properties", Justification = "<보류 중>")]
    public partial class SearchControl : ICore
    {
        private static bool IsLoadAttribute = false;
        private static string? CssClassStatic;
        private static string? CssClassPrependStatic;
        private static string? CssClassPrependSpanStatic;
        private static string? CssClassPrependSpanIconStatic;
        private static string? CssClassAppendStatic;

        string? _CssClass = null;
        string? _CssClassPrepend = null;
        string? _CssClassPrependSpan = null;
        string? _CssClassPrependSpanIcon = null;
        string? _CssClassAppend = null;

        #region property
        /// <summary>
        /// CssClass
        /// </summary>
        [Parameter]
        public string? CssClass { get { return this._CssClass ?? CssClassStatic; } set { this._CssClass = value; } }
        /// <summary>
        /// CssClassPrepend
        /// </summary>
        [Parameter]
        public string? CssClassPrepend { get { return this._CssClassPrepend ?? CssClassPrependStatic; } set { this._CssClassPrepend = value; } }
        /// <summary>
        /// CssClassPrependSpan
        /// </summary>
        [Parameter]
        public string? CssClassPrependSpan { get { return this._CssClassPrependSpan ?? CssClassPrependSpanStatic; } set { this._CssClassPrependSpan = value; } }
        /// <summary>
        /// CssClassPrependSpanIcon
        /// </summary>
        [Parameter]
        public string? CssClassPrependSpanIcon { get { return this._CssClassPrependSpanIcon ?? CssClassPrependSpanIconStatic; } set { this._CssClassPrependSpanIcon = value; } }
        /// <summary>
        /// CssClassAppend
        /// </summary>
        [Parameter]
        public string? CssClassAppend { get { return this._CssClassAppend ?? CssClassAppendStatic; } set { this._CssClassAppend = value; } }

        /// <summary>
        /// InputControl
        /// </summary>
        [Parameter]
        public RenderFragment? InputControl { get; set; }

        /// <summary>
        /// ButtonControl
        /// </summary>
        [Parameter]
        public RenderFragment? ButtonControl { get; set; }
        #endregion


        #region Init
        /// <summary>
        /// SearchControl
        /// </summary>
        public SearchControl()
        {
            if (!IsLoadAttribute)
            {
                CssClassStatic = this.GetAttribute(nameof(this.CssClass));
                CssClassPrependStatic = this.GetAttribute(nameof(this.CssClassPrepend));
                CssClassPrependSpanStatic = this.GetAttribute(nameof(this.CssClassPrependSpan));
                CssClassPrependSpanIconStatic = this.GetAttribute(nameof(this.CssClassPrependSpanIcon));
                CssClassAppendStatic = this.GetAttribute(nameof(this.CssClassAppend));

                IsLoadAttribute = true;
            }
        }
        #endregion
    }
}