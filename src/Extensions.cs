using MetaFrm.Extensions;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddSingleton<Maui.ApplicationModel.IBrowser, ApplicationModel.Browser>();//*
            services.AddScoped<Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider, Auth.AuthenticationStateProvider>();//*
            services.AddSingleton<Maui.Devices.IDeviceInfo, Devices.DeviceInfo>();//DeviceInfo
            services.AddSingleton<Maui.Devices.IDeviceToken, Firebase.DeviceToken>();//DeviceToken
            services.AddSingleton<Maui.Notification.ICloudMessaging, Firebase.Notification.CloudMessaging>();//CloudMessaging
            services.AddSingleton<Maui.Ads.IAds, Ads.DummyAds>();
            services.AddScoped<Maui.Storage.IPreferences, Storage.DummyPreferences>();

            services.AddOptions();
            services.AddAuthorizationCore();

            services.AddScoped<MetaFrm.Localization.ICultureChanged, MetaFrm.Localization.DummyLocalizationManager>();
            services.AddScoped<Microsoft.Extensions.Localization.IStringLocalizer, Localization.LocalizationManager>();

            if (!services.Any(x => x.ServiceType == typeof(Control.IActionEvent)))
                services.AddSingleton<Control.IActionEvent, Control.DummyActionEvent>();

            services.AddLocalization();

            return services;
        }
    }
}