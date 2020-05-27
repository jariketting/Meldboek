using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using meldboek.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Neo4j.Driver;
using Newtonsoft.Json;


namespace meldboek.Controllers
{
    //This class inherits properties of PersonController
    public class LoginController : Controller
    {
        //This method returns the view of Login page
        public IActionResult Index1()
        {

            return View();
        }
        // To submit user data
        [HttpPost]
        //This method checks the validation of inserted data and returns Redirection to Profile view if data is found in database
        public ActionResult Authorize(meldboek.Models.Person userModel, string email, string password)
        {
            //Gets the user from database
            List<INode> userlist = new List<INode>();
            var getuser = ConnectDb("MATCH (a:Person) WHERE a.Email = '" + email + "' AND a.Password = '" + password + "'  RETURN a");
         
            var user = new Person();
            
            userlist = getuser.Result; // fill chat nodes with queries result

            INode useritem;

            try
            {
                useritem = userlist.First();
            }
            catch
            {
                userModel.LoginErrorMessage = "Email of wachtwoord zijn onjuist";
                return View("Index1", userModel);
            }


            // pull data from useritem and convert json
            var userprops = JsonConvert.SerializeObject(useritem.As<INode>().Properties);
            user = (JsonConvert.DeserializeObject<Person>(userprops));


            // Get user role
            var role = ConnectDb2("MATCH(:Person{PersonId: " + user.PersonId + "})-[:HasRole]->(r:Role) RETURN r.RoleName").Result;


            //Checks if inserted data is not correct
            if (user.Email == null || user.Password == null)
            {

                //if inserted data is not found in the database, returns Login error message.
                userModel.LoginErrorMessage = "Email of wachtwoord zijn onjuist";
                return View("Index1", userModel);
            }
            else
            {
                //if inserted data is found in the database, make claims for the logged in user
                var claims = new List<Claim>
                                {
                                    //new Claim(ClaimTypes.Name, "Person", ClaimValueTypes.String),
                                    new Claim(ClaimTypes.NameIdentifier, user.PersonId.ToString(), ClaimValueTypes.String),
                                    new Claim(ClaimTypes.Role, role, ClaimValueTypes.String),
                                    new Claim(ClaimTypes.Name, userprops, ClaimValueTypes.String)

                                };
                var userIdentity = new ClaimsIdentity(claims, "SecureLogin");
                var userPrincipal = new ClaimsPrincipal(userIdentity);
                Thread.CurrentPrincipal = new ClaimsPrincipal(userIdentity);
                //Login the user
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                userPrincipal,
                new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(30),
                    IsPersistent = true,
                    AllowRefresh = false
                });

                return RedirectToAction("Home", "Person");
            }

        }

        public async Task<List<INode>> ConnectDb(string query)
        {
            var Driver = CreateDriverWithBasicAuth("bolt://localhost:11005", "neo4j", "1234");
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

        public async Task<string> ConnectDb2(string query)
        {
            // ConnectDb2 returns a string instead of list of nodes.

            var Driver = CreateDriverWithBasicAuth("bolt://localhost:11005", "neo4j", "1234");
            string res = "";
            IAsyncSession session = Driver.AsyncSession(o => o.WithDatabase("neo4j"));

            try
            {
                res = await session.ReadTransactionAsync(async tx =>
                {
                    string results = "";
                    var reader = await tx.RunAsync(query);

                    while (await reader.FetchAsync())
                    {
                        results = reader.Current[0].As<string>();
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