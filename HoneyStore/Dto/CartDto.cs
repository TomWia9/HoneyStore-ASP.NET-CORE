using System.Collections.Generic;

namespace HoneyStore.Dto
{
    public class CartDto
    {
        public CartDto()
        {
            Honeys = new List<HoneyItemDto>();
        }

        public List<HoneyItemDto> Honeys { get; set; }
    }
}
