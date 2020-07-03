using System.Collections.Generic;

namespace HoneyStore.Dto
{
    public class CartDto
    {
        public CartDto()
        {
            Honeys = new List<HoneyInTheCartDto>();
        }

        public List<HoneyInTheCartDto> Honeys { get; set; }
    }
}
