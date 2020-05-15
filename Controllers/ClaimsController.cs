using meldboek.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace meldboek.Controllers
{

    public class ClaimsController
    {
        private static ClaimsController instance = null;
        private static readonly object padlock = new object();
        private Person LoginClaim;


        public Person GetClaim()
        {
            Person returnObject;
            var a = (ClaimsPrincipal)Thread.CurrentPrincipal;
            // var naaam = Microsoft.AspNet.Identity.Claims.Where(c => c.Type == ClaimTypes.Name);
            var c = new List<Claim>();
            returnObject = LoginClaim;
            c.Add(new Claim(ClaimTypes.NameIdentifier, LoginClaim.PersonId.ToString()));
            return returnObject;
        }
        public void SetClaim(Person p)
        {
            var claims = new List<Claim>
                            {

                                new Claim(ClaimTypes.NameIdentifier, "123456789" , ClaimValueTypes.String),


                            };
            var userIdentity = new ClaimsIdentity(claims, "SecureLogin");
            var userPrincipal = new ClaimsPrincipal(userIdentity);
            Thread.CurrentPrincipal = new ClaimsPrincipal(userIdentity);
            var c = new List<Claim>();
            c.Add(new Claim(ClaimTypes.NameIdentifier, p.PersonId.ToString()));
            LoginClaim = p;
            var i = new ClaimsIdentity(c, DefaultAuthenticationTypes.ApplicationCookie);
            var cp = new ClaimsPrincipal(i);

            var t = Thread.CurrentPrincipal = cp;
 



            var a = (ClaimsPrincipal)Thread.CurrentPrincipal;
            
            // var naaam = Microsoft.AspNet.Identity.Claims.Where(c => c.Type == ClaimTypes.Name);
            
            return;


        }



        public static ClaimsController Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ClaimsController();
                    }
                    return instance;
                }
            }
        }
    }

}

