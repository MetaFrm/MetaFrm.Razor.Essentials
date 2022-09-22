using Microsoft.AspNetCore.Components;

namespace MetaFrm.Razor.Essentials
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