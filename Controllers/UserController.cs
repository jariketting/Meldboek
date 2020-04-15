using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using meldboek.Models;
using Neo4j.Driver;
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
                //passwordt incorrect
                return View();
            }


        }

        public IActionResult Newsfeed()
        {
            return View();

        }
        public IActionResult AddFriend(int userId, int friendId)
        {


            return View();
        }

        public User GetUser(int userId)
        {
            // still need to create a user out of the result
            var results = ConnectDb("MATCH (a:Person) WHERE a.UserId = " + userId.ToString() + "RETURN a");
            var nodes = results.Result;
            var node = nodes.FirstOrDefault();
            User user = new User()
            {


            };
            return user;
        }
        public async Task<List<INode>> ConnectDb(string query)
        {
            Driver = CreateDriverWithBasicAuth("bolt://localhost:7687", "neo4j", "1234");
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
                var node = res[0].As<INode>();
                Console.WriteLine(node);

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