namespace MetaFrm.Razor.Essentials
{
    /// <summary>
    /// ColumnDefinitions
    /// </summary>
    public class ColumnDefinitions
    {
        /// <summary>
        /// DataField
        /// </summary>
        public string DataField { get; set; } = string.Empty;

        /// <summary>
        /// Caption
        /// </summary>
        public string Caption { get; set; } = string.Empty;

        /// <summary>
        /// DataType
        /// </summary>
        public Database.DbType DataType { get; set; } = Database.DbType.NVarChar;

        /// <summary>
        /// Format
        /// </summary>
        public string Format { get; set; } = string.Empty;

        /// <summary>
        /// Alignment
        /// </summary>
        public Alignment Alignment { get; set; } = Alignment.NotSet;

        /// <summary>
        /// AlignString
        /// </summary>
        public string AlignString => this.Alignment switch
        {
            Alignment.NotSet => "",
            Alignment.Left => "left",
            Alignment.Center => "center",
            Alignment.Right => "right",
            _ => "",
        };

        /// <summary>
        /// SortDirection
        /// </summary>
        public SortDirection SortDirection { get; set; } = SortDirection.NotSet;

        /// <summary>
        /// SortString
        /// </summary>
        public string SortString => this.SortDirection switch
        {
            SortDirection.NotSet => "",
            SortDirection.Ascending => "∧",
            SortDirection.Descending => "∨",
            SortDirection.Normal => "",
            _ => "",
        };

        /// <summary>
        /// CssClassTh
        /// </summary>
        public string CssClassTh { get; set; } = string.Empty;

        /// <summary>
        /// CssClassTd
        /// </summary>
        public string CssClassTd { get; set; } = "text-break";

        /// <summary>
        /// CssClass
        /// </summary>
        public string CssClass { get; set; } = string.Empty;

        /// <summary>
        /// EditAble
        /// </summary>
        public bool Editable { get; set; }

        /// <summary>
        /// ColumnDefinitions
        /// </summary>
        public ColumnDefinitions() { }


        /// <summary>
        /// ColumnDefinitions
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="dataField"></param>
        /// <param name="caption"></param>
        public ColumnDefinitions(Database.DbType dataType, string dataField, string caption)
        {
            this.DataField = dataField;
            this.Caption = caption;
            this.DataType = dataType;
        }
        /// <summary>
        /// ColumnDefinitions
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="dataField"></param>
        /// <param name="caption"></param>
        /// <param name="editable"></param>
        public ColumnDefinitions(Database.DbType dataType, string dataField, string caption, bool editable = false)
        {
            this.DataField = dataField;
            this.Caption = caption;
            this.DataType = dataType;
            this.Editable = editable;
        }
        /// <summary>
        /// ColumnDefinitions
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="dataField"></param>
        /// <param name="caption"></param>
        /// <param name="cssClass"></param>
        public ColumnDefinitions(Database.DbType dataType, string dataField, string caption, string cssClass = "")
        {
            this.DataField = dataField;
            this.Caption = caption;
            this.DataType = dataType;
            this.CssClass = cssClass == "" ? string.Empty : cssClass;
        }
        /// <summary>
        /// ColumnDefinitions
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="dataField"></param>
        /// <param name="caption"></param>
        /// <param name="cssClass"></param>
        /// <param name="editable"></param>
        public ColumnDefinitions(Database.DbType dataType, string dataField, string caption, string cssClass = "", bool editable = false)
        {
            this.DataField = dataField;
            this.Caption = caption;
            this.DataType = dataType;
            this.CssClass = cssClass == "" ? string.Empty : cssClass;
            this.Editable = editable;
        }
        /// <summary>
        /// ColumnDefinitions
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="dataField"></param>
        /// <param name="caption"></param>
        /// <param name="cssClass"></param>
        /// <param name="cssClassTh"></param>
        public ColumnDefinitions(Database.DbType dataType, string dataField, string caption, string cssClass = "", string cssClassTh = "")
        {
            this.DataField = dataField;
            this.Caption = caption;
            this.DataType = dataType;
            this.CssClassTh = cssClassTh == "" ? string.Empty : cssClassTh;
            this.CssClass = cssClass == "" ? string.Empty : cssClass;
        }
        /// <summary>
        /// ColumnDefinitions
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="dataField"></param>
        /// <param name="caption"></param>
        /// <param name="cssClass"></param>
        /// <param name="cssClassTh"></param>
        /// <param name="editable"></param>
        public ColumnDefinitions(Database.DbType dataType, string dataField, string caption, string cssClass = "", string cssClassTh = "", bool editable = false)
        {
            this.DataField = dataField;
            this.Caption = caption;
            this.DataType = dataType;
            this.CssClassTh = cssClassTh == "" ? string.Empty : cssClassTh;
            this.CssClass = cssClass == "" ? string.Empty : cssClass;
            this.Editable = editable;
        }
        /// <summary>
        /// ColumnDefinitions
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="dataField"></param>
        /// <param name="caption"></param>
        /// <param name="cssClass"></param>
        /// <param name="cssClassTh"></param>
        /// <param name="cssClassTd"></param>
        public ColumnDefinitions(Database.DbType dataType, string dataField, string caption, string cssClass = "", string cssClassTh = "", string cssClassTd = "text-break")
        {
            this.DataField = dataField;
            this.Caption = caption;
            this.DataType = dataType;
            this.CssClassTh = cssClassTh == "" ? string.Empty : cssClassTh;
            this.CssClassTd = cssClassTd == "" ? string.Empty : cssClassTd;
            this.CssClass = cssClass == "" ? string.Empty : cssClass;
        }
        /// <summary>
        /// ColumnDefinitions
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="dataField"></param>
        /// <param name="caption"></param>
        /// <param name="cssClass"></param>
        /// <param name="cssClassTh"></param>
        /// <param name="cssClassTd"></param>
        /// <param name="editable"></param>
        public ColumnDefinitions(Database.DbType dataType, string dataField, string caption, string cssClass = "", string cssClassTh = "", string cssClassTd = "text-break", bool editable = false)
        {
            this.DataField = dataField;
            this.Caption = caption;
            this.DataType = dataType;
            this.CssClassTh = cssClassTh == "" ? string.Empty : cssClassTh;
            this.CssClassTd = cssClassTd == "" ? string.Empty : cssClassTd;
            this.CssClass = cssClass == "" ? string.Empty : cssClass;
            this.Editable = editable;
        }
        /// <summary>
        /// ColumnDefinitions
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="dataField"></param>
        /// <param name="caption"></param>
        /// <param name="cssClass"></param>
        /// <param name="cssClassTh"></param>
        /// <param name="cssClassTd"></param>
        /// <param name="format"></param>
        public ColumnDefinitions(Database.DbType dataType, string dataField, string caption, string cssClass = "", string cssClassTh = "", string cssClassTd = "text-break", string format = "")
        {
            this.DataField = dataField;
            this.Caption = caption;
            this.DataType = dataType;
            this.Format = format == "" ? string.Empty : format;
            this.CssClassTh = cssClassTh == "" ? string.Empty : cssClassTh;
            this.CssClassTd = cssClassTd == "" ? string.Empty : cssClassTd;
            this.CssClass = cssClass == "" ? string.Empty : cssClass;
        }
        /// <summary>
        /// ColumnDefinitions
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="dataField"></param>
        /// <param name="caption"></param>
        /// <param name="cssClass"></param>
        /// <param name="cssClassTh"></param>
        /// <param name="cssClassTd"></param>
        /// <param name="format"></param>
        /// <param name="editable"></param>
        public ColumnDefinitions(Database.DbType dataType, string dataField, string caption, string cssClass = "", string cssClassTh = "", string cssClassTd = "text-break", string format = "", bool editable = false)
        {
            this.DataField = dataField;
            this.Caption = caption;
            this.DataType = dataType;
            this.Format = format == "" ? string.Empty : format;
            this.CssClassTh = cssClassTh == "" ? string.Empty : cssClassTh;
            this.CssClassTd = cssClassTd == "" ? string.Empty : cssClassTd;
            this.CssClass = cssClass == "" ? string.Empty : cssClass;
            this.Editable = editable;
        }

        /// <summary>
        /// ColumnDefinitions
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="sortDirection"></param>
        /// <param name="dataField"></param>
        /// <param name="caption"></param>
        public ColumnDefinitions(Database.DbType dataType, SortDirection sortDirection, string dataField, string caption)
        {
            this.DataField = dataField;
            this.Caption = caption;
            this.DataType = dataType;
            this.SortDirection = sortDirection;
        }
        /// <summary>
        /// ColumnDefinitions
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="sortDirection"></param>
        /// <param name="dataField"></param>
        /// <param name="caption"></param>
        /// <param name="editable"></param>
        public ColumnDefinitions(Database.DbType dataType, SortDirection sortDirection, string dataField, string caption, bool editable = false)
        {
            this.DataField = dataField;
            this.Caption = caption;
            this.DataType = dataType;
            this.SortDirection = sortDirection;
            this.Editable = editable;
        }
        /// <summary>
        /// ColumnDefinitions
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="sortDirection"></param>
        /// <param name="dataField"></param>
        /// <param name="caption"></param>
        /// <param name="cssClass"></param>
        public ColumnDefinitions(Database.DbType dataType, SortDirection sortDirection, string dataField, string caption, string cssClass = "")
        {
            this.DataField = dataField;
            this.Caption = caption;
            this.DataType = dataType;
            this.SortDirection = sortDirection;
            this.CssClass = cssClass == "" ? string.Empty : cssClass;
        }
        /// <summary>
        /// ColumnDefinitions
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="sortDirection"></param>
        /// <param name="dataField"></param>
        /// <param name="caption"></param>
        /// <param name="cssClass"></param>
        /// <param name="editable"></param>
        public ColumnDefinitions(Database.DbType dataType, SortDirection sortDirection, string dataField, string caption, string cssClass = "", bool editable = false)
        {
            this.DataField = dataField;
            this.Caption = caption;
            this.DataType = dataType;
            this.SortDirection = sortDirection;
            this.CssClass = cssClass == "" ? string.Empty : cssClass;
            this.Editable = editable;
        }
        /// <summary>
        /// ColumnDefinitions
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="sortDirection"></param>
        /// <param name="dataField"></param>
        /// <param name="caption"></param>
        /// <param name="cssClass"></param>
        /// <param name="cssClassTh"></param>
        public ColumnDefinitions(Database.DbType dataType, SortDirection sortDirection, string dataField, string caption, string cssClass = "", string cssClassTh = "")
        {
            this.DataField = dataField;
            this.Caption = caption;
            this.DataType = dataType;
            this.SortDirection = sortDirection;
            this.CssClassTh = cssClassTh == "" ? string.Empty : cssClassTh;
            this.CssClass = cssClass == "" ? string.Empty : cssClass;
        }
        /// <summary>
        /// ColumnDefinitions
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="sortDirection"></param>
        /// <param name="dataField"></param>
        /// <param name="caption"></param>
        /// <param name="cssClass"></param>
        /// <param name="cssClassTh"></param>
        /// <param name="editable"></param>
        public ColumnDefinitions(Database.DbType dataType, SortDirection sortDirection, string dataField, string caption, string cssClass = "", string cssClassTh = "", bool editable = false)
        {
            this.DataField = dataField;
            this.Caption = caption;
            this.DataType = dataType;
            this.SortDirection = sortDirection;
            this.CssClassTh = cssClassTh == "" ? string.Empty : cssClassTh;
            this.CssClass = cssClass == "" ? string.Empty : cssClass;
            this.Editable = editable;
        }
        /// <summary>
        /// ColumnDefinitions
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="sortDirection"></param>
        /// <param name="dataField"></param>
        /// <param name="caption"></param>
        /// <param name="cssClass"></param>
        /// <param name="cssClassTh"></param>
        /// <param name="cssClassTd"></param>
        public ColumnDefinitions(Database.DbType dataType, SortDirection sortDirection, string dataField, string caption, string cssClass = "", string cssClassTh = "", string cssClassTd = "text-break")
        {
            this.DataField = dataField;
            this.Caption = caption;
            this.DataType = dataType;
            this.SortDirection = sortDirection;
            this.CssClassTh = cssClassTh == "" ? string.Empty : cssClassTh;
            this.CssClassTd = cssClassTd == "" ? string.Empty : cssClassTd;
            this.CssClass = cssClass == "" ? string.Empty : cssClass;
        }
        /// <summary>
        /// ColumnDefinitions
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="sortDirection"></param>
        /// <param name="dataField"></param>
        /// <param name="caption"></param>
        /// <param name="cssClass"></param>
        /// <param name="cssClassTh"></param>
        /// <param name="cssClassTd"></param>
        /// <param name="editable"></param>
        public ColumnDefinitions(Database.DbType dataType, SortDirection sortDirection, string dataField, string caption, string cssClass = "", string cssClassTh = "", string cssClassTd = "text-break", bool editable = false)
        {
            this.DataField = dataField;
            this.Caption = caption;
            this.DataType = dataType;
            this.SortDirection = sortDirection;
            this.CssClassTh = cssClassTh == "" ? string.Empty : cssClassTh;
            this.CssClassTd = cssClassTd == "" ? string.Empty : cssClassTd;
            this.CssClass = cssClass == "" ? string.Empty : cssClass;
            this.Editable = editable;
        }
        /// <summary>
        /// ColumnDefinitions
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="sortDirection"></param>
        /// <param name="dataField"></param>
        /// <param name="caption"></param>
        /// <param name="cssClass"></param>
        /// <param name="cssClassTh"></param>
        /// <param name="cssClassTd"></param>
        /// <param name="format"></param>
        public ColumnDefinitions(Database.DbType dataType, SortDirection sortDirection, string dataField, string caption, string cssClass = "", string cssClassTh = "", string cssClassTd = "text-break", string format = "")
        {
            this.DataField = dataField;
            this.Caption = caption;
            this.DataType = dataType;
            this.Format = format == "" ? string.Empty : format;
            this.SortDirection = sortDirection;
            this.CssClassTh = cssClassTh == "" ? string.Empty : cssClassTh;
            this.CssClassTd = cssClassTd == "" ? string.Empty : cssClassTd;
            this.CssClass = cssClass == "" ? string.Empty : cssClass;
        }
        /// <summary>
        /// ColumnDefinitions
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="sortDirection"></param>
        /// <param name="dataField"></param>
        /// <param name="caption"></param>
        /// <param name="cssClass"></param>
        /// <param name="cssClassTh"></param>
        /// <param name="cssClassTd"></param>
        /// <param name="format"></param>
        /// <param name="editable"></param>
        public ColumnDefinitions(Database.DbType dataType, SortDirection sortDirection, string dataField, string caption, string cssClass = "", string cssClassTh = "", string cssClassTd = "text-break", string format = "", bool editable = false)
        {
            this.DataField = dataField;
            this.Caption = caption;
            this.DataType = dataType;
            this.Format = format == "" ? string.Empty : format;
            this.SortDirection = sortDirection;
            this.CssClassTh = cssClassTh == "" ? string.Empty : cssClassTh;
            this.CssClassTd = cssClassTd == "" ? string.Empty : cssClassTd;
            this.CssClass = cssClass == "" ? string.Empty : cssClass;
            this.Editable = editable;
        }

        /// <summary>
        /// ColumnDefinitions
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="alignment"></param>
        /// <param name="dataField"></param>
        /// <param name="caption"></param>
        public ColumnDefinitions(Database.DbType dataType, Alignment alignment, string dataField, string caption)
        {
            this.DataField = dataField;
            this.Caption = caption;
            this.DataType = dataType;
            this.Alignment = alignment;
        }
        /// <summary>
        /// ColumnDefinitions
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="alignment"></param>
        /// <param name="dataField"></param>
        /// <param name="caption"></param>
        /// <param name="editable"></param>
        public ColumnDefinitions(Database.DbType dataType, Alignment alignment, string dataField, string caption, bool editable = false)
        {
            this.DataField = dataField;
            this.Caption = caption;
            this.DataType = dataType;
            this.Alignment = alignment;
            this.Editable = editable;
        }
        /// <summary>
        /// ColumnDefinitions
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="alignment"></param>
        /// <param name="dataField"></param>
        /// <param name="caption"></param>
        /// <param name="cssClass"></param>
        public ColumnDefinitions(Database.DbType dataType, Alignment alignment, string dataField, string caption, string cssClass = "")
        {
            this.DataField = dataField;
            this.Caption = caption;
            this.DataType = dataType;
            this.Alignment = alignment;
            this.CssClass = cssClass == "" ? string.Empty : cssClass;
        }
        /// <summary>
        /// ColumnDefinitions
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="alignment"></param>
        /// <param name="dataField"></param>
        /// <param name="caption"></param>
        /// <param name="cssClass"></param>
        /// <param name="editable"></param>
        public ColumnDefinitions(Database.DbType dataType, Alignment alignment, string dataField, string caption, string cssClass = "", bool editable = false)
        {
            this.DataField = dataField;
            this.Caption = caption;
            this.DataType = dataType;
            this.Alignment = alignment;
            this.CssClass = cssClass == "" ? string.Empty : cssClass;
            this.Editable = editable;
        }
        /// <summary>
        /// ColumnDefinitions
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="alignment"></param>
        /// <param name="dataField"></param>
        /// <param name="caption"></param>
        /// <param name="cssClass"></param>
        /// <param name="cssClassTh"></param>
        public ColumnDefinitions(Database.DbType dataType, Alignment alignment, string dataField, string caption, string cssClass = "", string cssClassTh = "")
        {
            this.DataField = dataField;
            this.Caption = caption;
            this.DataType = dataType;
            this.Alignment = alignment;
            this.CssClassTh = cssClassTh == "" ? string.Empty : cssClassTh;
            this.CssClass = cssClass == "" ? string.Empty : cssClass;
        }
        /// <summary>
        /// ColumnDefinitions
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="alignment"></param>
        /// <param name="dataField"></param>
        /// <param name="caption"></param>
        /// <param name="cssClass"></param>
        /// <param name="cssClassTh"></param>
        /// <param name="editable"></param>
        public ColumnDefinitions(Database.DbType dataType, Alignment alignment, string dataField, string caption, string cssClass = "", string cssClassTh = "", bool editable = false)
        {
            this.DataField = dataField;
            this.Caption = caption;
            this.DataType = dataType;
            this.Alignment = alignment;
            this.CssClassTh = cssClassTh == "" ? string.Empty : cssClassTh;
            this.CssClass = cssClass == "" ? string.Empty : cssClass;
            this.Editable = editable;
        }
        /// <summary>
        /// ColumnDefinitions
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="alignment"></param>
        /// <param name="dataField"></param>
        /// <param name="caption"></param>
        /// <param name="cssClass"></param>
        /// <param name="cssClassTh"></param>
        /// <param name="cssClassTd"></param>
        public ColumnDefinitions(Database.DbType dataType, Alignment alignment, string dataField, string caption, string cssClass = "", string cssClassTh = "", string cssClassTd = "text-break")
        {
            this.DataField = dataField;
            this.Caption = caption;
            this.DataType = dataType;
            this.Alignment = alignment;
            this.CssClassTh = cssClassTh == "" ? string.Empty : cssClassTh;
            this.CssClassTd = cssClassTd == "" ? string.Empty : cssClassTd;
            this.CssClass = cssClass == "" ? string.Empty : cssClass;
        }
        /// <summary>
        /// ColumnDefinitions
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="alignment"></param>
        /// <param name="dataField"></param>
        /// <param name="caption"></param>
        /// <param name="cssClass"></param>
        /// <param name="cssClassTh"></param>
        /// <param name="cssClassTd"></param>
        /// <param name="editable"></param>
        public ColumnDefinitions(Database.DbType dataType, Alignment alignment, string dataField, string caption, string cssClass = "", string cssClassTh = "", string cssClassTd = "text-break", bool editable = false)
        {
            this.DataField = dataField;
            this.Caption = caption;
            this.DataType = dataType;
            this.Alignment = alignment;
            this.CssClassTh = cssClassTh == "" ? string.Empty : cssClassTh;
            this.CssClassTd = cssClassTd == "" ? string.Empty : cssClassTd;
            this.CssClass = cssClass == "" ? string.Empty : cssClass;
            this.Editable = editable;
        }
        /// <summary>
        /// ColumnDefinitions
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="alignment"></param>
        /// <param name="dataField"></param>
        /// <param name="caption"></param>
        /// <param name="cssClass"></param>
        /// <param name="cssClassTh"></param>
        /// <param name="cssClassTd"></param>
        /// <param name="format"></param>
        public ColumnDefinitions(Database.DbType dataType, Alignment alignment, string dataField, string caption, string cssClass = "", string cssClassTh = "", string cssClassTd = "text-break", string format = "")
        {
            this.DataField = dataField;
            this.Caption = caption;
            this.DataType = dataType;
            this.Format = format == "" ? string.Empty : format;
            this.Alignment = alignment;
            this.CssClassTh = cssClassTh == "" ? string.Empty : cssClassTh;
            this.CssClassTd = cssClassTd == "" ? string.Empty : cssClassTd;
            this.CssClass = cssClass == "" ? string.Empty : cssClass;
        }
        /// <summary>
        /// ColumnDefinitions
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="alignment"></param>
        /// <param name="dataField"></param>
        /// <param name="caption"></param>
        /// <param name="cssClass"></param>
        /// <param name="cssClassTh"></param>
        /// <param name="cssClassTd"></param>
        /// <param name="format"></param>
        /// <param name="editable"></param>
        public ColumnDefinitions(Database.DbType dataType, Alignment alignment, string dataField, string caption, string cssClass = "", string cssClassTh = "", string cssClassTd = "text-break", string format = "", bool editable = false)
        {
            this.DataField = dataField;
            this.Caption = caption;
            this.DataType = dataType;
            this.Format = format == "" ? string.Empty : format;
            this.Alignment = alignment;
            this.CssClassTh = cssClassTh == "" ? string.Empty : cssClassTh;
            this.CssClassTd = cssClassTd == "" ? string.Empty : cssClassTd;
            this.CssClass = cssClass == "" ? string.Empty : cssClass;
            this.Editable = editable;
        }

        /// <summary>
        /// ColumnDefinitions
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="sortDirection"></param>
        /// <param name="alignment"></param>
        /// <param name="dataField"></param>
        /// <param name="caption"></param>
        public ColumnDefinitions(Database.DbType dataType, SortDirection sortDirection, Alignment alignment, string dataField, string caption)
        {
            this.DataField = dataField;
            this.Caption = caption;
            this.DataType = dataType;
            this.Alignment = alignment;
            this.SortDirection = sortDirection;
        }
        /// <summary>
        /// ColumnDefinitions
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="sortDirection"></param>
        /// <param name="alignment"></param>
        /// <param name="dataField"></param>
        /// <param name="caption"></param>
        /// <param name="editable"></param>
        public ColumnDefinitions(Database.DbType dataType, SortDirection sortDirection, Alignment alignment, string dataField, string caption, bool editable = false)
        {
            this.DataField = dataField;
            this.Caption = caption;
            this.DataType = dataType;
            this.Alignment = alignment;
            this.SortDirection = sortDirection;
            this.Editable = editable;
        }
        /// <summary>
        /// ColumnDefinitions
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="sortDirection"></param>
        /// <param name="alignment"></param>
        /// <param name="dataField"></param>
        /// <param name="caption"></param>
        /// <param name="cssClass"></param>
        public ColumnDefinitions(Database.DbType dataType, SortDirection sortDirection, Alignment alignment, string dataField, string caption, string cssClass = "")
        {
            this.DataField = dataField;
            this.Caption = caption;
            this.DataType = dataType;
            this.Alignment = alignment;
            this.SortDirection = sortDirection;
            this.CssClass = cssClass == "" ? string.Empty : cssClass;
        }
        /// <summary>
        /// ColumnDefinitions
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="sortDirection"></param>
        /// <param name="alignment"></param>
        /// <param name="dataField"></param>
        /// <param name="caption"></param>
        /// <param name="cssClass"></param>
        /// <param name="editable"></param>
        public ColumnDefinitions(Database.DbType dataType, SortDirection sortDirection, Alignment alignment, string dataField, string caption, string cssClass = "", bool editable = false)
        {
            this.DataField = dataField;
            this.Caption = caption;
            this.DataType = dataType;
            this.Alignment = alignment;
            this.SortDirection = sortDirection;
            this.CssClass = cssClass == "" ? string.Empty : cssClass;
            this.Editable = editable;
        }
        /// <summary>
        /// ColumnDefinitions
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="sortDirection"></param>
        /// <param name="alignment"></param>
        /// <param name="dataField"></param>
        /// <param name="caption"></param>
        /// <param name="cssClass"></param>
        /// <param name="cssClassTh"></param>
        public ColumnDefinitions(Database.DbType dataType, SortDirection sortDirection, Alignment alignment, string dataField, string caption, string cssClass = "", string cssClassTh = "")
        {
            this.DataField = dataField;
            this.Caption = caption;
            this.DataType = dataType;
            this.Alignment = alignment;
            this.SortDirection = sortDirection;
            this.CssClassTh = cssClassTh == "" ? string.Empty : cssClassTh;
            this.CssClass = cssClass == "" ? string.Empty : cssClass;
        }
        /// <summary>
        /// ColumnDefinitions
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="sortDirection"></param>
        /// <param name="alignment"></param>
        /// <param name="dataField"></param>
        /// <param name="caption"></param>
        /// <param name="cssClass"></param>
        /// <param name="cssClassTh"></param>
        /// <param name="editable"></param>
        public ColumnDefinitions(Database.DbType dataType, SortDirection sortDirection, Alignment alignment, string dataField, string caption, string cssClass = "", string cssClassTh = "", bool editable = false)
        {
            this.DataField = dataField;
            this.Caption = caption;
            this.DataType = dataType;
            this.Alignment = alignment;
            this.SortDirection = sortDirection;
            this.CssClassTh = cssClassTh == "" ? string.Empty : cssClassTh;
            this.CssClass = cssClass == "" ? string.Empty : cssClass;
            this.Editable = editable;
        }
        /// <summary>
        /// ColumnDefinitions
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="sortDirection"></param>
        /// <param name="alignment"></param>
        /// <param name="dataField"></param>
        /// <param name="caption"></param>
        /// <param name="cssClass"></param>
        /// <param name="cssClassTh"></param>
        /// <param name="cssClassTd"></param>
        public ColumnDefinitions(Database.DbType dataType, SortDirection sortDirection, Alignment alignment, string dataField, string caption, string cssClass = "", string cssClassTh = "", string cssClassTd = "text-break")
        {
            this.DataField = dataField;
            this.Caption = caption;
            this.DataType = dataType;
            this.Alignment = alignment;
            this.SortDirection = sortDirection;
            this.CssClassTh = cssClassTh == "" ? string.Empty : cssClassTh;
            this.CssClassTd = cssClassTd == "" ? string.Empty : cssClassTd;
            this.CssClass = cssClass == "" ? string.Empty : cssClass;
        }
        /// <summary>
        /// ColumnDefinitions
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="sortDirection"></param>
        /// <param name="alignment"></param>
        /// <param name="dataField"></param>
        /// <param name="caption"></param>
        /// <param name="cssClass"></param>
        /// <param name="cssClassTh"></param>
        /// <param name="cssClassTd"></param>
        /// <param name="editable"></param>
        public ColumnDefinitions(Database.DbType dataType, SortDirection sortDirection, Alignment alignment, string dataField, string caption, string cssClass = "", string cssClassTh = "", string cssClassTd = "text-break", bool editable=false)
        {
            this.DataField = dataField;
            this.Caption = caption;
            this.DataType = dataType;
            this.Alignment = alignment;
            this.SortDirection = sortDirection;
            this.CssClassTh = cssClassTh == "" ? string.Empty : cssClassTh;
            this.CssClassTd = cssClassTd == "" ? string.Empty : cssClassTd;
            this.CssClass = cssClass == "" ? string.Empty : cssClass;
            this.Editable = editable;
        }
        /// <summary>
        /// ColumnDefinitions
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="sortDirection"></param>
        /// <param name="alignment"></param>
        /// <param name="dataField"></param>
        /// <param name="caption"></param>
        /// <param name="cssClass"></param>
        /// <param name="cssClassTh"></param>
        /// <param name="cssClassTd"></param>
        /// <param name="format"></param>
        public ColumnDefinitions(Database.DbType dataType, SortDirection sortDirection, Alignment alignment, string dataField, string caption, string cssClass = "", string cssClassTh = "", string cssClassTd = "text-break", string format = "")
        {
            this.DataField = dataField;
            this.Caption = caption;
            this.DataType = dataType;
            this.Format = format == "" ? string.Empty : format;
            this.Alignment = alignment;
            this.SortDirection = sortDirection;
            this.CssClassTh = cssClassTh == "" ? string.Empty : cssClassTh;
            this.CssClassTd = cssClassTd == "" ? string.Empty : cssClassTd;
            this.CssClass = cssClass == "" ? string.Empty : cssClass;
        }
        /// <summary>
        /// ColumnDefinitions
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="sortDirection"></param>
        /// <param name="alignment"></param>
        /// <param name="dataField"></param>
        /// <param name="caption"></param>
        /// <param name="cssClass"></param>
        /// <param name="cssClassTh"></param>
        /// <param name="cssClassTd"></param>
        /// <param name="format"></param>
        /// <param name="editable"></param>
        public ColumnDefinitions(Database.DbType dataType, SortDirection sortDirection, Alignment alignment, string dataField, string caption, string cssClass = "", string cssClassTh = "", string cssClassTd = "text-break", string format = "", bool editable = false)
        {
            this.DataField = dataField;
            this.Caption = caption;
            this.DataType = dataType;
            this.Format = format == "" ? string.Empty : format;
            this.Alignment = alignment;
            this.SortDirection = sortDirection;
            this.CssClassTh = cssClassTh == "" ? string.Empty : cssClassTh;
            this.CssClassTd = cssClassTd == "" ? string.Empty : cssClassTd;
            this.CssClass = cssClass == "" ? string.Empty : cssClass;
            this.Editable = editable;
        }
    }
}