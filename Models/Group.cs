using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace meldboek.Models
{
    public class Group
    {

        public int GroupId { get; set; }
        //Primarykey
        public string GroupName { get; set; }

        //controller
        public Group(string groupName)
        {

            GroupName = groupName;
        }
        //lege controller
        public Group()
        {

        }

    }
}