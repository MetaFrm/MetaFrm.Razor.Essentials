using Microsoft.AspNetCore.Components;

namespace MetaFrm.Razor.Essentials
{
    /// <summary>
    /// CardControl
    /// </summary>
    public partial class CardControl : ICore
    {
        #region property
        string _cssClass = string.Empty;
        /// <summary>
        /// CssClass
        /// </summary>
        [Parameter]
        public string CssClass { get { return $"{this.GetAttribute(nameof(this.CssClass))} {this._cssClass}" ; } set { this._cssClass = value; } } 

        /// <summary>
        /// HeaderVisible
        /// </summary>
        [Parameter]
        public bool HeaderVisible { get; set; } = true;

        string _cssClassHeader = string.Empty;
        /// <summary>
        /// CssClassHeader
        /// </summary>
        [Parameter]
        public string CssClassHeader { get { return $"{this.GetAttribute(nameof(this.CssClassHeader))} {this._cssClassHeader}"; } set { this._cssClassHeader = value; } }

        /// <summary>
        /// HeaderText
        /// </summary>
        [Parameter]
        public string HeaderText { get; set; } = string.Empty;

        string _cssClassBody = string.Empty;
        /// <summary>
        /// CssClassBody
        /// </summary>
        [Parameter]
        public string CssClassBody { get { return $"{this.GetAttribute(nameof(this.CssClassBody))} {this._cssClassBody}"; } set { this._cssClassBody = value; } }

        string _cssClassTitle = string.Empty;
        /// <summary>
        /// CssClassTitle
        /// </summary>
        [Parameter]
        public string CssClassTitle { get { return $"{this.GetAttribute(nameof(this.CssClassTitle))} {this._cssClassTitle}"; } set { this._cssClassTitle = value; } }

        /// <summary>
        /// TitleText
        /// </summary>
        [Parameter]
        public string TitleText { get; set; } = string.Empty;

        string _cssClassSubTitle = string.Empty;
        /// <summary>
        /// CssClassSubTitle
        /// </summary>
        [Parameter]
        public string CssClassSubTitle { get { return $"{this.GetAttribute(nameof(this.CssClassSubTitle))} {this._cssClassSubTitle}"; } set { this._cssClassSubTitle = value; } }

        /// <summary>
        /// SubTitleText
        /// </summary>
        [Parameter]
        public string SubTitleText { get; set; } = string.Empty;


        string _cssClassText = string.Empty;
        /// <summary>
        /// CssClassText
        /// </summary>
        [Parameter]
        public string CssClassText { get { return $"{this.GetAttribute(nameof(this.CssClassText))} {this._cssClassText}"; } set { this._cssClassText = value; } }
        /// <summary>
        /// Text
        /// </summary>
        [Parameter]
        public RenderFragment? Text { get; set; }

        string _cssClassFooter = string.Empty;
        /// <summary>
        /// CssClassFooter
        /// </summary>
        [Parameter]
        public string CssClassFooter { get { return $"{this.GetAttribute(nameof(this.CssClassFooter))} {this._cssClassFooter}"; } set { this._cssClassFooter = value; } }
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
        public string CssClassWindowButtonStyle { get; set; } = string.Empty;

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
            this.CssClassWindowButtonStyle = this.GetAttribute(nameof(this.CssClassWindowButtonStyle));
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