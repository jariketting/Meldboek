using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace meldboek.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DisplayName("Uw email")]
        [Required(ErrorMessage = "Deze veld is verplicht")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Deze veld is verplicht")]
        [DisplayName("Uw wachtwoord")]
        public string Password { get; set; }
        public string LoginErrorMessage { get; set; }


        //constructor
        public Person(int personId, string firstName, string lastName, string email, string password)
        {
            PersonId = personId;
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