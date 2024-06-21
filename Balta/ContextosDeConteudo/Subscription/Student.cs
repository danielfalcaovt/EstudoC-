using ContextosDeConteudo.Contextos;
using ContextosDeConteudo.NotificationContext;

namespace ContextosDeConteudo.Subscription
{
    public class Student : Base
    {
        public IList<Subscription> Subscriptions { get; set; }
        public bool IsPremium => Subscriptions.Any(x=> !x.IsInactive);
        public User user { get; set; }
        public Student()
        {
            Subscriptions = new List<Subscription>();
        }

        public void AddSubscription(Subscription subscription) 
        {
            if (IsPremium)
            {
                AddNotification(new Notification("Premium", "Already Premium"));
                return;
            }
                Subscriptions.Add(subscription);
        }
        
    }
}