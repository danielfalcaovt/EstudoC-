namespace ContextosDeConteudo.Contextos
{
    public abstract class Content 
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Content() {
            Id = Guid.NewGuid();
        }
    }
}