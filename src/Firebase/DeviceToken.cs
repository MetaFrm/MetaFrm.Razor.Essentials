using MetaFrm.Maui.Devices;

namespace MetaFrm.Razor.Essentials.Firebase
{
    internal class DeviceToken : IDeviceToken
    {
        public Task<string> GetToken()
        {
            return Task.FromResult(string.Empty);
        }
    }
}