using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace meldboek.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateAccount(string firstname, string lastname, string email, string password, string password2)
        {
            //account toevoegen aan database
            return View();

        }
    }
}