using Microsoft.AspNetCore.Components;

namespace MetaFrm.Razor.Search
{
    /// <summary>
    /// SearchControl
    /// </summary>
    public partial class SearchControl : ICore
    {
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
    }
}