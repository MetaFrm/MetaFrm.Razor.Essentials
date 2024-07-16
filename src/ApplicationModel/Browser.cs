using MetaFrm.Maui.ApplicationModel;

namespace MetaFrm.Razor.Essentials.ApplicationModel
{
    /// <summary>
    /// Provides a way to display a web page inside an app.
    /// </summary>
    public class Browser : IBrowser
    {
        /// <summary>
        /// Open the browser to specified uri.
        /// </summary>
        /// <param name="uri">Uri to launch.</param>
        /// <returns>Completed task when browser is launched, but not necessarily closed. Result indicates if launching was successful or not.</returns>
        public Task<bool> OpenAsync(string uri) => Task.FromResult(false);

        /// <summary>
        /// Open the browser to specified uri.
        /// </summary>
        /// <param name="uri">Uri to launch.</param>
        /// <param name="launchMode">How to launch the browser.</param>
        /// <returns>Completed task when browser is launched, but not necessarily closed. Result indicates if launching was successful or not.</returns>
        public Task<bool> OpenAsync(string uri, BrowserLaunchMode launchMode) => Task.FromResult(false);

        /// <summary>
        /// Open the browser to specified uri.
        /// </summary>
        /// <param name="uri">Uri to launch.</param>
        /// <param name="options">Launch options for the browser.</param>
        /// <returns>Completed task when browser is launched, but not necessarily closed. Result indicates if launching was successful or not.</returns>
        public Task<bool> OpenAsync(string uri, BrowserLaunchOptions options) => Task.FromResult(false);

        /// <summary>
        /// Open the browser to specified uri.
        /// </summary>
        /// <param name="uri">Uri to launch.</param>
        /// <returns>Completed task when browser is launched, but not necessarily closed. Result indicates if launching was successful or not.</returns>
        public Task<bool> OpenAsync(Uri uri) => Task.FromResult(false);

        /// <summary>
        /// Open the browser to specified uri.
        /// </summary>
        /// <param name="uri">Uri to launch.</param>
        /// <param name="launchMode">How to launch the browser.</param>
        /// <returns>Completed task when browser is launched, but not necessarily closed. Result indicates if launching was successful or not.</returns>
        public Task<bool> OpenAsync(Uri uri, BrowserLaunchMode launchMode) => Task.FromResult(false);

        /// <summary>
        /// Open the browser to specified uri.
        /// </summary>
        /// <param name="uri">Uri to launch.</param>
        /// <param name="options">Launch options for the browser.</param>
        /// <returns>Completed task when browser is launched, but not necessarily closed. Result indicates if launching was successful or not.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> OpenAsync(Uri uri, BrowserLaunchOptions options) => Task.FromResult(false);
    }
}