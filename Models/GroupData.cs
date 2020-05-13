using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace meldboek.Models
{
    public class GroupData
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public Person Creator { get; set; }
        public List<Person> Members { get; set; }
    }
}
