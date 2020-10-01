using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoneyStore.Dto
{
    public class NewPasswordDto
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
