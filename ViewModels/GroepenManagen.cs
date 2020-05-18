using meldboek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace meldboek.ViewModels
{
    public class GroepenManagen
    {
        public GroupData Group { get; set; }
        public List<Person> NonMembers { get; set; }
    }
}
