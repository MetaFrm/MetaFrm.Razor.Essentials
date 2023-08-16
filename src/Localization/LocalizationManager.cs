using Microsoft.Extensions.Localization;

namespace MetaFrm.Razor.Essentials.Localization
{
    /// <summary>
    /// LocalizationManager
    /// </summary>
    public class LocalizationManager : IStringLocalizer
    {
        /// <summary>
        /// Gets the string resource with the given name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public LocalizedString this[string name] => new(name, name.Translate());

        /// <summary>
        /// Gets the string resource with the given name and formatted with the supplied arguments.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public LocalizedString this[string name, params object[] arguments] => new(name, arguments is string[] args ? name.Translate(args) : string.Format(name, arguments));

        /// <summary>
        /// Gets all string resources.
        /// </summary>
        /// <param name="includeParentCultures"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            throw new System.NotImplementedException();
        }
    }
}
