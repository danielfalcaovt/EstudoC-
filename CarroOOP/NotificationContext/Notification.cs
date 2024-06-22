namespace CarroOOP.NotificationContext
{
    public class Notification
    {
        public string Root { get; set; }
        public string Message { get; set; }
        public Notification(string root, string message)
        {
            Root = root;
            Message = message;
        }
    }
}