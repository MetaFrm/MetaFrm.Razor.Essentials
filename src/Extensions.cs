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
        /// <returns></returns>
        public static IServiceCollection AddMetaFrm(this IServiceCollection services)
        {
            services.AddSingleton<Maui.ApplicationModel.IBrowser, ApplicationModel.Browser>();//*
            services.AddScoped<Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider, Auth.AuthenticationStateProvider>();//*
            services.AddSingleton<Maui.Devices.IDeviceInfo, Devices.DeviceInfo>();//DeviceInfo
            services.AddSingleton<Maui.Devices.IDeviceToken, Firebase.DeviceToken>();//DeviceToken
            services.AddSingleton<Maui.Notification.ICloudMessaging, Firebase.Notification.CloudMessaging>();//CloudMessaging

            services.AddOptions();
            services.AddAuthorizationCore();

            services.AddScoped<MetaFrm.Localization.ICultureChanged, Localization.LocalizationManager>();
            services.AddScoped<Microsoft.Extensions.Localization.IStringLocalizer, Localization.LocalizationManager>();

            services.AddLocalization();

            return services;
        }
    }
}