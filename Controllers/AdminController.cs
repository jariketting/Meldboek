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
        //public IActionResult CreateAccount()
        //{
        //    return View();
        //}
        public Admin GetAdmin(int adminid)
        {
            List<INode> nodeList = new List<INode>();
            var result = ConnectDb("MATCH (a:Person) WHERE a.AdminId = " + adminid.ToString() + " RETURN a");
            var admin = new Admin();

            nodeList = result.Result;
            foreach (var record in nodeList)
            {
                var props = JsonConvert.SerializeObject(record.As<INode>().Properties);
                admin = (JsonConvert.DeserializeObject<Admin>(props));
            }



            return admin;
        }

        public IActionResult CreateAccount(string firstname, string lastname, string email, string password, string password2)
        {
            if (firstname != null & lastname != null & email != null & password != null & password == password2)
            {
                Admin u = new Admin()
                {
                    FirstName = firstname,
                    LastName = lastname,
                    Email = email,
                    Password = password


                };
                var r = ConnectDb("CREATE (p:Person:Admin { FirstName: '" + u.FirstName + "', LastName: '" + u.LastName + "' ,Email: '" + u.Email + "', Password: '" + u.Password + "' }) RETURN p");
                r.Wait();
                return View();
            }
            else
            {
                //passwordt incorrect
                return View();
            }
        }

        public IActionResult Profile(string username)
        {
            return View();
        }
        public IActionResult LogIn(string email, string password, int adminId)
        {
            var admin = GetAdmin(adminId);
            var adminid = admin.AdminId;
            var Email = email;
            var Password = password;


                if (Email != null & Password != null)
                {
                    var account = ConnectDb("MATCH (a:Person:Admin) WHERE a.AdminId = " + adminid.ToString() + " RETURN a");
                    if(account != null)
                    {
                         return RedirectToAction("Profile", "Admin");
                    }
                    else
                    {
                    RedirectToAction ("CreateAccount", "Admin");
                    }
                            
                }
                else
                {
                     RedirectToAction("CreateAccount", "Admin");
                }

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