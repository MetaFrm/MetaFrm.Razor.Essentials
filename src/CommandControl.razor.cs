using MetaFrm.Localization;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace MetaFrm.Razor.Essentials
{
    /// <summary>
    /// CommandControl
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "BL0007:Component parameters should be auto properties", Justification = "<보류 중>")]
    public partial class CommandControl<TItem> : ICore
    {
        private static bool IsLoadAttribute = false;
        private static string? CssClassStatic;
        private static string? CssClassSaveButtonStatic;
        private static string? CssClassSaveIconStatic;
        private static string? CssClassEditIconStatic;
        private static string? CssClassAddButtonStatic;
        private static string? CssClassAddIconStatic;
        private static string? CssClassRemoveButtonStatic;
        private static string? CssClassRemoveIconStatic;
        private static string? CssClassInitButtonStatic;
        private static string? CssClassInitIconStatic;
        private static string? CssClassNewButtonStatic;
        private static string? CssClassNewIconStatic;
        private static string? CssClassCopyButtonStatic;
        private static string? CssClassCopyIconStatic;
        private static string? CssClassDeleteButtonStatic;
        private static string? CssClassDeleteIconStatic;
        private static string? TextEditStatic;
        private static string? TextSaveStatic;
        private static string? TextAddStatic;
        private static string? TextRemoveStatic;
        private static string? TextInitStatic;
        private static string? TextNewStatic;
        private static string? TextCopyStatic;
        private static string? TextDeleteStatic;

        string? _CssClass = null;
        string? _CssClassSaveButton = null;
        string? _CssClassSaveIcon = null;
        string? _CssClassEditIcon = null;
        string? _CssClassAddButton = null;
        string? _CssClassAddIcon = null;
        string? _CssClassRemoveButton = null;
        string? _CssClassRemoveIcon = null;
        string? _CssClassInitButton = null;
        string? _CssClassInitIcon = null;
        string? _CssClassNewButton = null;
        string? _CssClassNewIcon = null;
        string? _CssClassCopyButton = null;
        string? _CssClassCopyIcon = null;
        string? _CssClassDeleteButton = null;
        string? _CssClassDeleteIcon = null;
        string? _TextEdit = null;
        string? _TextSave = null;
        string? _TextAdd = null;
        string? _TextRemove = null;
        string? _TextInit = null;
        string? _TextNew = null;
        string? _TextCopy = null;
        string? _TextDelete = null;


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
        /// CssClassDiv
        /// </summary>
        [Parameter]
        public string? CssClass { get { return this._CssClass ?? CssClassStatic; } set { this._CssClass = value; } }

        /// <summary>
        /// Save
        /// </summary>
        [Parameter]
        public EventCallback Save { get; set; }
        /// <summary>
        /// SaveIsSubmit
        /// </summary>
        [Parameter]
        public bool SaveIsSubmit { get; set; }
        /// <summary>
        /// CssClassSaveButton
        /// </summary>
        [Parameter]
        public string? CssClassSaveButton { get { return this._CssClassSaveButton ?? CssClassSaveButtonStatic; } set { this._CssClassSaveButton = value; } }
        /// <summary>
        /// CssClassSaveIcon
        /// </summary>
        [Parameter]
        public string? CssClassSaveIcon { get { return this._CssClassSaveIcon ?? CssClassSaveIconStatic; } set { this._CssClassSaveIcon = value; } }
        /// <summary>
        /// CssClassEditIcon
        /// </summary>
        [Parameter]
        public string? CssClassEditIcon { get { return this._CssClassEditIcon ?? CssClassEditIconStatic; } set { this._CssClassEditIcon = value; } }

        /// <summary>
        /// Add
        /// </summary>
        [Parameter]
        public EventCallback Add { get; set; }
        /// <summary>
        /// AddIsSubmit
        /// </summary>
        [Parameter]
        public bool AddIsSubmit { get; set; }
        /// <summary>
        /// CssClassAddButton
        /// </summary>
        [Parameter]
        public string? CssClassAddButton { get { return this._CssClassAddButton ?? CssClassAddButtonStatic; } set { this._CssClassAddButton = value; } }
        /// <summary>
        /// CssClassAddIcon
        /// </summary>
        [Parameter]
        public string? CssClassAddIcon { get { return this._CssClassAddIcon ?? CssClassAddIconStatic; } set { this._CssClassAddIcon = value; } }

        /// <summary>
        /// Remove
        /// </summary>
        [Parameter]
        public EventCallback Remove { get; set; }
        /// <summary>
        /// RemoveIsSubmit
        /// </summary>
        [Parameter]
        public bool RemoveIsSubmit { get; set; }
        /// <summary>
        /// CssClassRemoveButton
        /// </summary>
        [Parameter]
        public string? CssClassRemoveButton { get { return this._CssClassRemoveButton ?? CssClassRemoveButtonStatic; } set { this._CssClassRemoveButton = value; } }
        /// <summary>
        /// CssClassRemoveIcon
        /// </summary>
        [Parameter]
        public string? CssClassRemoveIcon { get { return this._CssClassRemoveIcon ?? CssClassRemoveIconStatic; } set { this._CssClassRemoveIcon = value; } }

        /// <summary>
        /// Init
        /// </summary>
        [Parameter]
        public EventCallback Init { get; set; }
        /// <summary>
        /// CssClassInitButton
        /// </summary>
        [Parameter]
        public string? CssClassInitButton { get { return this._CssClassInitButton ?? CssClassInitButtonStatic; } set { this._CssClassInitButton = value; } }
        /// <summary>
        /// CssClassInitIcon
        /// </summary>
        [Parameter]
        public string? CssClassInitIcon { get { return this._CssClassInitIcon ?? CssClassInitIconStatic; } set { this._CssClassInitIcon = value; } }

        /// <summary>
        /// New
        /// </summary>
        [Parameter]
        public EventCallback New { get; set; }
        /// <summary>
        /// CssClassNewButton
        /// </summary>
        [Parameter]
        public string? CssClassNewButton { get { return this._CssClassNewButton ?? CssClassNewButtonStatic; } set { this._CssClassNewButton = value; } }
        /// <summary>
        /// CssClassNewIcon
        /// </summary>
        [Parameter]
        public string? CssClassNewIcon { get { return this._CssClassNewIcon ?? CssClassNewIconStatic; } set { this._CssClassNewIcon = value; } }

        /// <summary>
        /// Copy
        /// </summary>
        [Parameter]
        public EventCallback Copy { get; set; }
        /// <summary>
        /// CssClassCopyButton
        /// </summary>
        [Parameter]
        public string? CssClassCopyButton { get { return this._CssClassCopyButton ?? CssClassCopyButtonStatic; } set { this._CssClassCopyButton = value; } }
        /// <summary>
        /// CssClassCopyIcon
        /// </summary>
        [Parameter]
        public string? CssClassCopyIcon { get { return this._CssClassCopyIcon ?? CssClassCopyIconStatic; } set { this._CssClassCopyIcon = value; } }

        /// <summary>
        /// Delete
        /// </summary>
        [Parameter]
        public EventCallback Delete { get; set; }
        /// <summary>
        /// CssClassDeleteButton
        /// </summary>
        [Parameter]
        public string? CssClassDeleteButton { get { return this._CssClassDeleteButton ?? CssClassDeleteButtonStatic; } set { this._CssClassDeleteButton = value; } }
        /// <summary>
        /// CssClassDeleteIcon
        /// </summary>
        [Parameter]
        public string? CssClassDeleteIcon { get { return this._CssClassDeleteIcon ?? CssClassDeleteIconStatic; } set { this._CssClassDeleteIcon = value; } }


        /// <summary>
        /// TextEdit
        /// </summary>
        [Parameter]
        public string? TextEdit { get { return this._TextEdit ?? TextEditStatic; } set { this._TextEdit = value; } }
        /// <summary>
        /// TextSave
        /// </summary>
        [Parameter]
        public string? TextSave { get { return this._TextSave ?? TextSaveStatic; } set { this._TextSave = value; } }
        /// <summary>
        /// TextAdd
        /// </summary>
        [Parameter]
        public string? TextAdd { get { return this._TextAdd ?? TextAddStatic; } set { this._TextAdd = value; } }
        /// <summary>
        /// TextRemove
        /// </summary>
        [Parameter]
        public string? TextRemove { get { return this._TextRemove ?? TextRemoveStatic; } set { this._TextRemove = value; } }
        /// <summary>
        /// TextInit
        /// </summary>
        [Parameter]
        public string? TextInit { get { return this._TextInit ?? TextInitStatic; } set { this._TextInit = value; } }
        /// <summary>
        /// TextNew
        /// </summary>
        [Parameter]
        public string? TextNew { get { return this._TextNew ?? TextNewStatic; } set { this._TextNew = value; } }
        /// <summary>
        /// TextCopy
        /// </summary>
        [Parameter]
        public string? TextCopy { get { return this._TextCopy ?? TextCopyStatic; } set { this._TextCopy = value; } }
        /// <summary>
        /// TextDelete
        /// </summary>
        [Parameter]
        public string? TextDelete { get { return this._TextDelete ?? TextDeleteStatic; } set { this._TextDelete = value; } }

        private readonly DummyLocalizationManager dummyLocalizationManager = new();
        [Inject]
        internal IStringLocalizer? InjectedLocalization { get; set; }

        /// <summary>
        /// Localization
        /// </summary>
        protected IStringLocalizer Localization
        {
            get
            {
                if (this.InjectedLocalization == null)
                {
                    return this.dummyLocalizationManager;
                }

                return this.InjectedLocalization;
            }
        }
        #endregion


        #region Init
        /// <summary>
        /// CommandControl
        /// </summary>
        public CommandControl()
        {
            if (!IsLoadAttribute)
            {
                CssClassStatic = this.GetAttribute<TItem>(nameof(this.CssClass));
                CssClassSaveButtonStatic = this.GetAttribute<TItem>(nameof(this.CssClassSaveButton));
                CssClassSaveIconStatic = this.GetAttribute<TItem>(nameof(this.CssClassSaveIcon));
                CssClassEditIconStatic = this.GetAttribute<TItem>(nameof(this.CssClassEditIcon));
                CssClassAddButtonStatic = this.GetAttribute<TItem>(nameof(this.CssClassAddButton));
                CssClassAddIconStatic = this.GetAttribute<TItem>(nameof(this.CssClassAddIcon));
                CssClassRemoveButtonStatic = this.GetAttribute<TItem>(nameof(this.CssClassRemoveButton));
                CssClassRemoveIconStatic = this.GetAttribute<TItem>(nameof(this.CssClassRemoveIcon));
                CssClassInitButtonStatic = this.GetAttribute<TItem>(nameof(this.CssClassInitButton));
                CssClassInitIconStatic = this.GetAttribute<TItem>(nameof(this.CssClassInitIcon));
                CssClassNewButtonStatic = this.GetAttribute<TItem>(nameof(this.CssClassNewButton));
                CssClassNewIconStatic = this.GetAttribute<TItem>(nameof(this.CssClassNewIcon));
                CssClassCopyButtonStatic = this.GetAttribute<TItem>(nameof(this.CssClassCopyButton));
                CssClassCopyIconStatic = this.GetAttribute<TItem>(nameof(this.CssClassCopyIcon));
                CssClassDeleteButtonStatic = this.GetAttribute<TItem>(nameof(this.CssClassDeleteButton));
                CssClassDeleteIconStatic = this.GetAttribute<TItem>(nameof(this.CssClassDeleteIcon));

                TextEditStatic = this.GetAttribute<TItem>(nameof(this.TextEdit));
                TextSaveStatic = this.GetAttribute<TItem>(nameof(this.TextSave));
                TextAddStatic = this.GetAttribute<TItem>(nameof(this.TextAdd));
                TextRemoveStatic = this.GetAttribute<TItem>(nameof(this.TextRemove));
                TextInitStatic = this.GetAttribute<TItem>(nameof(this.TextInit));
                TextNewStatic = this.GetAttribute<TItem>(nameof(this.TextNew));
                TextCopyStatic = this.GetAttribute<TItem>(nameof(this.TextCopy));
                TextDeleteStatic = this.GetAttribute<TItem>(nameof(this.TextDelete));

                IsLoadAttribute = true;
            }
        }
        #endregion


        #region Action Method
        private void OnSave()
        {
            this.Save.InvokeAsync();
        }
        private void OnAdd()
        {
            this.Add.InvokeAsync();
        }
        private void OnRemove()
        {
            this.Remove.InvokeAsync();
        }
        private void OnInit()
        {
            this.Init.InvokeAsync();
        }
        private void OnNew()
        {
            this.New.InvokeAsync();
        }
        private void OnCopy()
        {
            this.Copy.InvokeAsync();
        }
        private void OnDelete()
        {
            this.Delete.InvokeAsync();
        }
        #endregion
    }
}