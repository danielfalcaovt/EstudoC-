using ContextosDeConteudo.Contextos.Enums;

namespace ContextosDeConteudo.Contextos
{
    public class Lecture
    {
        public Lecture(int ordem, string title, int durationInMinutes, EContentLevel level)
        {
            Ordem = ordem;
            Title = title;
            DurationInMinutes = durationInMinutes;
            Level = level;
        }

        public int Ordem { get; set; }
        public string Title { get; set; }
        public int DurationInMinutes { get; set; }
        public EContentLevel Level { get; set; }
    }
}