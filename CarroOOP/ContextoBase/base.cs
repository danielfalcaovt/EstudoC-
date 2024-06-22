using CarroOOP.NotificationContext;

namespace CarroOOP.Estrutura
{
    public class Base : Notifiable
    {
        public Guid Id { get; set; }

        public Base()
        {
            Id = Guid.NewGuid();
        }
    }
}