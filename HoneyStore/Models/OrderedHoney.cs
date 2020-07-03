namespace HoneyStore.Models
{
    public class OrderedHoney
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
