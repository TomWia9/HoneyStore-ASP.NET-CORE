using System.Collections.Generic;

namespace HoneyStore.Models
{
    public class Cart
    {
        public Cart()
        {
            Honeys = new List<HoneyItem>();
        }

        public int Id { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public List<HoneyItem> Honeys { get; set; }

    }
}
