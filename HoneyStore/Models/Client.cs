﻿using System.Collections.Generic;

namespace HoneyStore.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public List<HoneyItem> HoneysInTheCart { get; set; }

    }
}
