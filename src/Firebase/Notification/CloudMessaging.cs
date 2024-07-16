using MetaFrm.Maui.Notification;

namespace MetaFrm.Razor.Essentials.Firebase.Notification
{
    internal class CloudMessaging : ICloudMessaging
    {
        public event TokenChanged? TokenChangedEvent { add { } remove { } }
        public event NotificationReceived? NotificationReceivedEvent { add { } remove { } }
        public event NotificationTapped? NotificationTappedEvent { add { } remove { } }
        public event Error? ErrorEvent { add { } remove { } }
    }
}