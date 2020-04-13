using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using meldboek.Models;
namespace meldboek.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateAccount(string firstname, string lastname, string email, string password)
        {
            if (password == password2)
            {
                User u1 = new User(firstname, lastname, email, password);
                return View();
            }
            else
            {
                //passwordt incorrect
                return View();
            }


        }

        public IActionResult Newsfeed()
        {
            return View();
        }
    }
}