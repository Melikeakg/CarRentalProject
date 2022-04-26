using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.DTOs
{
    //Bu class'ları dto olarak tutuyoruz, nedeni join atmak isteyebiliriz.
    public class UserForRegisterDto:IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
