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
        public IGraphClient GraphClient {get;set;}


       public IActionResult Index()
       {

           ConnectDb("CREATE (n:Person { name: 'Anna', title: 'Developer' }) RETURN n");


           return View();
       }

        // public ActionResult  Index()
        // {
        //     var client = new GraphClient(new Uri("bolt://localhost:7687"),"neo4j", "1234");
        //     client.Connect();
        //     GraphClient = client;

        //     var query = GraphClient.Cypher
        //     .Match("(n:Person) where n.name = Andy")
        //     .Return((n) => new{
        //         smt = n.As<string>("collect(x.name)")
        //     });
        //     var result = query.Results.ToList();
        //     Console.WriteLine(result);
        //       Console.WriteLine("Done");

        //       return View();
        // }



        public async void ConnectDb(string query)
        {
               Driver = CreateDriverWithBasicAuth("bolt://localhost:7687", "neo4j", "1234");


            IAsyncSession session = Driver.AsyncSession(o => o.WithDatabase("neo4j"));
            try
            {
                IResultCursor cursor = await session.RunAsync(query);
                //          Console.WriteLine(cursor.Current.Values.ToString());
                Console.WriteLine("Done");
                await cursor.ConsumeAsync();
            }

            finally
            {
                await session.CloseAsync();
            }

            await Driver.CloseAsync();
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
