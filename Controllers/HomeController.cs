using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using meldboek.Models;
using Neo4jClient;
using Neo4j.Driver;

namespace meldboek.Controllers
{
    public class HomeController : Controller
    {
        public IDriver Driver { get; set; }

        public IActionResult Index()
        {
            // Session on driver does not exist?

            // Driver = CreateDriverWithBasicAuth("http://localhost:7474/db/data", "neo4j", "1234");
            // using (var session = Driver.Session(SessionConfigBuilder.ForDatabase("examples")))
            // {
            //     session.Run("CREATE (a:Greeting {message: 'Hello, Example-Database'}) RETURN a").Consume();
            // }
            //     void SessionConfig(SessionConfigBuilder configBuilder) => configBuilder.WithDatabase("examples")
            //         .WithDefaultAccessMode(AccessMode.Read) .Build();
            //         using (var session = Driver.Session(SessionConfig)) {
            //         var result = session.Run("MATCH (a:Greeting) RETURN a.message as msg"); var msg = result.Single()[0].As<string>();
            //         Console.WriteLine(msg);
            //                     }

            // 404 cannot make connection??

            // var client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "1234");
            // client.Connect();

            // var result = client.Cypher.Match("N").Return<String>("N");
            // ViewData["Result"] = result;
            //  Console.WriteLine("Done");
            SMT();

            return View();
        }

        public async void SMT()
        {
            IDriver driver = GraphDatabase.Driver("bolt://localhost:7687", AuthTokens.Basic("neo4j", "1234"));


            IAsyncSession session = driver.AsyncSession(o => o.WithDatabase("neo4j"));
            try
            {
                IResultCursor cursor = await session.RunAsync("CREATE (n:Person { name: 'Andy', title: 'Developer' }) RETURN n");
                Console.WriteLine(cursor.ToString());
                Console.WriteLine("Done");
                await cursor.ConsumeAsync();
            }

            finally
            {
                await session.CloseAsync();
            }

            await driver.CloseAsync();
        }


        public IDriver CreateDriverWithBasicAuth(string uri, string user, string password)
        {
            return GraphDatabase.Driver(uri, AuthTokens.Basic(user, password));
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
