using ContextosDeConteudo.Contextos.Enums;

namespace ContextosDeConteudo.Contextos
{
    public class Course : Content
    {
        public string Tag { get; set; }
        public IList<Module> Modules;
        public EContentLevel Level { get; set; }

        public Course() 
        {
            Modules = new List<Module>();
        }

    }
}