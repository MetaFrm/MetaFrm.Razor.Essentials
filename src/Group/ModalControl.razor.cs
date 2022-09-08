using Microsoft.AspNetCore.Components;

namespace MetaFrm.Razor.Group
{
    /// <summary>
    /// ModalControl
    /// </summary>
    public partial class ModalControl<TItem> : ICore
    {
        #region property
        /// <summary>
        /// SelectItem
        /// </summary>
        [Parameter]
        public TItem? SelectItem { get; set; }

        /// <summary>
        /// SelectItemKeyProperty
        /// </summary>
        [Parameter]
        public string? SelectItemKeyProperty { get; set; }

        /// <summary>
        /// SelectItemHasKeyValue
        /// </summary>
        public bool? SelectItemHasKeyValue
        {
            get
            {
                if (this.SelectItem == null || this.SelectItemKeyProperty == null)
                    return null;

                return typeof(TItem).GetProperty(this.SelectItemKeyProperty)?.GetValue(this.SelectItem) != null;
            }
        }

        /// <summary>
        /// HeaderNewString
        /// </summary>
        [Parameter]
        public string HeaderNewString { get; set; } = "New";

        /// <summary>
        /// HeaderNewString
        /// </summary>
        [Parameter]
        public string HeaderEditString { get; set; } = "Edit";

        /// <summary>
        /// CssClassGroupBorder
        /// </summary>
        [Parameter]
        public string CssClassGroupBorder { get; set; } = "border-primary";

        /// <summary>
        /// Control
        /// </summary>
        [Parameter]
        public RenderFragment? Control { get; set; }

        /// <summary>
        /// InnerContainer
        /// </summary>
        [Parameter]
        public bool InnerContainer { get; set; }

        /// <summary>
        /// CssClassInnerContainer
        /// </summary>
        [Parameter]
        public string? CssClassInnerContainer { get; set; }
        #endregion
    }
}
