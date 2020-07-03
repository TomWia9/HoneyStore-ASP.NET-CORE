using System.Collections.Generic;

namespace HoneyStore.Models
{
    public class Client
    {
        public Client()
        {
            HoneysInTheCart = new List<HoneyItem>();
            Orders = new List<Order>();
        }
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public List<HoneyItem> HoneysInTheCart { get; set; }
        public List<Order> Orders { get; set; }

    }
}
