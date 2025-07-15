using MetaFrm.Localization;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;

namespace MetaFrm.Razor.Essentials
{
    /// <summary>
    /// TitleControl
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "BL0007:Component parameters should be auto properties", Justification = "<보류 중>")]
    public partial class TitleControl : ICore
    {
        private static bool IsLoadAttribute = false;
        private static string? CssClassStatic;

        string? _CssClass = null;

        #region property
        /// <summary>
        /// CssClass
        /// </summary>
        [Parameter]
        public string? CssClass { get { return this._CssClass ?? CssClassStatic; } set { this._CssClass = value; } }

        /// <summary>
        /// Title
        /// </summary>
        [Parameter]
        public string? Title { get; set; }

        /// <summary>
        /// Navigation
        /// </summary>
        [Inject]
        public IJSRuntime? JSRuntime { get; set; }

        /// <summary>
        /// Localization
        /// </summary>
        [Inject]
        protected IStringLocalizer Localization { get; set; } = MetaFrm.Localization.DummyLocalizationManager.Instance;
        #endregion

        #region Init
        /// <summary>
        /// TitleControl
        /// </summary>
        public TitleControl()
        {
            if (!IsLoadAttribute)
            {
                CssClassStatic = this.GetAttribute(nameof(this.CssClass));

                IsLoadAttribute = true;
            }
        }
        #endregion

        #region Event
        private async Task BackAsync()
        {
            if (this.JSRuntime != null)
                await this.JSRuntime.InvokeVoidAsync("history.back");
        }
        #endregion
    }
}