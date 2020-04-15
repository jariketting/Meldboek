using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using meldboek.Models;
using Neo4jClient;
using Neo4j.Driver;
using Neo4jClient.Cypher;
using Autofac;

namespace meldboek.Controllers
{
    public class HomeController : Controller
    {
        public IDriver Driver { get; set; }
        public IGraphClient GraphClient { get; set; }



        public IActionResult Index()
        {
            var results = ConnectDb("CREATE (n:Person { name: 'Yas', title: 'Developer' }) RETURN n");
            // var results = ConnectDb("MATCH (a:Person) RETURN a");
            Console.WriteLine(results.ToString());

            return View();
        }



        public async Task<List<String>> ConnectDb(string query)
        {
            Driver = CreateDriverWithBasicAuth("bolt://localhost:7687", "neo4j", "1234");
            List<string> res = new List<string>();
            IAsyncSession session = Driver.AsyncSession(o => o.WithDatabase("neo4j"));

            try
            {
                res = await session.ReadTransactionAsync(async tx =>
                {
                    var results = new List<string>();
                    var reader = await tx.RunAsync(query);

                    while (await reader.FetchAsync())
                    {
                        results.Add(reader.Current[0].ToString());
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
