using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniResearch.API.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateofBirth { get; set; }
        public UserType UserType { get; set; }
    }
}
