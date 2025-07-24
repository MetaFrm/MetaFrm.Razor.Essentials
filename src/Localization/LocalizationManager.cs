using MetaFrm.Localization;
using Microsoft.Extensions.Localization;

namespace MetaFrm.Razor.Essentials.Localization
{
    /// <summary>
    /// LocalizationManager
    /// </summary>
    /// <param name="cultureChanged"></param>
    /// <param name="languageCollector"></param>
    public class LocalizationManager(ICultureChanged cultureChanged, ILanguageCollector languageCollector) : IStringLocalizer, ICore
    {
        private readonly ICultureChanged CultureChanged = cultureChanged;
        private readonly ILanguageCollector LanguageCollector = languageCollector;

        /// <summary>
        /// Gets the string resource with the given name.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public LocalizedString this[string key]
        {
            get 
            {
                LocalizedString localizedString = new(key, key.Translate(this.CultureChanged?.CultureInfo ?? Thread.CurrentThread.CurrentCulture, out bool? successful));

                if (successful != null && successful == false)
                    this.LanguageCollector.Add(key);

                return localizedString;
            }
        }

        /// <summary>
        /// Gets the string resource with the given name and formatted with the supplied arguments.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public LocalizedString this[string key, params object[] arguments]
        {
            get
            {
                bool? successful;
                LocalizedString localizedString;

                if (arguments != null && arguments.Length > 0)
                    localizedString = new(key, key.Translate(this.CultureChanged?.CultureInfo ?? Thread.CurrentThread.CurrentCulture, out successful, Array.ConvertAll(arguments, x => $"{x}")));
                else
                    localizedString = new(key, key.Translate(this.CultureChanged?.CultureInfo ?? Thread.CurrentThread.CurrentCulture, out successful));

                if (successful != null && successful == false)
                    this.LanguageCollector.Add(key);

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
    }
}