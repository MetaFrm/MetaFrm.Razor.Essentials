using Microsoft.AspNetCore.Components;

namespace MetaFrm.Razor.Title
{
    /// <summary>
    /// TitleControl
    /// </summary>
    public partial class TitleControl : ICore
    {
        #region property
        /// <summary>
        /// Title
        /// </summary>
        [Parameter]
        public string? Title { get; set; }
        #endregion
    }
}