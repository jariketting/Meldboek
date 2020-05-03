using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using meldboek.Models;
using Microsoft.AspNetCore.Mvc;
using Neo4j.Driver;

namespace meldboek.Controllers
{
    public class ChatController : Controller
    {
        /// <summary>
        /// Overview page, join and get into chats.
        /// </summary>
        /// <returns>Index page</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Get chat user van join
        /// </summary>
        /// <returns></returns>
        public List<Chat> getChatJoinable()
        {
            List<INode> chatNodes = new List<INode>();
            var getPosts = ConnectDb("MATCH(g: Group)--(p: Post) WHERE g.name = 'rdam' RETURN p");
            var post = new Newspost();
            List<Newspost> postList = new List<Newspost>();
        }
    }
}