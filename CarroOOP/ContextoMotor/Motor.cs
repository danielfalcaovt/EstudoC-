using CarroOOP.Estrutura;
using CarroOOP.NotificationContext;

namespace CarroOOP.MotorContext
{
    public class Motor : Base
    {
        public int Valvulas { get; set; }
        public bool Ligado { get; set; }
        public void Acelerar()
        {
            if (Ligado)
            {
                Console.WriteLine("Acelerar");
            }
            else
            {
                AddNotification(new Notification("Motor", "Motor não pode executar a função enquanto desligado."));
            }
        }
        
        public void Ignicao()
        {
            Ligado = true;
        }
        public Motor(int valvulas)
        {
            Valvulas = valvulas;
        }
    }
}