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
 
    public class LoginController : PersonController
    {
        public IActionResult Index()
        {
           
            return View();
        }
        
        [HttpPost]
        public ActionResult Authorize(meldboek.Models.Person userModel, string email, string password)
        {
      
            List<INode> nodeList = new List<INode>();
            
                var results = ConnectDb("MATCH (a:Person) WHERE a.Email = '" + email + "' AND a.Password = '" + password + "'  RETURN a");
               
                var user = new Person();

                nodeList = results.Result;
                foreach (var record in nodeList)
                {
                    var nodeprops = JsonConvert.SerializeObject(record.As<INode>().Properties);
                    user = (JsonConvert.DeserializeObject<Models.Person>(nodeprops));
                }
               


            if (user.Email == null || user.Password == null)
                {
                    

                    userModel.LoginErrorMessage = "Email of wachtwoord zijn onjuist";
                    return View("Index", userModel);
                }
                else 
                {
                var claims = new List<Claim>
                                {
                                    new Claim(ClaimTypes.Name, "Person", ClaimValueTypes.String),
                                    new Claim(ClaimTypes.NameIdentifier, user.FirstName.ToString(), ClaimValueTypes.String),
                                    new Claim(ClaimTypes.Role, "Person", ClaimValueTypes.String)
                                   
                                };
                                var userIdentity = new ClaimsIdentity(claims, "SecureLogin");
                                var userPrincipal = new ClaimsPrincipal(userIdentity);
                                Thread.CurrentPrincipal = new ClaimsPrincipal(userIdentity);
                                 //Log de gebruiker in
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