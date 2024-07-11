namespace DataAccess.Models
{
    public class Career
    {
        public IList<CareerItem> Items { get; set; }
        public Career()
        {
            Items = new List<CareerItem>();
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}