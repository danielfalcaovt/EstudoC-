using ContextosDeConteudo.Contextos;

namespace ContextosDeConteudo 
{
    class Program 
    {
        static void Main(string[] args)
        {
            var course = new Career();
            course.Items.Add(new CareerItem());
            Console.WriteLine(course.ItemsCount);
        }
    }
}