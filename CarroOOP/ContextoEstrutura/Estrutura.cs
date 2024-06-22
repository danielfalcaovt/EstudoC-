using CarroOOP.DirecaoContext;
using CarroOOP.MotorContext;
using CarroOOP.TanqueContext;

namespace CarroOOP.Estrutura
{
    public class Estrutura : Base
    {
        public string Modelo { get; set; }
        public string Color { get; set; }
        public Motor Motor { get; set; }
        public Tanque Tanque { get; set; }
        public Direcao Direcao { get; set; }
    }
}