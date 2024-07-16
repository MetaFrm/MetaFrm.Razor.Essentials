using Blazored.LocalStorage;
using MetaFrm.Localization;
using Microsoft.Extensions.Localization;
using System.Globalization;

namespace MetaFrm.Razor.Essentials.Localization
{
    /// <summary>
    /// LocalizationManager
    /// </summary>
    public class LocalizationManager : IStringLocalizer, ICultureChanged
    {
        private CultureInfo CurrentCulture = Thread.CurrentThread.CurrentCulture; //CultureInfo.CurrentCulture;
        private readonly ILocalStorageService? LocalStorage;

        /// <summary>
        /// LocalizationManager
        /// </summary>
        public LocalizationManager(ILocalStorageService? localStorageService)
        {
            this.LocalStorage = localStorageService;

            this.GetCultureInfo();
        }
        private async void GetCultureInfo()
        {
            if (this.LocalStorage == null)
                this.CurrentCulture = Thread.CurrentThread.CurrentCulture;
            else
            {
                try
                {
                    string? tmp = await this.LocalStorage.GetItemAsStringAsync(".AspNetCore.Culture");//c=es-MX|uic=es-MX

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
            if (this.LocalStorage != null)
            {
                try
                {
                    await this.LocalStorage.SetItemAsStringAsync(".AspNetCore.Culture", $"c={cultureInfo.Name}|uic={cultureInfo.Name}");//c=es-MX|uic=es-MX
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
        public LocalizedString this[string name] => new(name, name.Translate(this.CurrentCulture));

        /// <summary>
        /// Gets the string resource with the given name and formatted with the supplied arguments.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public LocalizedString this[string name, params object[] arguments] => new(name, arguments != null && arguments.Length > 0 && arguments[0] is string ?
            name.Translate(this.CurrentCulture, Array.ConvertAll(arguments, x => (string)x))
            : arguments == null ? name : string.Format(name, arguments));

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
        /// CultureChange
        /// </summary>
        /// <param name="cultureInfo"></param>
        public void CultureChange(CultureInfo cultureInfo)
        {
            this.SetCultureInfo(cultureInfo);
        }
    }
}