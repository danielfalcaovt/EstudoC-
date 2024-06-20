using ContextosDeConteudo.Contextos.Enums;

namespace ContextosDeConteudo.Contextos
{
    public class Module
    {
        public int Order { get; set; }
        public string Title { get; set; }
        public IList<Lecture> Lectures;
        public EContentLevel Level { get; set; }

        public Module()
        {
            Lectures = new List<Lecture>();
        }
    }
}