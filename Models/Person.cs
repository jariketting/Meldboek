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
        public int PersonId { get; set; } //Id of user (Person)
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DisplayName("Uw email")] // It displays a text instead of the string name
        [Required(ErrorMessage = "Deze veld is verplicht")] // Shows error when field is empty after submit.
        public string Email { get; set; }
        [DataType(DataType.Password)] // It hides password characters from screen 
        [Required(ErrorMessage = "Deze veld is verplicht")] // Shows error when field is empty after submit.
        [DisplayName("Uw wachtwoord")] // It displays a text instead of the string name
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