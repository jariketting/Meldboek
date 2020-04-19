using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using meldboek.Models;
using Neo4j.Driver;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Neo4jClient;
using System.Collections;
using System.Reflection;

namespace meldboek.Controllers
{
    public class UserController : Controller
    {
        public IDriver Driver { get; set; }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateAccount(string firstname, string lastname, string email, string password)
        {
            if (firstname != null & lastname != null & email != null & password != null)
            {
                User u1 = new User()
                {
                    FirstName = firstname,
                    LastName = lastname,
                    Email = email,
                    Password = password
                };

                return View();
            }
            else
            {
                //password incorrect
                return View();
            }


        }

        public IActionResult Newsfeed()
        {
            GetPosts();
            return View();
        }

        [HttpPost]
        public IActionResult AddPost(string title, string description, string postid)
        {
            string Timestamp = System.DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            ConnectDb("CREATE (n:Post {title: '" + title + "', description: '" + description + "', postid: '" + postid + "', dateadded: '" + Timestamp + "'})");
            return RedirectToAction("Newsfeed");
        }

        public IActionResult GetPosts() {
            List<INode> nodeList = new List<INode>();
            var results = ConnectDb("MATCH (p) RETURN (p)");
            var post = new Newspost();
            List<Newspost> obj = new List<Newspost>();

            nodeList = results.Result;
            foreach (var record in nodeList)
            {
                var nodeprops = JsonConvert.SerializeObject(record.As<INode>().Properties);
                post = (JsonConvert.DeserializeObject<Newspost>(nodeprops));

                obj.Add(new Newspost()
                {
                    PostId = post.PostId,
                    Title = post.Title,
                    Description = post.Description,
                    DateAdded = post.DateAdded
                });
            }
            List<Newspost> SortedList = obj.OrderByDescending(p => p.DateAdded).ToList();
            return View(SortedList);
        }

        public Boolean AddFriend(int userId, int friendId)
        {
            // maybe add check for if they already are friends

            var user = GetUser(userId);
            var userPending = GetUser(friendId);
            var Success = new Boolean();
            var userid = user.UserId;
            var frienduserid = userPending.UserId;
            Console.WriteLine(userid.ToString());
            Console.WriteLine(frienduserid.ToString());

            if (userid == userId & friendId == frienduserid)
            {
                var results = ConnectDb("MATCH (a:Person), (b:Person) WHERE a.UserId = " + userId.ToString() + " AND b.UserId = " + friendId.ToString() + " CREATE (a)-[r:FriendPending]->(b)" + " RETURN a");
                Success = true;
            }
            else
            {
                Success = false;
            }

            return Success;

        }

        public void AcceptFriend(User userRequested, User userAccepted)
        {            
           ConnectDb("MATCH (a:Person), (b:Person) WHERE a.UserId = " + userRequested.UserId.ToString() + " AND b.UserId = " + userAccepted.UserId.ToString() + " CREATE (a)-[r:IsFriendsWith]->(b)" + " RETURN a");
        }

        public User GetUser(int userId)
        {
            List<INode> nodeList = new List<INode>();
            var results = ConnectDb("MATCH (a:Person) WHERE a.UserId = " + userId.ToString() + " RETURN a");
            var user = new User();

                nodeList = results.Result;
                foreach (var record in nodeList)
                {
                    var nodeprops = JsonConvert.SerializeObject(record.As<INode>().Properties);
                    user = (JsonConvert.DeserializeObject<User>(nodeprops));
                }
            


            return user;
        }

         public async Task<List<INode>> ConnectDb(string query)
        {
            Driver = CreateDriverWithBasicAuth("bolt://localhost:11003", "neo4j", "1234");
            List<INode> res = new List<INode>();
            IAsyncSession session = Driver.AsyncSession(o => o.WithDatabase("neo4j"));

            try
            {
                res = await session.ReadTransactionAsync(async tx =>
                {
                    var results = new List<INode>();
                    var reader = await tx.RunAsync(query);

                    while (await reader.FetchAsync())
                    {
                        results.Add(reader.Current[0].As<INode>());

                    }

                    return results;
                });


            }

            finally
            {
                await session.CloseAsync();

            }
            return res;

        }




        public IDriver CreateDriverWithBasicAuth(string uri, string user, string password)
        {
            return GraphDatabase.Driver(new Uri(uri), AuthTokens.Basic(user, password));
        }


    }
}