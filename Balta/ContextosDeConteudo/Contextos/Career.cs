namespace ContextosDeConteudo.Contextos
{
    public class Career : Content
    {
        public IList<CareerItem> Items { get; set; }
        public int ItemsCount { get { return Items.Count; } }
        public Career() {
            Items = new List<CareerItem>();
        }
    }
}