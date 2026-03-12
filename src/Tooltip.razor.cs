using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace MetaFrm.Razor.Essentials
{
    /// <summary>
    /// Tooltip
    /// </summary>
    public partial class Tooltip : ICore
    {
        private static bool IsLoadAttribute = false;

        private static string CssClassIconStatic = "bi bi-question-circle ms-1";

        string? _CssClassIcon;

        #region property
        /// <summary>
        /// CssClassIcon
        /// </summary>
        [Parameter]
        public string CssClassIcon { get { return this._CssClassIcon ?? CssClassIconStatic; } set { this._CssClassIcon = value; } }

        /// <summary>
        /// Text
        /// </summary>
        [Parameter]
        public RenderFragment? Text { get; set; }

        /// <summary>
        /// Localization
        /// </summary>
        [Inject]
        protected IStringLocalizer Localization { get; set; } = MetaFrm.Localization.DummyLocalizationManager.Instance;
        #endregion

        #region Init
        /// <summary>
        /// Tooltip
        /// </summary>
        public Tooltip()
        {
            if (!IsLoadAttribute)
            {
                CssClassIconStatic = this.GetAttribute(nameof(this.CssClassIcon));

                IsLoadAttribute = true;
            }
        }
        #endregion
    }
}