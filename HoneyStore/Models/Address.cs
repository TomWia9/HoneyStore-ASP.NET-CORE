namespace HoneyStore.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string StreetAndHouseNumber { get; set; }
        public string PostCode { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
