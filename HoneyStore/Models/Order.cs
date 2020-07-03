using System;
using System.Collections.Generic;

namespace HoneyStore.Models
{
    public class Order
    {
        public Order()
        {
            OrderedHoneys = new List<OrderedHoney>();
        }

        public int Id { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public List<OrderedHoney> OrderedHoneys { get; set; }
        public decimal TotalPrice { get; set; }
        public Delivery Delivery { get; set; }
        public Payment Payment { get; set; }
        public DateTime Date { get; set; }
    }
}
