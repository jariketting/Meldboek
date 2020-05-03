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
        public IActionResult Index(string type, string chat)
        {
            ViewBag.success = null; // store success msg

            // check if post is made
            if (type != null & chat != null)
            {
                // check join of open chat
                if (type == "join")
                {
                    JoinChat(chat); // join chat
                    Chat room = GetChat(chat);
                    ViewBag.success = "Je bent toegevoegd aan " + room.Name; // TODO add chat name
                }
                else if (type == "open")
                {
                    return RedirectToAction("Room", new { chat });
                }
            }

            // get joinable chats and add to viewbag
            List<Chat> joinable = GetChatsJoinable();
            ViewBag.chatsJoinable = joinable;

            // get joined chats and add to viewbag
            List<Chat> joined = GetChatsJoined();
            ViewBag.chatsJoined = joined;

            return View(ViewBag);
        }

        /// <summary>
        /// Chat room
        /// </summary>
        /// <param name="chat">id of chatroom</param>
        /// <returns>Chatroom view</returns>
        public IActionResult Room(string chat, string message)
        {
            // TODO validate user in room

            // check if chat id given
            if (chat == null)
            {
                return RedirectToAction("Index");
            }

            // get chatroom and add to viewbag
            Chat room = GetChat(chat);
            ViewBag.room = room;

            // check if new message added
            if(message != null)
            {
                SendMessage(message, chat);
            }

            List<Message> messages = GetChatMessages(chat);
            ViewBag.messages = messages;

            return View();
        }

        /// <summary>
        /// Join chat by id
        /// </summary>
        /// <param name="chat">id of chat to join</param>
        public async void JoinChat(string chat)
        {
            // TODO replace by current logged in user
            _ = await Db.ConnectDb("MATCH (u:User),(c:Chat) WHERE u.Email = 'jariketting@hotmail.com' AND c.ChatId = '" + chat + "' CREATE(u)-[r:InChat]->(c)");
        }

        /// <summary>
        /// Get chat by id
        /// </summary>
        /// <returns>Chat found</returns>
        public Chat GetChat(string ChatId)
        {
            List<INode> chatNodes = new List<INode>(); // will store chat nodes
            var getChats = Db.ConnectDb("MATCH (p:Chat) WHERE p.ChatId = '" + ChatId + "' RETURN p LIMIT 1"); // run query
            var chat = new Chat(); // store chat

            chatNodes = getChats.Result; // fill chat nodes with queries result

            var item = chatNodes.First();

            // pull data from item and convert json
            var nodeprops = JsonConvert.SerializeObject(item.As<INode>().Properties);
            chat = (JsonConvert.DeserializeObject<Chat>(nodeprops));

            // fill list with chats
            return new Chat()
            {
                ChatId = chat.ChatId,
                Name = chat.Name,
                Description = chat.Description
            };
        }

        /// <summary>
        /// Send message
        /// </summary>
        /// <param name="message">Message to send</param>
        /// <param name="chat">Id of chat</param>
        public async void SendMessage(string message, string chat)
        {
            Random rnd = new Random();
            int id = rnd.Next(1, 9999999);

            string Date = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");

            _ = await Db.ConnectDb("CREATE (p:Message { MessageId: '" + id + "', Content: '" + message + "', DatetimeSend: '" + Date + "', DatetimeRead: ''}) RETURN p");
            _ = await Db.ConnectDb("MATCH (u:User),(p:Message) WHERE u.Email = 'jariketting@hotmail.com' AND p.MessageId = '" + id + "' CREATE(u)-[r:Sends]->(p)");
            _ = await Db.ConnectDb("MATCH (u:Message),(p:Chat) WHERE u.MessageId = '" + id + "' AND p.ChatId = '" + chat + "' CREATE(p)-[r:Contains]->(u)");
        }

        /// <summary>
        /// Get chat user van join
        /// </summary>
        /// <returns></returns>
        public List<Message> GetChatMessages(string chat)
        {
            List<INode> messageNodes = new List<INode>(); // will store Message nodes
            var getMessages = Db.ConnectDb("MATCH (n:Chat{ChatId:'" + chat + "'})-[:Contains]->(m:Message) RETURN m"); // run query
            var message = new Message(); // store Message
            List<Message> messageList = new List<Message>(); // store list of all messages

            messageNodes = getMessages.Result; // fill chat nodes with queries result
            // go trough all items
            foreach (var item in messageNodes)
            {
                // pull data from item and convert json
                var nodeprops = JsonConvert.SerializeObject(item.As<INode>().Properties);
                message = (JsonConvert.DeserializeObject<Message>(nodeprops));

                // Another query gets the related users to a post from the database thus finding its creator, the result is processed similarly.
                List<INode> userList = new List<INode>();
                var getuser = Db.ConnectDb("MATCH(u:User)-[:Sends]-(c:Message) WHERE c.MessageId = '" + message.MessageId + "' RETURN u LIMIT 1");
                var user = new User();

                userList = getuser.Result;
                var userItem = userList.First();

                var userprops = JsonConvert.SerializeObject(userItem.As<INode>().Properties);
                user = (JsonConvert.DeserializeObject<User>(userprops));

                // TODO as all these params should match, this could be automated...
                // fill list with chats
                messageList.Add(new Message()
                {
                    MessageId = message.MessageId,
                    Content = message.Content,
                    DatetimeSend = message.DatetimeSend,
                    DatetimeRead = message.DatetimeRead,
                    Username = user.Email
                });
            }

            // order by time send
            List<Message> messages = messageList.OrderByDescending(p => p.DatetimeSend).ToList();

            return messages; // return results
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