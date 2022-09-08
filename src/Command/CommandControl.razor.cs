using Microsoft.AspNetCore.Components;

namespace MetaFrm.Razor.Command
{
    /// <summary>
    /// CommandControl
    /// </summary>
    public partial class CommandControl<TItem> : ICore
    {
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
        /// Init
        /// </summary>
        [Parameter]
        public EventCallback Init { get; set; }

        /// <summary>
        /// New
        /// </summary>
        [Parameter]
        public EventCallback New { get; set; }

        /// <summary>
        /// Copy
        /// </summary>
        [Parameter]
        public EventCallback Copy { get; set; }

        /// <summary>
        /// Delete
        /// </summary>
        [Parameter]
        public EventCallback Delete { get; set; }

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
        /// CssClassDiv
        /// </summary>
        [Parameter]
        public string CssClassDiv { get; set; } = "row py-2 px-1";
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