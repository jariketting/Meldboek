using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using meldboek.Models;
using Microsoft.AspNetCore.Mvc;
using Neo4j.Driver;

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

            Group g = new Group(Groepnaam);

            var r = ConnectDb("CREATE (g:Group { Groupname: '" + g.GroupName + "' }) RETURN g");

            r.Wait();

            var GroupLong = r.Result[0].Id;


           int GroupId = unchecked((int)GroupLong);


            var r2 = ConnectDb("MATCH (p:Person),(g:Group) WHERE ID(p) = "+ManagerID+" AND ID(g) = "+GroupId+" CREATE(p) -[r: IsOwner]->(g) RETURN p, g");



            return View();


         

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