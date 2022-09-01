namespace MetaFrm.Razor.DataGrid
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
        /// SortDirection
        /// </summary>
        public SortDirection SortDirection { get; set; } = SortDirection.NotSet;

        /// <summary>
        /// Class
        /// </summary>
        public string Class { get; set; } = string.Empty;

        /// <summary>
        /// EditAble
        /// </summary>
        public bool Editable { get; set; }

        /// <summary>
        /// ColumnDefinitions
        /// </summary>
        public ColumnDefinitions() { }
    }
}