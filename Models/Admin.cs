using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace meldboek.Models
{
    public class Admin

    {
        private int AdminId { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string Email { get; set; }
        private string Password { get; set; }

        public Admin(int adminid, string firstname, string lastname, string email, string password)
        {
            AdminId = adminid;
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            Password = password;

        }
       

    }

}
