using MetaFrm.Reflection;
using Microsoft.AspNetCore.Components;

namespace MetaFrm.Razor.Essentials
{
    /// <summary>
    /// DataGridControl
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "BL0007:Component parameters should be auto properties", Justification = "<보류 중>")]
    public partial class DataGridControl<TItem> : ICore
    {
        private static bool IsLoadAttribute = false;
        private static int? PaddingTopStatic;
        private static int? HeaderHeightStatic;
        private static int? PagingSizeStatic;
        private static int? RowHeightStatic;
        private static string? CssClassTableStatic;
        private static string? DataBsToggleStatic;
        private static string? DataBsTargetStatic;

        int? _PaddingTop = null;
        int? _HeaderHeight = null;
        int? _PagingSize = null;
        int? _RowHeight = null;
        string? _CssClassTable = null;
        string? _DataBsToggle = null;
        string? _DataBsTarget = null;


        #region property
        /// <summary>
        /// DataItems
        /// </summary>
        [Parameter]
        public List<TItem>? DataItems { get; set; }

        ColumnDefinitions[]? _columns;
        /// <summary>
        /// Columns
        /// </summary>
        [Parameter]
        public ColumnDefinitions[]? Columns
        {
            get
            {
                return this._columns;
            }
            set
            {
                this._columns ??= value;
            }
        }


        /// <summary>
        /// PaddingTop
        /// </summary>
        [Parameter]
        public int? PaddingTop { get { return this._PaddingTop ?? PaddingTopStatic; } set { this._PaddingTop = value; } }

        /// <summary>
        /// HeaderHeight
        /// </summary>
        [Parameter]
        public int? HeaderHeight { get { return this._HeaderHeight ?? HeaderHeightStatic; } set { this._HeaderHeight = value; } }

        /// <summary>
        /// PagingSize
        /// </summary>
        [Parameter]
        public int? PagingSize { get { return this._PagingSize ?? PagingSizeStatic; } set { this._PagingSize = value; } }

        /// <summary>
        /// RowHeight
        /// </summary>
        [Parameter]
        public int? RowHeight { get { return this._RowHeight ?? RowHeightStatic; } set { this._RowHeight = value; } }

        /// <summary>
        /// TableClass
        /// </summary>
        [Parameter]
        public string? CssClassTable { get { return this._CssClassTable ?? CssClassTableStatic; } set { this._CssClassTable = value; } }

        /// <summary>
        /// SearchControlAlignment
        /// </summary>
        [Parameter]
        public SearchControlAlignment SearchControlAlignment { get; set; } = SearchControlAlignment.NotSet;

        /// <summary>
        /// Row Selected
        /// </summary>
        [Parameter]
        public EventCallback<TItem> RowSelected { get; set; }

        /// <summary>
        /// Row Add
        /// </summary>
        [Parameter]
        public EventCallback RowAdd { get; set; }

        /// <summary>
        /// Add Action
        /// </summary>
        [Parameter]
        public EventCallback<TItem> AddAction { get; set; }

        /// <summary>
        /// Row Modify
        /// </summary>
        [Parameter]
        public EventCallback<TItem> RowModify { get; set; }

        /// <summary>
        /// Row Delete
        /// </summary>
        [Parameter]
        public EventCallback<TItem> RowDelete { get; set; }


        /// <summary>
        /// PagingEnabled
        /// </summary>
        [Parameter]
        public bool PagingEnabled { get; set; }

        private int _currentPageNumber = 1;
        /// <summary>
        /// CurrentPageNumber
        /// </summary>
        public int CurrentPageNumber
        {
            get
            {
                return this._currentPageNumber;
            }
            set
            {
                if (value <= 0) value = 1;

                if (this._currentPageNumber != value)
                {
                    this._currentPageNumber = value;
                    this.GotoMovePage();
                }
                else
                    this._currentPageNumber = value;
            }
        }

        /// <summary>
        /// CustomerPager
        /// </summary>
        [Parameter]
        public RenderFragment? CustomerPager { get; set; }

        /// <summary>
        /// MovePage
        /// </summary>
        [Parameter]
        public EventCallback MovePage { get; set; }

        /// <summary>
        /// Pages
        /// </summary>
        [Parameter]
        public int[]? Pages { get; set; }

        private int MaxPageNumber => (this.DataItems == null || (this.PagingEnabled && this.DataItems.Count < this.PagingSize)) ? this.CurrentPageNumber : int.MaxValue;


        /// <summary>
        /// SearchInputControl
        /// </summary>
        [Parameter]
        public RenderFragment? SearchInputControl { get; set; }

        /// <summary>
        /// SearchButtonControl
        /// </summary>
        [Parameter]
        public RenderFragment? SearchButtonControl { get; set; }


        /// <summary>
        /// DataBsToggle
        /// </summary>
        [Parameter]
        public string? DataBsToggle { get { return this._DataBsToggle ?? DataBsToggleStatic; } set { this._DataBsToggle = value; } }

        /// <summary>
        /// DataBsTarget
        /// </summary>
        [Parameter]
        public string? DataBsTarget { get { return this._DataBsTarget ?? DataBsTargetStatic; } set { this._DataBsTarget = value; } }


        /// <summary>
        /// RowEditable
        /// </summary>
        [Parameter]
        public bool RowEditable { get; set; }

        /// <summary>
        /// RowEditableBoolColumn
        /// </summary>
        [Parameter]
        public string RowEditableStatusColumn { get; set; } = String.Empty;

        private string CssClassPrevDisabled => this.DataItems == null || this.CurrentPageNumber <= 1 ? "disabled" : "";

        private string CssClassNextDisabled => (this.DataItems == null || (this.PagingEnabled && this.DataItems.Count < this.PagingSize)) ? "disabled" : "";
        #endregion


        #region Sort Method
        /// <summary>
        /// SortInit
        /// </summary>
        /// <param name="columns"></param>
        /// <param name="dataField"></param>
        /// <param name="sortDirection"></param>
        public void SortInit(IList<ColumnDefinitions>? columns, string? dataField = null, SortDirection sortDirection = SortDirection.Normal)
        {
            if (columns != null)
                foreach (var col in columns)
                    if (col.SortDirection != SortDirection.NotSet)
                    {
                        if (dataField != null && dataField.Equals(col.DataField))
                            col.SortDirection = sortDirection;
                        else
                            col.SortDirection = SortDirection.Normal;
                    }
        }

        /// <summary>
        /// SortData
        /// </summary>
        /// <param name="sortByColumn"></param>
        public void SortData(ColumnDefinitions? sortByColumn = null)
        {
            bool initial = (sortByColumn == null);

            if (this.DataItems == null) return;
            if (this._columns == null) return;

            if (sortByColumn == null)
            {
                sortByColumn = this._columns.FirstOrDefault(x => x.SortDirection != SortDirection.NotSet && x.SortDirection != SortDirection.Normal);

                if (sortByColumn == null) return;
            }

            foreach (var column in this._columns)
            {
                if (column.DataField != sortByColumn.DataField && column.SortDirection != SortDirection.NotSet) column.SortDirection = SortDirection.Normal;
            }

            if (!initial)
                sortByColumn.SortDirection = sortByColumn.SortDirection switch
                {
                    SortDirection.NotSet => SortDirection.Ascending,
                    SortDirection.Ascending => SortDirection.Descending,
                    SortDirection.Descending => SortDirection.Ascending,
                    SortDirection.Normal => SortDirection.Ascending,
                    _ => SortDirection.Ascending,
                };

            if (typeof(TItem).GetProperty(sortByColumn.DataField) != null)
                if (sortByColumn.SortDirection == SortDirection.Ascending)
                {
                    switch (sortByColumn.DataType)
                    {
                        case Database.DbType.BigInt:
                            this.DataItems.Sort((x, y) => (Property.GetPropertyValue<Int64, TItem>(sortByColumn.DataField, x, Int64.MinValue)).CompareTo(Property.GetPropertyValue<Int64, TItem>(sortByColumn.DataField, y, Int64.MinValue)));
                            break;

                        case Database.DbType.Binary:
                            break;

                        case Database.DbType.Bit:
                            break;

                        case Database.DbType.Char:
                            this.DataItems.Sort((x, y) => (Property.GetPropertyValue<string, TItem>(sortByColumn.DataField, x, string.Empty)).CompareTo(Property.GetPropertyValue<string, TItem>(sortByColumn.DataField, y, string.Empty)));
                            break;

                        case Database.DbType.DateTime:
                            this.DataItems.Sort((x, y) => (Property.GetPropertyValue<DateTime, TItem>(sortByColumn.DataField, x, DateTime.MinValue)).CompareTo(Property.GetPropertyValue<DateTime, TItem>(sortByColumn.DataField, y, DateTime.MinValue)));
                            break;

                        case Database.DbType.Decimal:
                            this.DataItems.Sort((x, y) => (Property.GetPropertyValue<decimal, TItem>(sortByColumn.DataField, x, decimal.MinValue)).CompareTo(Property.GetPropertyValue<decimal, TItem>(sortByColumn.DataField, y, decimal.MinValue)));
                            break;

                        case Database.DbType.Float:
                            this.DataItems.Sort((x, y) => (Property.GetPropertyValue<float, TItem>(sortByColumn.DataField, x, float.MinValue)).CompareTo(Property.GetPropertyValue<float, TItem>(sortByColumn.DataField, y, float.MinValue)));
                            break;

                        case Database.DbType.Image:
                            break;

                        case Database.DbType.Int:
                            this.DataItems.Sort((x, y) => (Property.GetPropertyValue<int, TItem>(sortByColumn.DataField, x, int.MinValue)).CompareTo(Property.GetPropertyValue<int, TItem>(sortByColumn.DataField, y, int.MinValue)));
                            break;

                        case Database.DbType.Money:
                            this.DataItems.Sort((x, y) => (Property.GetPropertyValue<decimal, TItem>(sortByColumn.DataField, x, decimal.MinValue)).CompareTo(Property.GetPropertyValue<decimal, TItem>(sortByColumn.DataField, y, decimal.MinValue)));
                            break;

                        case Database.DbType.NChar:
                            this.DataItems.Sort((x, y) => (Property.GetPropertyValue<string, TItem>(sortByColumn.DataField, x, string.Empty)).CompareTo(Property.GetPropertyValue<string, TItem>(sortByColumn.DataField, y, string.Empty)));
                            break;

                        case Database.DbType.NText:
                            this.DataItems.Sort((x, y) => (Property.GetPropertyValue<string, TItem>(sortByColumn.DataField, x, string.Empty)).CompareTo(Property.GetPropertyValue<string, TItem>(sortByColumn.DataField, y, string.Empty)));
                            break;

                        case Database.DbType.NVarChar:
                            this.DataItems.Sort((x, y) => (Property.GetPropertyValue<string, TItem>(sortByColumn.DataField, x, string.Empty)).CompareTo(Property.GetPropertyValue<string, TItem>(sortByColumn.DataField, y, string.Empty)));
                            break;

                        case Database.DbType.Real:
                            this.DataItems.Sort((x, y) => (Property.GetPropertyValue<float, TItem>(sortByColumn.DataField, x, float.MinValue)).CompareTo(Property.GetPropertyValue<float, TItem>(sortByColumn.DataField, y, float.MinValue)));
                            break;

                        case Database.DbType.UniqueIdentifier:
                            break;

                        case Database.DbType.SmallDateTime:
                            this.DataItems.Sort((x, y) => (Property.GetPropertyValue<DateTime, TItem>(sortByColumn.DataField, x, DateTime.MinValue)).CompareTo(Property.GetPropertyValue<DateTime, TItem>(sortByColumn.DataField, y, DateTime.MinValue)));
                            break;

                        case Database.DbType.SmallInt:
                            this.DataItems.Sort((x, y) => (Property.GetPropertyValue<Int16, TItem>(sortByColumn.DataField, x, Int16.MinValue)).CompareTo(Property.GetPropertyValue<Int16, TItem>(sortByColumn.DataField, y, Int16.MinValue)));
                            break;

                        case Database.DbType.SmallMoney:
                            this.DataItems.Sort((x, y) => (Property.GetPropertyValue<decimal, TItem>(sortByColumn.DataField, x, decimal.MinValue)).CompareTo(Property.GetPropertyValue<decimal, TItem>(sortByColumn.DataField, y, decimal.MinValue)));
                            break;

                        case Database.DbType.Text:
                            this.DataItems.Sort((x, y) => (Property.GetPropertyValue<string, TItem>(sortByColumn.DataField, x, string.Empty)).CompareTo(Property.GetPropertyValue<string, TItem>(sortByColumn.DataField, y, string.Empty)));
                            break;

                        case Database.DbType.TinyInt:
                            this.DataItems.Sort((x, y) => (Property.GetPropertyValue<byte, TItem>(sortByColumn.DataField, x, byte.MinValue)).CompareTo(Property.GetPropertyValue<byte, TItem>(sortByColumn.DataField, y, byte.MinValue)));
                            break;

                        case Database.DbType.VarBinary:
                            break;

                        case Database.DbType.VarChar:
                            this.DataItems.Sort((x, y) => (Property.GetPropertyValue<string, TItem>(sortByColumn.DataField, x, string.Empty)).CompareTo(Property.GetPropertyValue<string, TItem>(sortByColumn.DataField, y, string.Empty)));
                            break;

                        case Database.DbType.Variant:
                            break;

                        case Database.DbType.Xml:
                            break;

                        case Database.DbType.Udt:
                            break;

                        case Database.DbType.Structured:
                            break;

                        case Database.DbType.Date:
                            this.DataItems.Sort((x, y) => (Property.GetPropertyValue<DateOnly, TItem>(sortByColumn.DataField, x, DateOnly.MinValue)).CompareTo(Property.GetPropertyValue<DateOnly, TItem>(sortByColumn.DataField, y, DateOnly.MinValue)));
                            break;

                        case Database.DbType.Time:
                            this.DataItems.Sort((x, y) => (Property.GetPropertyValue<TimeOnly, TItem>(sortByColumn.DataField, x, TimeOnly.MinValue)).CompareTo(Property.GetPropertyValue<TimeOnly, TItem>(sortByColumn.DataField, y, TimeOnly.MinValue)));
                            break;

                        case Database.DbType.DateTime2:
                            this.DataItems.Sort((x, y) => (Property.GetPropertyValue<DateTime, TItem>(sortByColumn.DataField, x, DateTime.MinValue)).CompareTo(Property.GetPropertyValue<DateTime, TItem>(sortByColumn.DataField, y, DateTime.MinValue)));
                            break;

                        case Database.DbType.DateTimeOffset:
                            this.DataItems.Sort((x, y) => (Property.GetPropertyValue<DateTimeOffset, TItem>(sortByColumn.DataField, x, DateTimeOffset.MinValue)).CompareTo(Property.GetPropertyValue<DateTimeOffset, TItem>(sortByColumn.DataField, y, DateTimeOffset.MinValue)));
                            break;
                        case Database.DbType.Timestamp:
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    switch (sortByColumn.DataType)
                    {
                        case Database.DbType.BigInt:
                            this.DataItems.Sort((y, x) => (Property.GetPropertyValue<Int64, TItem>(sortByColumn.DataField, x, Int64.MinValue)).CompareTo(Property.GetPropertyValue<Int64, TItem>(sortByColumn.DataField, y, Int64.MinValue)));
                            break;

                        case Database.DbType.Binary:
                            break;

                        case Database.DbType.Bit:
                            break;

                        case Database.DbType.Char:
                            this.DataItems.Sort((y, x) => (Property.GetPropertyValue<string, TItem>(sortByColumn.DataField, x, string.Empty)).CompareTo(Property.GetPropertyValue<string, TItem>(sortByColumn.DataField, y, string.Empty)));
                            break;

                        case Database.DbType.DateTime:
                            this.DataItems.Sort((y, x) => (Property.GetPropertyValue<DateTime, TItem>(sortByColumn.DataField, x, DateTime.MinValue)).CompareTo(Property.GetPropertyValue<DateTime, TItem>(sortByColumn.DataField, y, DateTime.MinValue)));
                            break;

                        case Database.DbType.Decimal:
                            this.DataItems.Sort((y, x) => (Property.GetPropertyValue<decimal, TItem>(sortByColumn.DataField, x, decimal.MinValue)).CompareTo(Property.GetPropertyValue<decimal, TItem>(sortByColumn.DataField, y, decimal.MinValue)));
                            break;

                        case Database.DbType.Float:
                            this.DataItems.Sort((y, x) => (Property.GetPropertyValue<float, TItem>(sortByColumn.DataField, x, float.MinValue)).CompareTo(Property.GetPropertyValue<float, TItem>(sortByColumn.DataField, y, float.MinValue)));
                            break;

                        case Database.DbType.Image:
                            break;

                        case Database.DbType.Int:
                            this.DataItems.Sort((y, x) => (Property.GetPropertyValue<int, TItem>(sortByColumn.DataField, x, int.MinValue)).CompareTo(Property.GetPropertyValue<int, TItem>(sortByColumn.DataField, y, int.MinValue)));
                            break;

                        case Database.DbType.Money:
                            this.DataItems.Sort((y, x) => (Property.GetPropertyValue<decimal, TItem>(sortByColumn.DataField, x, decimal.MinValue)).CompareTo(Property.GetPropertyValue<decimal, TItem>(sortByColumn.DataField, y, decimal.MinValue)));
                            break;

                        case Database.DbType.NChar:
                            this.DataItems.Sort((y, x) => (Property.GetPropertyValue<string, TItem>(sortByColumn.DataField, x, string.Empty)).CompareTo(Property.GetPropertyValue<string, TItem>(sortByColumn.DataField, y, string.Empty)));
                            break;

                        case Database.DbType.NText:
                            this.DataItems.Sort((y, x) => (Property.GetPropertyValue<string, TItem>(sortByColumn.DataField, x, string.Empty)).CompareTo(Property.GetPropertyValue<string, TItem>(sortByColumn.DataField, y, string.Empty)));
                            break;

                        case Database.DbType.NVarChar:
                            this.DataItems.Sort((y, x) => (Property.GetPropertyValue<string, TItem>(sortByColumn.DataField, x, string.Empty)).CompareTo(Property.GetPropertyValue<string, TItem>(sortByColumn.DataField, y, string.Empty)));
                            break;

                        case Database.DbType.Real:
                            this.DataItems.Sort((y, x) => (Property.GetPropertyValue<float, TItem>(sortByColumn.DataField, x, float.MinValue)).CompareTo(Property.GetPropertyValue<float, TItem>(sortByColumn.DataField, y, float.MinValue)));
                            break;

                        case Database.DbType.UniqueIdentifier:
                            break;

                        case Database.DbType.SmallDateTime:
                            this.DataItems.Sort((y, x) => (Property.GetPropertyValue<DateTime, TItem>(sortByColumn.DataField, x, DateTime.MinValue)).CompareTo(Property.GetPropertyValue<DateTime, TItem>(sortByColumn.DataField, y, DateTime.MinValue)));
                            break;

                        case Database.DbType.SmallInt:
                            this.DataItems.Sort((y, x) => (Property.GetPropertyValue<Int16, TItem>(sortByColumn.DataField, x, Int16.MinValue)).CompareTo(Property.GetPropertyValue<Int16, TItem>(sortByColumn.DataField, y, Int16.MinValue)));
                            break;

                        case Database.DbType.SmallMoney:
                            this.DataItems.Sort((y, x) => (Property.GetPropertyValue<decimal, TItem>(sortByColumn.DataField, x, decimal.MinValue)).CompareTo(Property.GetPropertyValue<decimal, TItem>(sortByColumn.DataField, y, decimal.MinValue)));
                            break;

                        case Database.DbType.Text:
                            this.DataItems.Sort((y, x) => (Property.GetPropertyValue<string, TItem>(sortByColumn.DataField, x, string.Empty)).CompareTo(Property.GetPropertyValue<string, TItem>(sortByColumn.DataField, y, string.Empty)));
                            break;

                        case Database.DbType.TinyInt:
                            this.DataItems.Sort((y, x) => (Property.GetPropertyValue<byte, TItem>(sortByColumn.DataField, x, byte.MinValue)).CompareTo(Property.GetPropertyValue<byte, TItem>(sortByColumn.DataField, y, byte.MinValue)));
                            break;

                        case Database.DbType.VarBinary:
                            break;

                        case Database.DbType.VarChar:
                            this.DataItems.Sort((y, x) => (Property.GetPropertyValue<string, TItem>(sortByColumn.DataField, x, string.Empty)).CompareTo(Property.GetPropertyValue<string, TItem>(sortByColumn.DataField, y, string.Empty)));
                            break;

                        case Database.DbType.Variant:
                            break;

                        case Database.DbType.Xml:
                            break;

                        case Database.DbType.Udt:
                            break;

                        case Database.DbType.Structured:
                            break;

                        case Database.DbType.Date:
                            this.DataItems.Sort((y, x) => (Property.GetPropertyValue<DateOnly, TItem>(sortByColumn.DataField, x, DateOnly.MinValue)).CompareTo(Property.GetPropertyValue<DateOnly, TItem>(sortByColumn.DataField, y, DateOnly.MinValue)));
                            break;

                        case Database.DbType.Time:
                            this.DataItems.Sort((y, x) => (Property.GetPropertyValue<TimeOnly, TItem>(sortByColumn.DataField, x, TimeOnly.MinValue)).CompareTo(Property.GetPropertyValue<TimeOnly, TItem>(sortByColumn.DataField, y, TimeOnly.MinValue)));
                            break;

                        case Database.DbType.DateTime2:
                            this.DataItems.Sort((y, x) => (Property.GetPropertyValue<DateTime, TItem>(sortByColumn.DataField, x, DateTime.MinValue)).CompareTo(Property.GetPropertyValue<DateTime, TItem>(sortByColumn.DataField, y, DateTime.MinValue)));
                            break;

                        case Database.DbType.DateTimeOffset:
                            this.DataItems.Sort((y, x) => (Property.GetPropertyValue<DateTimeOffset, TItem>(sortByColumn.DataField, x, DateTimeOffset.MinValue)).CompareTo(Property.GetPropertyValue<DateTimeOffset, TItem>(sortByColumn.DataField, y, DateTimeOffset.MinValue)));
                            break;
                        case Database.DbType.Timestamp:
                            break;
                        default:
                            break;
                    }
                }
        }
        #endregion


        #region Page Method
        private void GotoPrevPage()
        {
            if (this.CurrentPageNumber > 1)
            {
                this.CurrentPageNumber--;
                this.GotoMovePage();
            }
        }
        private void GotoNextPage()
        {
            if (this.CurrentPageNumber >= 1)
            {
                this.CurrentPageNumber++;
                this.GotoMovePage();
            }
        }
        private void GotoPage(int page)
        {
            if (page >= 1)
            {
                this.CurrentPageNumber = page;
                this.GotoMovePage();
            }
        }
        private void GotoMovePage()
        {
            this.MovePage.InvokeAsync();
        }
        #endregion


        #region Row Action Method
        private void OnRowSelected(TItem item)
        {
            this.RowSelected.InvokeAsync(item);
        }
        private void OnRowAdd()
        {
            this.RowAdd.InvokeAsync();
        }
        private void OnAddAction(TItem item)
        {
            this.AddAction.InvokeAsync(item);
        }
        private void OnRowDeleted(TItem item)
        {
            this.RowDelete.InvokeAsync(item);
        }
        private void OnRowModify(TItem item)
        {
            this.RowModify.InvokeAsync(item);
        }
        private void OnRowEditable(TItem item)
        {
            if (!string.IsNullOrEmpty(this.RowEditableStatusColumn))
            {
                this[new Indexer<bool> { DataField = this.RowEditableStatusColumn, Item = item }] = !this[new Indexer<bool> { DataField = this.RowEditableStatusColumn, Item = item }];

                bool? vs = this[new Indexer<bool> { DataField = this.RowEditableStatusColumn, Item = item }];

                if (vs != null && !(bool)vs)
                    this.RowModify.InvokeAsync(item);
            }
        }
        #endregion


        #region Init
        /// <summary>
        /// DataGridControl
        /// </summary>
        public DataGridControl()
        {
            if (!IsLoadAttribute)
            {
                PaddingTopStatic = this.GetAttributeInt<TItem>(nameof(this.PaddingTop));
                HeaderHeightStatic = this.GetAttributeInt<TItem>(nameof(this.HeaderHeight));
                PagingSizeStatic = this.GetAttributeInt<TItem>(nameof(this.PagingSize));
                RowHeightStatic = this.GetAttributeInt<TItem>(nameof(this.RowHeight));
                CssClassTableStatic = this.GetAttribute<TItem>(nameof(this.CssClassTable));
                DataBsToggleStatic = this.GetAttribute<TItem>(nameof(this.DataBsToggle));
                DataBsTargetStatic = this.GetAttribute<TItem>(nameof(this.DataBsTarget));

                IsLoadAttribute = true;
            }
        }
        #endregion


        #region ETC
        private static object? ValueFormating(ColumnDefinitions column, TItem item)
        {
            object? value = typeof(TItem).GetProperty(column.DataField)?.GetValue(item);

            if (!column.Format.IsNullOrEmpty())
            {
                return column.DataType switch
                {
                    Database.DbType.BigInt => value == null ? 0.ToString(column.Format) : ((Int64)value).ToString(column.Format),
                    Database.DbType.Binary => value,
                    Database.DbType.Bit => value == null ? null : ((bool)value).ToString(),
                    Database.DbType.Char => value == null ? null : ((string)value),
                    Database.DbType.DateTime => value == null ? null : ((DateTime)value).ToString(column.Format),
                    Database.DbType.Decimal => value == null ? 0M.ToString(column.Format) : ((decimal)value).ToString(column.Format),
                    Database.DbType.Float => value == null ? 0f.ToString(column.Format) : ((float)value).ToString(column.Format),
                    Database.DbType.Image => value,
                    Database.DbType.Int => value == null ? 0.ToString(column.Format) : ((int)value).ToString(column.Format),
                    Database.DbType.Money => value == null ? 0M.ToString(column.Format) : ((decimal)value).ToString(column.Format),
                    Database.DbType.NChar => value == null ? null : ((string)value),
                    Database.DbType.NText => value == null ? null : ((string)value),
                    Database.DbType.NVarChar => value == null ? null : ((string)value),
                    Database.DbType.Real => value == null ? 0f.ToString(column.Format) : ((float)value).ToString(column.Format),
                    Database.DbType.UniqueIdentifier => value == null ? null : ((Guid)value).ToString(column.Format),
                    Database.DbType.SmallDateTime => value == null ? null : ((DateTime)value).ToString(column.Format),
                    Database.DbType.SmallInt => value == null ? 0.ToString(column.Format) : ((Int16)value).ToString(column.Format),
                    Database.DbType.SmallMoney => value == null ? 0M.ToString(column.Format) : ((decimal)value).ToString(column.Format),
                    Database.DbType.Text => value == null ? null : ((string)value),
                    Database.DbType.TinyInt => value == null ? 0f.ToString(column.Format) : ((byte)value).ToString(column.Format),
                    Database.DbType.VarBinary => value,
                    Database.DbType.VarChar => value == null ? null : ((string)value),
                    Database.DbType.Variant => value,
                    Database.DbType.Xml => value,
                    Database.DbType.Udt => value,
                    Database.DbType.Structured => value,
                    Database.DbType.Date => value == null ? null : ((DateOnly)value).ToString(column.Format),
                    Database.DbType.Time => value == null ? null : ((TimeOnly)value).ToString(column.Format),
                    Database.DbType.DateTime2 => value == null ? null : ((DateTime)value).ToString(column.Format),
                    Database.DbType.DateTimeOffset => value == null ? null : ((DateTimeOffset)value).ToString(column.Format),
                    _ => value,
                };
            }
            else
                return value;
        }
        #endregion


        #region Indexer
        /// <summary>
        /// Indexer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class Indexer<T>
        {
            /// <summary>
            /// Item
            /// </summary>
            public TItem? Item { get; set; }
            /// <summary>
            /// DataField
            /// </summary>
            public string DataField { get; set; } = string.Empty;
        }
        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="indexer"></param>
        /// <returns></returns>
        public Int64? this[Indexer<Int64> indexer]
        {
            get => (Int64?)typeof(TItem).GetProperty(indexer.DataField)?.GetValue(indexer.Item);
            set => typeof(TItem).GetProperty(indexer.DataField)?.SetValue(indexer.Item, value);
        }
        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="indexer"></param>
        /// <returns></returns>
        public bool this[Indexer<bool> indexer]
        {
            get
            {
                bool? value = (bool?)typeof(TItem).GetProperty(indexer.DataField)?.GetValue(indexer.Item);

                if (value == null)
                    return false;
                else
                    return (bool)value;
            }
            set => typeof(TItem).GetProperty(indexer.DataField)?.SetValue(indexer.Item, value);
        }
        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="indexer"></param>
        /// <returns></returns>
        public string? this[Indexer<string> indexer]
        {
            get => (string?)typeof(TItem).GetProperty(indexer.DataField)?.GetValue(indexer.Item);
            set => typeof(TItem).GetProperty(indexer.DataField)?.SetValue(indexer.Item, value);
        }
        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="indexer"></param>
        /// <returns></returns>
        public DateTime? this[Indexer<DateTime> indexer]
        {
            get => (DateTime?)typeof(TItem).GetProperty(indexer.DataField)?.GetValue(indexer.Item);
            set => typeof(TItem).GetProperty(indexer.DataField)?.SetValue(indexer.Item, value);
        }
        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="indexer"></param>
        /// <returns></returns>
        public decimal? this[Indexer<decimal> indexer]
        {
            get => (decimal?)typeof(TItem).GetProperty(indexer.DataField)?.GetValue(indexer.Item);
            set => typeof(TItem).GetProperty(indexer.DataField)?.SetValue(indexer.Item, value);
        }
        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="indexer"></param>
        /// <returns></returns>
        public float? this[Indexer<float> indexer]
        {
            get => (float?)typeof(TItem).GetProperty(indexer.DataField)?.GetValue(indexer.Item);
            set => typeof(TItem).GetProperty(indexer.DataField)?.SetValue(indexer.Item, value);
        }
        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="indexer"></param>
        /// <returns></returns>
        public int? this[Indexer<int> indexer]
        {
            get => (int?)typeof(TItem).GetProperty(indexer.DataField)?.GetValue(indexer.Item);
            set => typeof(TItem).GetProperty(indexer.DataField)?.SetValue(indexer.Item, value);
        }
        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="indexer"></param>
        /// <returns></returns>
        public Guid? this[Indexer<Guid> indexer]
        {
            get => (Guid?)typeof(TItem).GetProperty(indexer.DataField)?.GetValue(indexer.Item);
            set => typeof(TItem).GetProperty(indexer.DataField)?.SetValue(indexer.Item, value);
        }
        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="indexer"></param>
        /// <returns></returns>
        public Int16? this[Indexer<Int16> indexer]
        {
            get => (Int16?)typeof(TItem).GetProperty(indexer.DataField)?.GetValue(indexer.Item);
            set => typeof(TItem).GetProperty(indexer.DataField)?.SetValue(indexer.Item, value);
        }
        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="indexer"></param>
        /// <returns></returns>
        public byte? this[Indexer<byte> indexer]
        {
            get => (byte?)typeof(TItem).GetProperty(indexer.DataField)?.GetValue(indexer.Item);
            set => typeof(TItem).GetProperty(indexer.DataField)?.SetValue(indexer.Item, value);
        }
        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="indexer"></param>
        /// <returns></returns>
        public DateOnly? this[Indexer<DateOnly> indexer]
        {
            get => (DateOnly?)typeof(TItem).GetProperty(indexer.DataField)?.GetValue(indexer.Item);
            set => typeof(TItem).GetProperty(indexer.DataField)?.SetValue(indexer.Item, value);
        }
        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="indexer"></param>
        /// <returns></returns>
        public TimeOnly? this[Indexer<TimeOnly> indexer]
        {
            get => (TimeOnly?)typeof(TItem).GetProperty(indexer.DataField)?.GetValue(indexer.Item);
            set => typeof(TItem).GetProperty(indexer.DataField)?.SetValue(indexer.Item, value);
        }
        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="indexer"></param>
        /// <returns></returns>
        public DateTimeOffset? this[Indexer<DateTimeOffset> indexer]
        {
            get => (DateTimeOffset?)typeof(TItem).GetProperty(indexer.DataField)?.GetValue(indexer.Item);
            set => typeof(TItem).GetProperty(indexer.DataField)?.SetValue(indexer.Item, value);
        }
        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="indexer"></param>
        /// <returns></returns>
        public object? this[Indexer<object> indexer]
        {
            get => typeof(TItem).GetProperty(indexer.DataField)?.GetValue(indexer.Item);
            set => typeof(TItem).GetProperty(indexer.DataField)?.SetValue(indexer.Item, value);
        }
        /// <summary>
        /// Indexer
        /// </summary>
        /// <param name="indexer"></param>
        /// <returns></returns>
        public object?[] this[Indexer<object[]> indexer]
        {
            get
            {
                string[]? tmps = indexer.DataField.Split(',');
                object?[] objects = new object[tmps.Length];

                for (int i = 0; i < tmps.Length; i++)
                    objects[i] = typeof(TItem).GetProperty(tmps[i])?.GetValue(indexer.Item);

                return objects;
            }
            set
            {
                string[]? tmps = indexer.DataField.Split(',');

                for (int i = 0; i < tmps.Length; i++)
                    typeof(TItem).GetProperty(tmps[i])?.SetValue(indexer.Item, value[i]);
            }
        }
        #endregion
    }
}