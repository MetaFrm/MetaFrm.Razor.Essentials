using Microsoft.AspNetCore.Components;

namespace MetaFrm.Razor.Field
{
    /// <summary>
    /// FieldControl
    /// </summary>
    public partial class FieldControl : ICore
    {
        #region property
        /// <summary>
        /// Label
        /// </summary>
        [Parameter]
        public string? Label { get; set; }
        /// <summary>
        /// CssClassLabel
        /// </summary>
        [Parameter]
        public string CssClassLabel { get; set; } = "";

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
        /// CssClassLabel
        /// </summary>
        [Parameter]
        public string? CssClassControl { get; set; } = "";

        /// <summary>
        /// CssClassDiv
        /// </summary>
        [Parameter]
        public string CssClassDiv { get; set; } = "py-2";
        /// <summary>
        /// IsColon
        /// </summary>
        [Parameter]
        public bool IsColon { get; set; } = true;
        #endregion
    }
}