using MetaFrm.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;

namespace MetaFrm.Razor.Essentials
{
    /// <summary>
    /// AddMetaFrm
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// AddMetaFrm
        /// </summary>
        /// <param name="services"></param>
        /// <param name="baseAddress"></param>
        /// <param name="accessKey"></param>
        /// <param name="platform"></param>
        /// <returns></returns>
        public static IServiceCollection AddMetaFrm(this IServiceCollection services, string baseAddress, string accessKey, Maui.Devices.DevicePlatform platform)
        {
            services.AddFactory(baseAddress, accessKey, platform);
            services.AddMetaFrm();

            return services;
        }

        /// <summary>
        /// AddMetaFrm
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddMetaFrm(this IServiceCollection services)
        {
            //services.AddSingleton<     Factory>();
            services.AddSingleton<  Maui.ApplicationModel.IPermissions, Maui.ApplicationModel.DummyPermissions>();
            services.AddSingleton<  Maui.ApplicationModel.IBrowser, Maui.ApplicationModel.DummyBrowser>();
            services.AddScoped<     Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider, Auth.AuthenticationStateProvider>();
            services.AddSingleton<  Maui.Devices.IDeviceInfo, Maui.Devices.DummyDeviceInfo>();
            services.AddSingleton<  Maui.Devices.IDeviceToken, Maui.Devices.DummyDeviceToken>();
            services.AddSingleton<  Maui.Notification.ICloudMessaging, Maui.Notification.DummyCloudMessaging>();
            services.AddSingleton<  Maui.Ads.IAds, Ads.DummyAds>();
            services.AddSingleton<  Maui.Storage.IPreferences, Storage.DummyPreferences>();

            services.AddOptions();
            services.AddAuthorizationCore();

            services.AddScoped<     MetaFrm.Localization.ICultureChanged, MetaFrm.Localization.CultureChanger>();
            services.AddScoped<     MetaFrm.Localization.ILanguageCollector, MetaFrm.Localization.LanguageCollector>();
            services.AddScoped<     Microsoft.Extensions.Localization.IStringLocalizer, MetaFrm.Razor.Essentials.Localization.LocalizationManager>();

            services.AddSingleton<INotifyPropertyChanged, MetaFrm.ComponentModel.DummyNotifyPropertyChanged>();//Dummy Maui xaml

            if (!services.Any(x => x.ServiceType == typeof(Control.IActionEvent)))
                services.AddScoped<     Control.IActionEvent, Control.DummyActionEvent>();

            services.AddLocalization();

            return services;
        }
    }
}