using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace meldboek.Models
{
    public class Newspost
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Person Creator { get; set; }
        public string DateAdded { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Path { get;set; }
        public string Filename { get;set; }
    }
}
