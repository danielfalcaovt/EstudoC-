using CarroOOP.Estrutura;
using CarroOOP.MotorContext;
using CarroOOP.NotificationContext;
using CarroOOP.TanqueContext;

namespace CarroOOP.DirecaoContext
{
    public class Direcao : Base
    {
        public Motor Motor { get; set; }
        public Tanque Tanque { get; set; }

        public Direcao(Motor motor, Tanque tanque)
        {
            Motor = motor;
            Tanque = tanque;
        }
        public void LigarCarro()
        {
            if (Tanque.Gasolina > 0)
            {
                Console.WriteLine("Ligando carro...");
                Motor.Ignicao();
            }
            else
            {
                AddNotification(new Notification("Tanque", "Tanque vazio"));
            }
        }
        public void Dirigir()
        {
            if (Motor.Ligado)
            {
                Console.WriteLine("Dirigindo...");
            }
            else
            {
                AddNotification(new Notification("Motor", "Ligue o motor antes de dirigir."));
            }
        }
    }
}