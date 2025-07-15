using MetaFrm.Localization;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace MetaFrm.Razor.Essentials
{
    /// <summary>
    /// ModalControl
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "BL0007:Component parameters should be auto properties", Justification = "<보류 중>")]
    public partial class ModalControl<TItem> : ICore
    {
        private static bool IsLoadAttribute = false;
        private static string? CssClassStatic;
        private static string? DataBsTargetStatic;
        private static string? CssClassDialogStatic;
        private static string? CssClassDialogContentStatic;
        private static string? CssClassDialogNewContentBorderStatic;
        private static string? CssClassHeaderStatic;
        private static string? CssClassHeaderTitleStatic;
        private static string? CssClassHeaderCloseButtonStatic;
        private static string? CssClassHeaderCloseButtonIconStatic;
        private static string? CssClassBodyStatic;
        private static string? CssClassInnerContainerStatic;

        string? _CssClass = null;
        string? _DataBsTarget = null;
        string? _CssClassDialog = null;
        string? _CssClassDialogContent = null;
        string? _CssClassDialogNewContentBorder = null;
        string? _CssClassHeader = null;
        string? _CssClassHeaderTitle = null;
        string? _CssClassHeaderCloseButton = null;
        string? _CssClassHeaderCloseButtonIcon = null;
        string? _CssClassBody = null;
        string? _CssClassInnerContainer = null;

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
        public bool SelectItemHasKeyValue
        {
            get
            {
                if (this.SelectItem == null || this.SelectItemKeyProperty == null)
                    return false;

                return typeof(TItem).GetProperty(this.SelectItemKeyProperty)?.GetValue(this.SelectItem) != null;
            }
        }


        /// <summary>
        /// CssClass
        /// </summary>
        [Parameter]
        public string? CssClass { get { return this._CssClass ?? CssClassStatic; } set { this._CssClass = value; } }

        /// <summary>
        /// DataBsTarget
        /// </summary>
        [Parameter]
        public string? DataBsTarget { get { Config.Client.SetAttribute("Modal.DataBsTarget", (this._DataBsTarget ?? DataBsTargetStatic) ?? ""); return this._DataBsTarget ?? DataBsTargetStatic; } set { this._DataBsTarget = value; } }

        /// <summary>
        /// CssClassDialog
        /// </summary>
        [Parameter]
        public string? CssClassDialog { get { return this._CssClassDialog ?? CssClassDialogStatic; } set { this._CssClassDialog = value; } }

        /// <summary>
        /// CssClassDialogContent
        /// </summary>
        [Parameter]
        public string? CssClassDialogContent { get { return this._CssClassDialogContent ?? CssClassDialogContentStatic; } set { this._CssClassDialogContent = value; } }

        /// <summary>
        /// CssClassDialogNewContentBorder
        /// </summary>
        [Parameter]
        public string? CssClassDialogNewContentBorder { get { return this._CssClassDialogNewContentBorder ?? CssClassDialogNewContentBorderStatic; } set { this._CssClassDialogNewContentBorder = value; } }

        /// <summary>
        /// CssClassHeader
        /// </summary>
        [Parameter]
        public string? CssClassHeader { get { return this._CssClassHeader ?? CssClassHeaderStatic; } set { this._CssClassHeader = value; } }

        /// <summary>
        /// CssClassHeaderTitle
        /// </summary>
        [Parameter]
        public string? CssClassHeaderTitle { get { return this._CssClassHeaderTitle ?? CssClassHeaderTitleStatic; } set { this._CssClassHeaderTitle = value; } }

        /// <summary>
        /// HeaderText
        /// </summary>
        [Parameter]
        public string HeaderText { get; set; } = string.Empty;

        /// <summary>
        /// CssClassHeaderCloseButton
        /// </summary>
        [Parameter]
        public string? CssClassHeaderCloseButton { get { return this._CssClassHeaderCloseButton ?? CssClassHeaderCloseButtonStatic; } set { this._CssClassHeaderCloseButton = value; } }

        /// <summary>
        /// CssClassHeaderCloseButtonIcon
        /// </summary>
        [Parameter]
        public string? CssClassHeaderCloseButtonIcon { get { return this._CssClassHeaderCloseButtonIcon ?? CssClassHeaderCloseButtonIconStatic; } set { this._CssClassHeaderCloseButtonIcon = value; } }

        /// <summary>
        /// CssClassBody
        /// </summary>
        [Parameter]
        public string? CssClassBody { get { return this._CssClassBody ?? CssClassBodyStatic; } set { this._CssClassBody = value; } }

        /// <summary>
        /// CssClassInnerContainer
        /// </summary>
        [Parameter]
        public string? CssClassInnerContainer { get { return this._CssClassInnerContainer ?? CssClassInnerContainerStatic; } set { this._CssClassInnerContainer = value; } }


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
        /// Localization
        /// </summary>
        [Inject]
        protected IStringLocalizer Localization { get; set; } = MetaFrm.Localization.DummyLocalizationManager.Instance;
        #endregion

        #region Init
        /// <summary>
        /// ModalControl
        /// </summary>
        public ModalControl()
        {
            if (!IsLoadAttribute)
            {
                CssClassStatic = this.GetAttribute<TItem>(nameof(this.CssClass));
                DataBsTargetStatic = this.GetAttribute<TItem>(nameof(this.DataBsTarget));
                CssClassDialogStatic = this.GetAttribute<TItem>(nameof(this.CssClassDialog));
                CssClassDialogContentStatic = this.GetAttribute<TItem>(nameof(this.CssClassDialogContent));
                CssClassDialogNewContentBorderStatic = this.GetAttribute<TItem>(nameof(this.CssClassDialogNewContentBorder));
                CssClassHeaderStatic = this.GetAttribute<TItem>(nameof(this.CssClassHeader));
                CssClassHeaderTitleStatic = this.GetAttribute<TItem>(nameof(this.CssClassHeaderTitle));
                CssClassHeaderCloseButtonStatic = this.GetAttribute<TItem>(nameof(this.CssClassHeaderCloseButton));
                CssClassHeaderCloseButtonIconStatic = this.GetAttribute<TItem>(nameof(this.CssClassHeaderCloseButtonIcon));
                CssClassBodyStatic = this.GetAttribute<TItem>(nameof(this.CssClassBody));
                CssClassInnerContainerStatic = this.GetAttribute<TItem>(nameof(this.CssClassInnerContainer));

                IsLoadAttribute = true;
            }
        }
        #endregion
    }
}