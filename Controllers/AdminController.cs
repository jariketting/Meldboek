using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using meldboek.Models;
using Microsoft.AspNetCore.Mvc;
using Neo4j.Driver;
using Newtonsoft.Json;
using System.Security.Claims;

namespace meldboek.Controllers
{
    public class AdminController : Controller
    {
        public IDriver Driver { get; set; }

        public IActionResult Index()
        {
            return View();
        }

        public Person GetCurrentPerson()
        {
            if (!User.Claims.Any(x => x.Type == ClaimTypes.Name))
            {
                return null;
            }
            else
            {
                var getClaims = User.Claims.First(x => x.Type == ClaimTypes.Name).Value;
                Person CurrentPerson = (JsonConvert.DeserializeObject<Person>(getClaims));

                return CurrentPerson;
            }
        }

        public IActionResult CreateAccount()
        {
            if (GetCurrentPerson() == null)
            {
                return RedirectToAction("LoginError", "Login");
            }

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
        public IActionResult CreateGroups(string GroupName, string ManagerId)
        {
            if (GetCurrentPerson() == null)
            {
                return RedirectToAction("LoginError", "Login");
            }

            if (GroupName != null)
            {
                int GroupId = GetMaxGroupId();
                GroupName = GroupName.Replace("'", "&#39;");
                Group g = new Group(GroupId, GroupName);

                var r = ConnectDb("CREATE (g:Group {GroupId: " + g.GroupId + ", GroupName: '" + g.GroupName + "' }) RETURN g");

                r.Wait();
                //dit is om het de Neo4J ID te pakken
                // var GroupLong = r.Result[0].Id; 
                // int GroupId = unchecked((int)GroupLong);


                var r2 = ConnectDb("MATCH (p:Person),(g:Group) WHERE p.PersonId = " + ManagerId + " AND g.GroupId = " + GroupId + " CREATE(p) -[r: IsOwner]->(g) RETURN p, g");
                r2.Wait();

            }

            return View(GetManagers());

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

        public List<Person> GetManagers()
        {
            // GetManagers() gets all the Persons that are Managers (relationship type "HasRole" with Role and RoleName "Manager") from the database and puts them in a list of Person objects.

            List<INode> managerNodes = new List<INode>();
            var getManagers = ConnectDb("MATCH(p) WHERE (p)-[:HasRole]->(:Role {RoleName:'Manager'}) RETURN p");
            var manager = new Person();
            List<Person> managerList = new List<Person>();

            managerNodes = getManagers.Result;
            foreach (var record in managerNodes)
            {
                var nodeprops = JsonConvert.SerializeObject(record.As<INode>().Properties);
                manager = (JsonConvert.DeserializeObject<Person>(nodeprops));

                manager.LastName = manager.LastName.Replace("&#39;", "'");

                // After getting al the required data, it is put into a Person object and added to the list of managers.
                managerList.Add(new Person()
                {
                    PersonId = manager.PersonId,
                    FirstName = manager.FirstName,
                    LastName = manager.LastName,
                    Email = manager.Email
                });

            }

            // The final list is ordered by FirstName (then by LastName) and put into a list called "final".
            List<Person> final = managerList.OrderBy(m => m.FirstName).ThenBy(m => m.LastName).ToList();
            return final;
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
        public IDriver CreateDriverWithBasicAuth(string uri, string Person, string password)
        {
            return GraphDatabase.Driver(new Uri(uri), AuthTokens.Basic(Person, password));
        }

    }
}