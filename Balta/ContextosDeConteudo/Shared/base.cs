using ContextosDeConteudo.NotificationContext;

namespace ContextosDeConteudo.Shared
{
    public abstract class Base : Notifiable 
    {
        public Guid Id { get; set;}
        public Base() 
        {
            Id = Guid.NewGuid();
        }

    }
}