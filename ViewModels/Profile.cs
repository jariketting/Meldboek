
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using meldboek.Models;

namespace meldboek.ViewModels
{
    public class Profile
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public List<Person> Friends { get; set; }
    }
}