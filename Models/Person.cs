using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace meldboek.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        //constructor
        public Person(int PersonId, string firstName, string lastName, string email, string password)
        {
            PersonId = PersonId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }

        //lege constructor
        public Person()
        {
        }
    }

}