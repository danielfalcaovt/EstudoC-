using CarroOOP.Estrutura;

namespace CarroOOP.TanqueContext
{
    public class Tanque : Base
    {
        public int Gasolina { get; set; }

        public void EncherTanque(int porcentoGasolina)
        {
            if ((Gasolina + porcentoGasolina) > 100)
            {
                Gasolina = 100;
            }
            else
            {
                Gasolina += porcentoGasolina;
            }
        }
    }
}