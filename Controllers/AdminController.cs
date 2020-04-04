using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace meldboek.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateAccount()
        {
            return View();
        }
        
        public IActionResult LogIn(string email, string password)
        {
            if (email == null)
            {
                return null;
            }
            email = "saadeddinsalila@gmail.com";
            password = "0000";
         
            
            return View();
            
        }

    }
}