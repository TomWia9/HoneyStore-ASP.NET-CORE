namespace HoneyStore.Models
{
    public class HoneyItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }
    }
}
