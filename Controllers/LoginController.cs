using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                var results = ConnectDb("MATCH (a:Person) WHERE a.Email = '" + email + "' AND a.Password =  '" + password + "'  RETURN a");
                var user = new Models.Person();

                nodeList = results.Result;
                foreach (var record in nodeList)
                {
                    var nodeprops = JsonConvert.SerializeObject(record.As<INode>().Properties);
                    user = (JsonConvert.DeserializeObject<Models.Person>(nodeprops));
                }
               
                if (user.Email == null || user.Password == null)
                {

                    userModel.LoginErrorMessage = "Email of wachtword zijn onjuist";
                    return View("Index", userModel);
                }
                else 
                {
         
                 return RedirectToAction("Profile", "Person");
                }

            }
       
    }
    
}