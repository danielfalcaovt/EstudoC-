using CarroOOP.DirecaoContext;
using CarroOOP.Estrutura;
using CarroOOP.MotorContext;
using CarroOOP.TanqueContext;

namespace CarroOOP 
{
    class Program
    {
        static void Main(string[] args)
        {
            var carro = new Carro();
            carro.Tanque.EncherTanque(80);
            carro.Direcao.Dirigir();
            carro.Direcao.LigarCarro();
        }

        public class Carro : Base
        {
            public Tanque Tanque { get; set; }
            public Motor Motor { get; set; }
            public Direcao Direcao { get; set; }
            public Carro()
            {
                Tanque = new Tanque();
                Motor = new Motor(4);
                Direcao = new Direcao(Motor, Tanque);
            }
        }
    }
}