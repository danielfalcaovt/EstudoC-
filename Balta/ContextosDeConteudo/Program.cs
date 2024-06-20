using ContextosDeConteudo.Contextos;

namespace ContextosDeConteudo 
{
    class Program 
    {
        static void Main(string[] args)
        {
            var articles = new List<Article>();
            articles.Add(new Article("C-SHARP", "TUDO SOBRE C-SHARP"));
            articles.Add(new Article("JAVASCRIPT", "TUDO SOBRE JAVASCRIPT"));
            articles.Add(new Article("TYPESCRIPT", "TUDO SOBRE TYPESCRIPT"));

    /*         foreach (var article in articles)
            {
                Console.WriteLine(article.Id);
                Console.WriteLine(article.Title);
                Console.WriteLine(article.Url);
            } */

            var courses = new List<Course>();
            var courseFun = new Course("Fundamental", "fundamentos-oop");
            var courseInt = new Course("Intermediate", "fundamentos-int");
            var courseAdv = new Course("Advanced", "fundamentos-adv");

            courses.Add(courseFun);
            courses.Add(courseInt);
            courses.Add(courseAdv);

            var career = new Career(".NET", "dot-net");
            var careerItem = new CareerItem(1, "Aprenda C#", "", null);
            var careerItem2 = new CareerItem(2, "Aprenda JS", "", null);
            var careerItem3 = new CareerItem(3, "Aprenda TS", "", null);
 
            career.Items.Add(careerItem);
            career.Items.Add(careerItem2);
            career.Items.Add(careerItem3);
            career.Items.OrderBy(x=>x.Order);
            foreach (var item in career.Items)
            {                                        
                Console.WriteLine(item.Order);
                Console.WriteLine(item.Title);
            }
        }
    }
}