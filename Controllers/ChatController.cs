using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using meldboek.Models;
using Microsoft.AspNetCore.Mvc;
using Neo4j.Driver;
using Newtonsoft.Json;

namespace meldboek.Controllers
{
    public class ChatController : Controller
    {
        Database Db { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public ChatController()
        {
            Db = new Database(); // init database
        }

        /// <summary>
        /// Overview page, join and get into chats.
        /// </summary>
        /// <returns>Index page</returns>
        public IActionResult Index(string type, int chat)
        {
            ViewBag.success = null; // store success msg

            // check if post is made
            if (type != null & chat > 0)
            {
                // check join of open chat
                if (type == "join")
                {
                    JoinChat(chat); // join chat
                    ViewBag.success = "Je bent toegevoegd aan chat " + chat; // TODO add chat name
                }
                else if (type == "open")
                {
                    // TODO redirect to chat
                }
            }

            List<Chat> joinable = GetChatsJoinable();
            ViewBag.chatsJoinable = joinable;

            List<Chat> joined = GetChatsJoined();
            ViewBag.chatsJoined = joined;

            return View(ViewBag);
        }

        public void JoinChat(int chat)
        {
            // TODO replace by current logged in user
            var Join = Db.ConnectDb("MATCH (u:User),(c:Chat) WHERE u.Email = 'jariketting@hotmail.com' AND c.ChatId = '" + chat + "' CREATE(u)-[r:InChat]->(c)");
        }

        /// <summary>
        /// Get chat user van join
        /// </summary>
        /// <returns></returns>
        public List<Chat> GetChatsJoinable()
        {
            List<INode> chatNodes = new List<INode>(); // will store chat nodes
            var getChats = Db.ConnectDb("MATCH (p:Chat) WHERE NOT(p) -[:InChat]-(: User{ Email: 'jariketting@hotmail.com'}) RETURN p"); // run query
            var chat = new Chat(); // store chat
            List<Chat> chatList = new List<Chat>(); // store list of al chats

            chatNodes = getChats.Result; // fill chat nodes with queries result
            // go trough all items
            foreach(var item in chatNodes)
            {
                // pull data from item and convert json
                var nodeprops = JsonConvert.SerializeObject(item.As<INode>().Properties); 
                chat = (JsonConvert.DeserializeObject<Chat>(nodeprops));

                // TODO as all these params should match, this could be automated...
                // fill list with chats
                chatList.Add(new Chat(){
                    ChatId = chat.ChatId,
                    Name = chat.Name,
                    Description = chat.Description
                });
            }

            return chatList; // return results
        }

        /// <summary>
        /// Get chat user has joined
        /// </summary>
        /// <returns></returns>
        public List<Chat> GetChatsJoined()
        {
            List<INode> chatNodes = new List<INode>(); // will store chat nodes
            var getChats = Db.ConnectDb("MATCH (p:Chat) WHERE(p) -[:InChat]-(: User{ Email: 'jariketting@hotmail.com'}) RETURN p"); // run query
            var chat = new Chat(); // store chat
            List<Chat> chatList = new List<Chat>(); // store list of al chats

            chatNodes = getChats.Result; // fill chat nodes with queries result
            // go trough all items
            foreach (var item in chatNodes)
            {
                // pull data from item and convert json
                var nodeprops = JsonConvert.SerializeObject(item.As<INode>().Properties);
                chat = (JsonConvert.DeserializeObject<Chat>(nodeprops));

                // TODO as all these params should match, this could be automated...
                // fill list with chats
                chatList.Add(new Chat()
                {
                    ChatId = chat.ChatId,
                    Name = chat.Name,
                    Description = chat.Description
                });
            }

            return chatList; // return results
        }
    }
}