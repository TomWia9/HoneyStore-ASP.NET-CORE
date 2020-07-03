using HoneyStore.Models;
using System;
using System.Collections.Generic;

namespace HoneyStore.Dto
{
    public class OrderDto
    {
        public OrderDto()
        {
            OrderedHoneys = new List<HoneyItemDto>();
          //  Date = DateTime.Now;
        }
        public int Id { get; set; }
        public int ClientId { get; set; }
       // public Client Client { get; set; }
        public List<HoneyItemDto> OrderedHoneys { get; set; }
        public decimal TotalPrice { get; set; }
        public Delivery Delivery { get; set; }
        public Payment Payment { get; set; }
        public Status Status { get; set; }
        public DateTime Date { get; set; }
    }
}
