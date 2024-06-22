namespace CarroOOP.NotificationContext
{
    public class Notifiable
    {
        public List<Notification> Notifications { get; set; }
        public Notifiable()
        {
            Notifications = new List<Notification>();
        }

        public void AddNotification(Notification notification)
        {
            Notifications.Add(notification);
        }

        public void AddNotifications(IList<Notification> notifications)
        {
            Notifications.AddRange(notifications);
        }
    }
}