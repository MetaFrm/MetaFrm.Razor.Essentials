namespace MetaFrm.Razor.DataGrid
{
    /// <summary>
    /// PagingConfig
    /// </summary>
    public class PagingConfig : ICore
    {
        /// <summary>
        /// Enabled
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// PageSize
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// CustomPager
        /// </summary>
        public bool CustomPager { get; set; }
    }
}
