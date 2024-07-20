using MetaFrm.Localization;
using MetaFrm.Maui.Devices;
using MetaFrm.Service;
using MetaFrm.Storage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Localization;
using System.Globalization;

namespace MetaFrm.Razor.Essentials.Localization
{
    /// <summary>
    /// LocalizationManager
    /// </summary>
    public class LocalizationManager : IStringLocalizer, ICultureChanged
    {
        private object _lock = new();
        private CultureInfo CurrentCulture = Thread.CurrentThread.CurrentCulture; //CultureInfo.CurrentCulture;
        private static ICookieStorageService? CookieStorageService;
        private static LocalizationManager? localizationManager;
        private static bool IsSaveLanguageDictionaryTmp = false;
        /// <summary>
        /// AuthState
        /// </summary>
        public static Task<AuthenticationState>? AuthState { get; set; }
        /// <summary>
        /// DictionaryCollectionAll
        /// </summary>
        public static Dictionary<string, string> DictionaryCollectionAll { get; set; } = new();
        /// <summary>
        /// DictionaryCollection
        /// </summary>
        public static Dictionary<string, string> DictionaryCollection { get; set; } = new();

        /// <summary>
        /// LocalizationManager
        /// </summary>
        public LocalizationManager(ICookieStorageService? cookieStorageService)
        {
            CookieStorageService = cookieStorageService;

            localizationManager ??= this;

            this.GetCultureInfo();

            IsSaveLanguageDictionaryTmp = Factory.ProjectService.Attribute.Any(x => x.AttributeName == "IsSaveLanguageDictionaryTmp" && x.AttributeValue == "Y");
        }
        private async void GetCultureInfo()
        {
            if (CookieStorageService == null)
                this.CurrentCulture = Thread.CurrentThread.CurrentCulture;
            else
            {
                try
                {
                    string? tmp = await CookieStorageService.GetItemAsStringAsync(".AspNetCore.Culture");//c=es-MX|uic=es-MX

                    if (tmp == null)
                        this.CurrentCulture = Thread.CurrentThread.CurrentCulture;
                    else
                    {
                        if (tmp.Contains('|'))
                            tmp = tmp.Split('|')[0];

                        if (tmp.Contains("c=") && tmp.Contains('-'))
                            this.CurrentCulture = new(tmp.Split('=')[1]);
                        else
                            this.CurrentCulture = Thread.CurrentThread.CurrentCulture;
                    }
                }
                catch (Exception)
                {
                    this.CurrentCulture = Thread.CurrentThread.CurrentCulture;
                }
            }
        }
        private async void SetCultureInfo(CultureInfo cultureInfo)
        {
            if (CookieStorageService != null)
            {
                try
                {
                    await CookieStorageService.SetItemAsStringAsync(".AspNetCore.Culture", $"c={cultureInfo.Name}|uic={cultureInfo.Name}", 365);//c=es-MX|uic=es-MX
                }
                catch (Exception)
                {
                }
            }

            this.CurrentCulture = cultureInfo;
        }

        /// <summary>
        /// Gets the string resource with the given name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public LocalizedString this[string name]
        {
            get 
            {
                LocalizedString localizedString = new(name, name.Translate(this.CurrentCulture, out bool? successful));

                if (successful != null && successful == false)
                    this.DictionaryCollectionInsert(name, this.CurrentCulture);

                return localizedString;
            }
        }

        /// <summary>
        /// Gets the string resource with the given name and formatted with the supplied arguments.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                bool? successful;
                LocalizedString localizedString;

                if (arguments != null && arguments.Length > 0 && arguments is string[])
                    localizedString = new(name, name.Translate(this.CurrentCulture, out successful, Array.ConvertAll(arguments, x => (string)x)));
                else
                    localizedString = new(name, name.Translate(this.CurrentCulture, out successful));

                if (successful != null && successful == false)
                    this.DictionaryCollectionInsert(name, this.CurrentCulture);

                return localizedString;
            }
        }

        /// <summary>
        /// Gets all string resources.
        /// </summary>
        /// <param name="includeParentCultures"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Instance
        /// </summary>
        public static LocalizationManager Instance { get; } = localizationManager ?? new (CookieStorageService);

        /// <summary>
        /// CultureChange
        /// </summary>
        /// <param name="cultureInfo"></param>
        public void CultureChange(CultureInfo cultureInfo)
        {
            this.SetCultureInfo(cultureInfo);

            if (localizationManager != null && !this.Equals(localizationManager))
                localizationManager.CultureChange(cultureInfo);
        }

        /// <summary>
        /// CultureInfo
        /// </summary>
        public CultureInfo CultureInfo => this.CurrentCulture;


        private static DateTime LastRun = DateTime.Now;

        /// <summary>
        /// DictionaryCollectionInsert
        /// </summary>
        /// <param name="name"></param>
        /// <param name="cultureInfo"></param>
        public void DictionaryCollectionInsert(string name, CultureInfo cultureInfo)
        {
            if (Factory.Platform != DevicePlatform.iOS && Factory.Platform != DevicePlatform.Android && Factory.Platform != DevicePlatform.WinUI)
                return;

            if (!IsSaveLanguageDictionaryTmp)
                return;

            lock (_lock)
                if (!DictionaryCollectionAll.TryGetValue(name, out var _))
                {
                    DictionaryCollectionAll.Add(name, cultureInfo.Name);

                    if (!DictionaryCollection.TryGetValue(name, out var _))
                        DictionaryCollection.Add(name, cultureInfo.Name);

                }


            DateTime date = DateTime.Now;
            bool isRun = false;

            lock (_lock)
                if (DictionaryCollection.Count > 100 || (date - LastRun).TotalMinutes >= 10)
                {
                    LastRun = DateTime.Now;
                    isRun = true;
                }

            if (isRun)
                this.DictionaryCollectionUpload();
        }

        private async void DictionaryCollectionUpload()
        {
            Response response;

            if (!IsSaveLanguageDictionaryTmp)
                return;

            if (AuthState == null || !AuthState.IsLogin())
                return;

            try
            {
                ServiceData serviceData = new()
                {
                    TransactionScope = true,
                    Token = AuthState.Token()
                };
                serviceData["1"].CommandText = this.GetAttribute("SaveTemp");
                serviceData["1"].AddParameter("CULTURE_NAME", Database.DbType.NVarChar, 10);
                serviceData["1"].AddParameter("STRING", Database.DbType.NVarChar, 4000);
                serviceData["1"].AddParameter("USER_ID", Database.DbType.Int, 3);

                lock (_lock)
                {
                    foreach (var item in DictionaryCollection)
                    {
                        serviceData["1"].NewRow();
                        serviceData["1"].SetValue("CULTURE_NAME", item.Value);
                        serviceData["1"].SetValue("STRING", item.Key);
                        serviceData["1"].SetValue("USER_ID", AuthState.UserID());
                    }

                    DictionaryCollection.Clear();
                }

                response = await this.ServiceRequestAsync(serviceData);

                if (response.Status != Status.OK)
                    ;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}