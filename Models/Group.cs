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

        //constructor
        public Group(int groupId, string groupName)
        {
            GroupId = groupId;
            GroupName = groupName;
        }
        //lege constructor
        public Group()
        {

        }

    }
}