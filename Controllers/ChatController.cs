using System;
using System.Collections.Generic;
using System.Linq;
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
                    return RedirectToAction("Room", new { chat, type });
                }
                else if (type == "chat")
                {
                    return RedirectToAction("Room", new { chat, type });
                }
            }

            // get joinable chats and add to viewbag
            List<Chat> joinable = GetChatsJoinable();
            ViewBag.chatsJoinable = joinable;

            // get joined chats and add to viewbag
            List<Chat> joined = GetChatsJoined();
            ViewBag.chatsJoined = joined;

            // get friends and add to viewbag
            List<Person> friends = GetFriends();
            ViewBag.friends = friends;

            return View(ViewBag);
        }

        /// <summary>
        /// Chat room
        /// </summary>
        /// <param name="chat">id of chatroom</param>
        /// <returns>Chatroom view</returns>
        public IActionResult Room(string chat, string type, string message)
        {
            // check if chat id given
            if (chat == null || type == null)
            {
                return RedirectToAction("Index");
            }

            if(type == "open") 
            { 
                // get chatroom and add to viewbag
                Chat room = GetChat(chat);
                ViewBag.name = room.Name;
            }
            else if(type == "chat")
            {
                Person friend = GetFriend(chat);
                ViewBag.name = friend.FirstName + " " + friend.LastName;
            }

            // check if new message added
            if (message != null)
            {
                SendMessage(message, chat, type);
                System.Threading.Thread.Sleep(500);
            }

            List<Message> messages = GetChatMessages(chat, type);
            ViewBag.messages = messages;

            return View();
        }

        /// <summary>
        /// Join chat by id
        /// </summary>
        /// <param name="chat">id of chat to join</param>
        public async void JoinChat(string chat)
        {
            // TODO replace by current logged in Person
            _ = await Db.ConnectDb("MATCH (u:Person),(c:Chat) WHERE u.PersonId = 1 AND c.ChatId = '" + chat + "' CREATE(u)-[r:InChat]->(c)");
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
        public async void SendMessage(string message, string chat, string type)
        {
            string Date = DateTime.Now.ToString("MM-dd-yyyy HH:mm:ss");

            string id = Db.GenerateUniqueId(Date + message.Substring(Math.Max(0, message.Length - 5)));

            _ = await Db.ConnectDb("CREATE (p:Message { MessageId: '" + id + "', Content: '" + message + "', DatetimeSend: '" + Date + "', DatetimeRead: ''}) RETURN p");
            _ = await Db.ConnectDb("MATCH (u:Person),(p:Message) WHERE u.PersonId = 1 AND p.MessageId = '" + id + "' CREATE(u)-[r:Sends]->(p)");

            if(type == "open")
            {
                _ = await Db.ConnectDb("MATCH (u:Message),(p:Chat) WHERE u.MessageId = '" + id + "' AND p.ChatId = '" + chat + "' CREATE(p)-[r:Contains]->(u)");
            } 
            else if(type == "chat")
            {
                _ = await Db.ConnectDb("MATCH (u:Message),(p:Person) WHERE u.MessageId = '" + id + "' AND p.Email = '" + chat + "' CREATE(p)-[r:Receives]->(u)");
            }

            System.Threading.Thread.Sleep(500);
        }

        /// <summary>
        /// Get chat user van join
        /// </summary>
        /// <returns></returns>
        public List<Message> GetChatMessages(string chat, string type)
        {
            List<INode> messageNodes = new List<INode>(); // will store Message nodes
            var message = new Message(); // store Message
            List<Message> messageList = new List<Message>(); // store list of all messages

            if (type == "open")
            {
                var getMessages = Db.ConnectDb("MATCH (n:Chat{ChatId:'" + chat + "'})-[:Contains]->(m:Message) RETURN m"); // run query

                messageNodes = getMessages.Result; // fill chat nodes with queries result
                // go trough all items
                foreach (var item in messageNodes)
                {
                    // pull data from item and convert json
                    var nodeprops = JsonConvert.SerializeObject(item.As<INode>().Properties);
                    message = (JsonConvert.DeserializeObject<Message>(nodeprops));

                    // Another query gets the related Persons to a post from the database thus finding its creator, the result is processed similarly.
                    List<INode> PersonList = new List<INode>();
                    var getPerson = Db.ConnectDb("MATCH(u:Person)-[:Sends]-(c:Message) WHERE c.MessageId = '" + message.MessageId + "' RETURN u LIMIT 1");
                    var Person = new Person();

                    PersonList = getPerson.Result;
                    var PersonItem = PersonList.First();

                    var Personprops = JsonConvert.SerializeObject(PersonItem.As<INode>().Properties);
                    Person = (JsonConvert.DeserializeObject<Person>(Personprops));

                    // TODO as all these params should match, this could be automated...
                    // fill list with chats
                    messageList.Add(new Message()
                    {
                        MessageId = message.MessageId,
                        Content = message.Content,
                        DatetimeSend = message.DatetimeSend,
                        DatetimeRead = message.DatetimeRead,
                        Personname = Person.Email
                    });
                }
            }
            else if(type == "chat")
            {
                var getMessages = Db.ConnectDb("MATCH (n:Person{PersonId: 1})-[:Sends]->(m:Message)<-[:Receives]-(P:Person{Email:'"+ chat +"'}) RETURN m"); // run query

                messageNodes = getMessages.Result; // fill chat nodes with queries result

                // go trough all items
                foreach (var item in messageNodes)
                {
                    // pull data from item and convert json
                    var nodeprops = JsonConvert.SerializeObject(item.As<INode>().Properties);
                    message = (JsonConvert.DeserializeObject<Message>(nodeprops));

                    // Another query gets the related Persons to a post from the database thus finding its creator, the result is processed similarly.
                    List<INode> PersonList = new List<INode>();
                    var getPerson = Db.ConnectDb("MATCH(u:Person)-[:Sends]-(c:Message) WHERE c.MessageId = '" + message.MessageId + "' RETURN u LIMIT 1");
                    var Person = new Person();

                    PersonList = getPerson.Result;
                    var PersonItem = PersonList.First();

                    var Personprops = JsonConvert.SerializeObject(PersonItem.As<INode>().Properties);
                    Person = (JsonConvert.DeserializeObject<Person>(Personprops));

                    // TODO as all these params should match, this could be automated...
                    // fill list with chats
                    messageList.Add(new Message()
                    {
                        MessageId = message.MessageId,
                        Content = message.Content,
                        DatetimeSend = message.DatetimeSend,
                        DatetimeRead = message.DatetimeRead,
                        Personname = Person.Email
                    });
                }

                getMessages = Db.ConnectDb("MATCH (n:Person{PersonId: 1})-[:Receives]->(m:Message)<-[:Sends]-(P:Person{Email:'" + chat + "'}) RETURN m"); // run query

                messageNodes = getMessages.Result; // fill chat nodes with queries result
                // go trough all items
                foreach (var item in messageNodes)
                {
                    // pull data from item and convert json
                    var nodeprops = JsonConvert.SerializeObject(item.As<INode>().Properties);
                    message = (JsonConvert.DeserializeObject<Message>(nodeprops));

                    // Another query gets the related Persons to a post from the database thus finding its creator, the result is processed similarly.
                    List<INode> PersonList = new List<INode>();
                    var getPerson = Db.ConnectDb("MATCH(u:Person)-[:Sends]-(c:Message) WHERE c.MessageId = '" + message.MessageId + "' RETURN u LIMIT 1");
                    var Person = new Person();

                    PersonList = getPerson.Result;
                    var PersonItem = PersonList.First();

                    var Personprops = JsonConvert.SerializeObject(PersonItem.As<INode>().Properties);
                    Person = (JsonConvert.DeserializeObject<Person>(Personprops));

                    // TODO as all these params should match, this could be automated...
                    // fill list with chats
                    messageList.Add(new Message()
                    {
                        MessageId = message.MessageId,
                        Content = message.Content,
                        DatetimeSend = message.DatetimeSend,
                        DatetimeRead = message.DatetimeRead,
                        Personname = Person.Email
                    });
                }
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
            var getChats = Db.ConnectDb("MATCH (p:Chat) WHERE NOT(p) -[:InChat]-(: Person{ PersonId: 1}) RETURN p"); // run query
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
            var getChats = Db.ConnectDb("MATCH (p:Chat) WHERE(p) -[:InChat]-(: Person{ PersonId: 1}) RETURN p"); // run query
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

        /// <summary>
        /// Get friends
        /// </summary>
        /// <returns>List with users friends</returns>
        public List<Person> GetFriends()
        {
            List<INode> friendNodes = new List<INode>(); // will store friend nodes
            var getFriends = Db.ConnectDb("MATCH (p:Person) WHERE(p) -[:IsFriendsWith]-(: Person{ PersonId: 1}) RETURN p"); // run query
            var friend = new Person(); // store friend
            List<Person> friendList = new List<Person>(); // store list of all friends

            friendNodes = getFriends.Result; // fill friend nodes with queries result
            // go trough all items
            foreach (var item in friendNodes)
            {
                // pull data from item and convert json
                var nodeprops = JsonConvert.SerializeObject(item.As<INode>().Properties);
                friend = (JsonConvert.DeserializeObject<Person>(nodeprops));

                // fill list with chats
                friendList.Add(new Person()
                {
                    FirstName = friend.FirstName,
                    LastName = friend.LastName,
                    Email = friend.Email
                });
            }

            return friendList; // return results
        }

        /// <summary>
        /// Get friend by email
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Person GetFriend(string email)
        {
            List<INode> nodeList = new List<INode>(); // store friend node
            var results = Db.ConnectDb("MATCH (a:Person) WHERE a.Email = '" + email + "' RETURN a"); // run query
            var user = new Person();

            nodeList = results.Result;
            foreach (var record in nodeList)
            {
                var nodeprops = JsonConvert.SerializeObject(record.As<INode>().Properties);
                user = (JsonConvert.DeserializeObject<Person>(nodeprops));
            }

            return user;
        }
    }
}