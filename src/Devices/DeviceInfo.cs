namespace MetaFrm.Razor.Essentials.Devices
{
    internal class DeviceInfo : Maui.Devices.IDeviceInfo
    {
        public string? Model { get; set; }
        public string? Manufacturer { get; set; }
        public string? Name { get; set; }
        public string? VersionString { get; set; }
        public Version? Version { get; set; }
        public Maui.Devices.DevicePlatform Platform { get; set; }
        public Maui.Devices.DeviceIdiom Idiom { get; set; }
        public Maui.Devices.DeviceType DeviceType { get; set; }
    }
}