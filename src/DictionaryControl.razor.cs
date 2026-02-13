using MetaFrm.Database;
using MetaFrm.Service;
using MetaFrm.Web.Bootstrap;
using Microsoft.AspNetCore.Components;

namespace MetaFrm.Razor.Essentials
{
    /// <summary>
    /// DictionaryControl
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "BL0007:Component parameters should be auto properties", Justification = "<보류 중>")]
    public partial class DictionaryControl : ICore
    {
        private string? CODE;
        /// <summary>
        /// CODE
        /// </summary>
        [Parameter]
        public string? Code { get { return this.CODE; } set { this.CODE = value; } }

        private string? SEARCH_TEXT;
        /// <summary>
        /// SEARCH_TEXT
        /// </summary>
        [Parameter]
        public string? SearchText { get { return this.SEARCH_TEXT; } set { this.SEARCH_TEXT = value; } }

        private int SEARCH_INDEX;
        /// <summary>
        /// SEARCH_INDEX
        /// </summary>
        [Parameter]
        public int SearchIndex { get { return this.SEARCH_INDEX; } set { this.SEARCH_INDEX = value; } }

        private string? COND_ETC;
        /// <summary>
        /// COND_ETC
        /// </summary>
        [Parameter]
        public string? CondtionEtc { get { return this.COND_ETC; } set { this.COND_ETC = value; } }

        private string? SEARCH_ALL;
        /// <summary>
        /// SEARCH_ALL
        /// </summary>
        [Parameter]
        public string? SearchAll { get { return this.SEARCH_ALL; } set { this.SEARCH_ALL = value; } }

        private string? STARTS_WITH;
        /// <summary>
        /// STARTS_WITH
        /// </summary>
        [Parameter]
        public string? StartsWith { get { return this.STARTS_WITH; } set { this.STARTS_WITH = value; } }

        /// <summary>
        /// Control
        /// </summary>
        [Parameter]
        public RenderFragment? Control { get; set; }

        /// <summary>
        /// Items
        /// </summary>
        [Parameter]
        public IEnumerable<Data.DataRow>? Items { get; set; }
        /// <summary>
        /// Items1
        /// </summary>
        public IEnumerable<Data.DataRow>? Items1 { get; set; }

        /// <summary>
        /// ResultEvent
        /// </summary>
        [Parameter]
        public EventCallback<IEnumerable<Data.DataRow>> ResultEvent { get; set; }

        /// <summary>
        /// AppendEmptyItem
        /// </summary>
        [Parameter]
        public bool AppendEmptyItem { get; set; }


        /// <summary>
        /// DataField
        /// </summary>
        [Parameter]
        public string DataField { get; set; } = string.Empty;

        /// <summary>
        /// Caption
        /// </summary>
        [Parameter]
        public string Caption { get; set; } = string.Empty;

        /// <summary>
        /// DataType
        /// </summary>
        [Parameter]
        public DbType DataType { get; set; } = DbType.NVarChar;

        private static readonly Dictionary<string, Data.DataTable> CacheData = [];

        /// <summary>
        /// OnInitialized
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();

            if (this.Items == null || !this.Items.Any())
                this.Search();
        }

        private void Search()
        {
            Response response;
            string key;

            try
            {
                key = $"{this.CODE}_{this.SEARCH_TEXT}_{this.SEARCH_INDEX}_{this.COND_ETC}_{this.SEARCH_ALL}_{this.STARTS_WITH}";

                if (!CacheData.TryGetValue(key, out Data.DataTable? dataTable))
                {
                    ServiceData serviceData = new()
                    {
                        Token = this.AuthState.IsLogin() ? this.AuthState.Token() : Factory.ProjectService.Token
                    };
                    serviceData["1"].CommandText = this.GetAttribute("Exec.Dictionary");
                    serviceData["1"].AddParameter(nameof(this.CODE), DbType.NVarChar, 50, this.CODE);
                    serviceData["1"].AddParameter(nameof(this.SEARCH_TEXT), DbType.NVarChar, 4000, this.SEARCH_TEXT);
                    serviceData["1"].AddParameter(nameof(this.SEARCH_INDEX), DbType.Int, 3, this.SEARCH_INDEX);
                    serviceData["1"].AddParameter(nameof(this.COND_ETC), DbType.NVarChar, 4000, this.COND_ETC);
                    serviceData["1"].AddParameter(nameof(this.SEARCH_ALL), DbType.NVarChar, 1, this.SEARCH_ALL);
                    serviceData["1"].AddParameter(nameof(this.STARTS_WITH), DbType.NVarChar, 1, this.STARTS_WITH);

                    response = serviceData.ServiceRequest(serviceData);

                    if (response.Status == Status.OK)
                    {
                        if (response.DataSet != null && response.DataSet.DataTables.Count > 0)
                        {
                            if (this.AppendEmptyItem)
                            {
                                Data.DataRow dataRow = new();

                                foreach (var column in response.DataSet.DataTables[0].DataColumns)
                                {
                                    if (column.FieldName != null)
                                    {
                                        if (column.FieldName == "SORT")
                                            dataRow.Values[column.FieldName] = new Data.DataValue(0);
                                        else
                                            dataRow.Values[column.FieldName] = new Data.DataValue(null);
                                    }
                                }

                                response.DataSet.DataTables[0].DataRows.Add(dataRow);
                            }

                            dataTable = response.DataSet.DataTables[0];
                        }

                        if (response.DataSet != null && response.DataSet.DataTables.Count > 1 && response.DataSet.DataTables[1].DataRows.Count > 0
                            && response.DataSet.DataTables[1].DataColumns.Any(x => x.FieldName == "IS_CACHE")
                            && response.DataSet.DataTables[1].DataRows[0].String("IS_CACHE") == "Y")
                        {
                            CacheData.Add(key, response.DataSet.DataTables[0]);
                        }
                    }
                    else
                    {
                        if (response.Message != null)
                        {
                            this.ModalShow("Warning", response.Message, new() { { "Ok", Btn.Warning } }, null);
                        }
                    }
                }

                if (dataTable != null)
                {
                    var isSort = dataTable.DataColumns.Select(x => x.FieldName == "SORT");

                    if (isSort.Any(x => x))
                        this.Items = dataTable.DataRows.OrderBy(x => x.Int("SORT"));
                    else
                        this.Items = dataTable.DataRows;

                    if (this.Control == null)
                        this.Items1 = this.Items;

                    this.ResultEvent.InvokeAsync(this.Items);
                }
            }
            catch (Exception e)
            {
                this.ModalShow("An Exception has occurred.", e.Message, new() { { "Ok", Btn.Danger } }, null);
            }
            finally
            {
            }
        }
    }
}