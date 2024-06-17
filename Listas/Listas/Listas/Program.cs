using System.Globalization;
using RestSharp;

namespace Listas
{
    class Program
    {
        static void Main(string[] args)
        {

            var payments = new List<Payment>();
            payments.Add(new Payment(1, "Monitoro", "98"));
            payments.Add(new Payment(2, "Cinderelo", "100"));
            payments.Add(new Payment(3, "Marmito", "500"));
            payments.Add(new Payment(4, "Esponjo", "321"));
            payments.Add(new Payment(5, "Pericles", "10"));
            foreach (var payment in payments)
            {
                Console.Write(payment.Id);
                Console.Write($"\t{payment.Valor}\t");
                Console.Write(payment.Name);
                Console.Write("\n");
            }
            var found = payments.Where(pay => pay.Id == 3);
            foreach (var fPayments in found)
            {
                Console.WriteLine(fPayments.Id);
            }
        }
    }

    public class Payment
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Valor { get; set; } 

        public Payment(int id, string name, string valor)
        {
            Id = id;
            Name = name;
            Valor = $"R${valor}";
        }
    }
}