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
    public class AdminController : Controller
    {
        public IDriver Driver { get; set; }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateAccount()
        {
            return View();
        }

        public IActionResult LogIn(string email, string password)
        {

            {
                if (email == "admin" && password == "admin")
                {
                    Response.Redirect("LogIn");
                }
            }



            return View();

        }
        public IActionResult CreateGroups(string Groepnaam, string ManagerID)
        {
            if (Groepnaam != null)
            {
                int groupId = GetMaxGroupId();
                Group g = new Group(groupId, Groepnaam);

                var r = ConnectDb("CREATE (g:Group {GroupId: " + g.GroupId + ", GroupName: '" + g.GroupName + "' }) RETURN g");

                r.Wait();
                //dit is om het de Neo4J ID te pakken
                // var GroupLong = r.Result[0].Id; 
                // int GroupId = unchecked((int)GroupLong);


                var r2 = ConnectDb("MATCH (p:Person),(g:Group) WHERE p.PersonId = " + ManagerID + " AND g.GroupId = " + groupId + " CREATE(p) -[r: IsOwner]->(g) RETURN p, g");
                r2.Wait();

            }


            return View();




        }

        public int GetMaxGroupId()
        {
            int returnId = 0;
            // GetMaxPostId pakt een id die nog niet gebruikt wordt
            Random rnd = new Random();


            while (true)
            {
                returnId = rnd.Next(1000001, 999999999);
                var r = ConnectDb("MATCH (n:Group) WHERE n.GroupId =" + returnId + " return n;");
                r.Wait();
                if (r.Result.Count == 0)
                {
                    return returnId;
                }
            }
        }

        public async Task<List<INode>> ConnectDb(string query)
        {
            Driver = CreateDriverWithBasicAuth("bolt://localhost:11005", "neo4j", "1234");
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
        public IDriver CreateDriverWithBasicAuth(string uri, string Person, string password)
        {
            return GraphDatabase.Driver(new Uri(uri), AuthTokens.Basic(Person, password));
        }

    }
}