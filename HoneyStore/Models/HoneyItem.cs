
namespace HoneyStore.Models
{
    public class HoneyItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }

    }
}
