using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace meldboek.Models
{
    public class User
    {
        private String Username { get; set; } // Gebruikersnaam om mee in te loggen
        private String Password { get; set; } // Wachtwoord om in te loggen, deze wordt later gehashed
        private int UserId {get; set; }// Gebruikers Id voor de Database

        //constructor
        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        //lege constructor
        public User()
        {
            
        }




    }
}
