namespace TiposGenericos
{
    public class Program
    {
        static void Main(string[] args)
        {
            Person user = new Person();
            Subscription sub = new Subscription();
            Payment payMethod = new Payment();
            var payContext = new PaymentContext<Person, Payment, Subscription>();
            Person persona = payContext.Save(user);
        }
    }

    public class PaymentContext<PE, PA, SU>
        where PE : Person
        where PA : Payment
        where SU : Subscription
    {
       public PE Save(PE person)
        {
            return person;
        }

        public PA Save(PA paymentMethod)
        {
            return paymentMethod;
        }

        public SU Save(SU subscription)
        {
            return subscription;
        }
    }

    public class Person
    {

    }

    public class Payment
    {

    }

    public class Subscription
    {

    }
}