using Microsoft.AspNetCore.Components;

namespace MetaFrm.Razor.Essentials
{
    /// <summary>
    /// CardControl
    /// </summary>
    public partial class CardControl<TItem> : ICore
    {
        private static bool IsLoadAttribute = false;
        private static string? CssClassStatic;
        private static string? CssClassCardNewBorderStatic;
        private static string? CssClassHeaderStatic;
        private static string? CssClassBodyStatic;
        private static string? CssClassTitleStatic;
        private static string? CssClassSubTitleStatic;
        private static string? CssClassTextStatic;
        private static string? CssClassFooterStatic;
        private static string? CssClassWindowButtonStyleStatic;

        string? _CssClass = null;
        string? _CssClassCardNewBorder = null;
        string? _CssClassHeader = null;
        string? _CssClassBody = null;
        string? _CssClassTitle = null;
        string? _CssClassSubTitle = null;
        string? _CssClassText = null;
        string? _CssClassFooter = null;
        string? _CssClassWindowButtonStyle = null;

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
        /// CssClassCardNewBorder
        /// </summary>
        [Parameter]
        public string? CssClassCardNewBorder { get { return this._CssClassCardNewBorder ?? CssClassCardNewBorderStatic; } set { this._CssClassCardNewBorder = value; } }

        /// <summary>
        /// HeaderVisible
        /// </summary>
        [Parameter]
        public bool HeaderVisible { get; set; } = true;

        /// <summary>
        /// CssClassHeader
        /// </summary>
        [Parameter]
        public string? CssClassHeader { get { return this._CssClassHeader ?? CssClassHeaderStatic; } set { this._CssClassHeader = value; } }

        /// <summary>
        /// HeaderText
        /// </summary>
        [Parameter]
        public string HeaderText { get; set; } = string.Empty;

        /// <summary>
        /// CssClassBody
        /// </summary>
        [Parameter]
        public string? CssClassBody { get { return this._CssClassBody ?? CssClassBodyStatic; } set { this._CssClassBody = value; } }

        /// <summary>
        /// CssClassTitle
        /// </summary>
        [Parameter]
        public string? CssClassTitle { get { return this._CssClassTitle ?? CssClassTitleStatic; } set { this._CssClassTitle = value; } }

        /// <summary>
        /// TitleText
        /// </summary>
        [Parameter]
        public string TitleText { get; set; } = string.Empty;

        /// <summary>
        /// CssClassSubTitle
        /// </summary>
        [Parameter]
        public string? CssClassSubTitle { get { return this._CssClassSubTitle ?? CssClassSubTitleStatic; } set { this._CssClassSubTitle = value; } }

        /// <summary>
        /// SubTitleText
        /// </summary>
        [Parameter]
        public string SubTitleText { get; set; } = string.Empty;


        /// <summary>
        /// CssClassText
        /// </summary>
        [Parameter]
        public string? CssClassText { get { return this._CssClassText ?? CssClassTextStatic; } set { this._CssClassText = value; } }
        /// <summary>
        /// Text
        /// </summary>
        [Parameter]
        public RenderFragment? Text { get; set; }

        /// <summary>
        /// CssClassFooter
        /// </summary>
        [Parameter]
        public string? CssClassFooter { get { return this._CssClassFooter ?? CssClassFooterStatic; } set { this._CssClassFooter = value; } }
        /// <summary>
        /// FooterText
        /// </summary>
        [Parameter]
        public RenderFragment? Footer { get; set; }


        /// <summary>
        /// CssClassWindowButtonStyle
        /// ex) primary, secondary, success, danger, warning, info, light, dark, link
        /// </summary>
        [Parameter]
        public string? CssClassWindowButtonStyle { get { return this._CssClassWindowButtonStyle ?? CssClassWindowButtonStyleStatic; } set { this._CssClassWindowButtonStyle = value; } }

        /// <summary>
        /// Minimize
        /// </summary>
        [Parameter]
        public EventCallback Minimize { get; set; }
        /// <summary>
        /// Maximize
        /// </summary>
        [Parameter]
        public EventCallback Maximize { get; set; }
        /// <summary>
        /// Close
        /// </summary>
        [Parameter]
        public EventCallback Close { get; set; }

        /// <summary>
        /// GroupWindowStatus
        /// </summary>
        [Parameter]
        public CardWindowStatus CardWindowStatus { get; set; } = CardWindowStatus.Maximize;
        #endregion


        #region Init
        /// <summary>
        /// CardControl
        /// </summary>
        public CardControl()
        {
            if (!IsLoadAttribute)
            {
                CssClassStatic = this.GetAttribute<TItem>(nameof(this.CssClass));
                CssClassCardNewBorderStatic = this.GetAttribute<TItem>(nameof(this.CssClassCardNewBorder));
                CssClassHeaderStatic = this.GetAttribute<TItem>(nameof(this.CssClassHeader));
                CssClassBodyStatic = this.GetAttribute<TItem>(nameof(this.CssClassBody));
                CssClassTitleStatic = this.GetAttribute<TItem>(nameof(this.CssClassTitle));
                CssClassSubTitleStatic = this.GetAttribute<TItem>(nameof(this.CssClassSubTitle));
                CssClassTextStatic = this.GetAttribute<TItem>(nameof(this.CssClassText));
                CssClassFooterStatic = this.GetAttribute<TItem>(nameof(this.CssClassFooter));
                CssClassWindowButtonStyleStatic = this.GetAttribute<TItem>(nameof(this.CssClassWindowButtonStyle));

                IsLoadAttribute = true;
            }
        }
        #endregion


        #region event
        private void OnMinimize()
        {
            this.Minimize.InvokeAsync();
        }
        private void OnMaximize()
        {
            this.Maximize.InvokeAsync();
        }
        private void OnClose()
        {
            this.Close.InvokeAsync();
        }
        #endregion
    }
}