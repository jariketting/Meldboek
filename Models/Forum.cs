using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace meldboek.Models
{
    public class Forum
    {
        public int ForumId { get; set; }

        public Person Owner { get; set; }
        public String Title { get; set; }

        public String Content { get; set; }

        public DateTime lastEdit { get; set; }

        //Aparte Varibale
        public int AantalReacties { get; set; }

        public Forum(int forumId, Person owner, string title, string content)
        {
            ForumId = forumId;
            Owner = owner;
            Title = title;
            Content = content;
        }
        public Forum(int forumId, Person owner, string title, string content, DateTime LastEdit)
        {
            ForumId = forumId;
            Owner = owner;
            Title = title;
            Content = content;
            lastEdit = LastEdit;
        }

        //lege constructor
        public Forum()
        {
        }
    }
}