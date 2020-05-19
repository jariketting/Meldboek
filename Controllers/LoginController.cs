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
    public class LoginController : PersonController
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
            List<INode> nodeList = new List<INode>();

            var results = ConnectDb("MATCH (a:Person) WHERE a.Email = '" + email + "' AND a.Password = '" + password + "'  RETURN a");

            var user = new Person();

            nodeList = results.Result;
            foreach (var record in nodeList)
            {
                var nodeprops = JsonConvert.SerializeObject(record.As<INode>().Properties);
                user = (JsonConvert.DeserializeObject<Models.Person>(nodeprops));
            }


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
                                    new Claim(ClaimTypes.Name, "Person", ClaimValueTypes.String),
                                    new Claim(ClaimTypes.NameIdentifier, user.FirstName.ToString(), ClaimValueTypes.String),
                                    new Claim(ClaimTypes.Role, "Person", ClaimValueTypes.String)

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

                return RedirectToAction("Profile", "Person");
            }

        }

    }

}