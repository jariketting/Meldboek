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
        //   public IDriver Driver { get; }

        public IActionResult Index()
        {

            // 404 cannot make connection??
            // var client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "1234");
            // client.Connect();

            // var result = client.Cypher.Match("N").Return<String>("N");
            // ViewData["Result"] = result;
            //  Console.WriteLine("Done");

            return View();
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
