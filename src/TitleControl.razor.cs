using Microsoft.AspNetCore.Components;

namespace MetaFrm.Razor.Essentials
{
    /// <summary>
    /// TitleControl
    /// </summary>
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
    }
}