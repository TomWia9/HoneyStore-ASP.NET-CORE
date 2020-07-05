using System.Collections.Generic;

namespace HoneyStore.Dto
{
    public class NumberOfOrdersDataDto
    {
        public IEnumerable<int> Data { get; set; }
        public IEnumerable<string> Labels { get; set; }
    }
}
