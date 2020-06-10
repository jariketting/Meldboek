using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using meldboek.ViewModels;
using System.Globalization;
using Microsoft.AspNetCore.Authentication;
using meldboek.Models;
using Neo4j.Driver;
using Newtonsoft.Json;


namespace meldboek
{
    public class Startup
    {
        Database Db { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether Person consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseDefaultFiles();

            RoleCheck();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Login}/{action=Index1}");
            });
        }

        public async Task<string> RoleCheck()
        { 
            Db = new Database();
            var RoleCheckk =  Db.ConnectDb2("MATCH(r:Role) WHERE r.RoleName = 'Manager' RETURN r.RoleName");
            string RoleCheck = RoleCheckk.Result;
            if(RoleCheck == "Manager")
            {
                return "true";
            }
            else
            {
                await Db.ConnectDb("CREATE(r:Role {RoleName: 'Manager'})");
                await Db.ConnectDb("CREATE(r:Role {RoleName: 'Medewerker'})");
                await Db.ConnectDb("CREATE (p:Person { PersonId: 1, FirstName: 'Henk', LastName: 'Jansen' ,Email: 'henk@jansen.nl', Password: 'meldboek' }) RETURN p");
                await Db.ConnectDb("MATCH (p:Person), (r:Role) WHERE p.PersonId = 1 AND r.RoleName = 'Manager' CREATE (p)-[:HasRole]->(r) RETURN p, r");
                
                return "done";
            }

        }
    }
}
