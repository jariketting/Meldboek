using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace meldboek.Models
{
    public class ForumItem
    {
        public int ForumItemId { get; set; }

        public Person Owner { get; set; } 
        public String Content { get; set; }

        public Forum ReplyOnForum { get; set; }

        public ForumItem ReplyOnForumItem { get; set; }

        

        //constructor voor 1ste reply
        public ForumItem(int forumItemId, Person owner, string content, Forum replyOnForum)
        {
            ForumItemId = forumItemId;
            Owner = owner;
            Content = content;
            ReplyOnForum = replyOnForum;

        }
        
        //constructor voor reply op reply
        public ForumItem(int forumItemId, Person owner, string content, ForumItem replyOnForumItem)
        {
            ForumItemId = forumItemId;
            Owner = owner;
            Content = content;
            ReplyOnForumItem = replyOnForumItem;
        }
        //lege constructor
        public ForumItem()
        {
        }
    }
}