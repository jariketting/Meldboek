using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace meldboek.Models
{
    public class Group
    {
        //Primarykey
        public string GroupName { get; set; }

        public Group(string groupName)
        {

            GroupName = groupName;
        }
        public Group()
        {

        }
    }
}