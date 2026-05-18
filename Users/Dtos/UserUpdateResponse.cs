using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FotoFlow.Users.Dtos
{
    public class UserUpdateResponse
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Age { get; set; }
        public string Password { get; set; }
    }
}
