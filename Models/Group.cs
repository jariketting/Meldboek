using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace meldboek.Models
{
    public class Group
    {
<<<<<<< HEAD
        //Primarykey
        public string GroupName { get; set; }

        public Group(string groupName)
        {

            GroupName = groupName;
        }
        public Group()
        {

        }
=======
        public int GroupId { get; set; }
        public string GroupName { get; set; }

>>>>>>> origin/chat
    }
}