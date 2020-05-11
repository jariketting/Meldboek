﻿using meldboek.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Neo4j.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace meldboek.Controllers
{
    public class ForumController : Controller
    {
        Forum CurrentForum;
        public IDriver Driver { get; set; }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ForumHome(string fid, string Title,string Content)
        {
            Person u = new PersonController().GetPerson(1);


            /* Forum f = new Forum(GetNewForumId(),u , "Test", "Hoe moet je dit testen?");
                 SaveForum(f);


                 ForumItem fi1 = new ForumItem(GetNewForumItemId(), u, "Geen Idee", f);
                 SaveForumItem(fi1);

                 ForumItem fi2 = new ForumItem(GetNewForumItemId(), u, "Meer replies!", fi1);
                 SaveForumItem(fi2);
     ForumItem fi3 = new ForumItem(GetNewForumItemId(), u, "Meer replies!", fi2);
     SaveForumItem(fi3);
     ForumItem fi4 = new ForumItem(GetNewForumItemId(), u, "Meer replies!", fi3);
     SaveForumItem(fi4);*/



            /*            Forum a = LoadForum(4);
                        List<ForumItem> l = GetAllReplies(a);



                        */
            /*    var fl = GetAllForums();*/
            if (fid != null)
            {
                CurrentForum = LoadForum(Convert.ToInt32(fid));
                ViewBag.Forum = CurrentForum;
 
                Response.Redirect("Forum?id="+fid);
            }
       if(Title != null)
            {

                Forum forum = new Forum(GetNewForumId(), u, Title, Content);

                SaveForum(forum);
            }

            return View();

        }
        
  

   

        public IActionResult Forum(string Content, string fid)
        {
            int ForumId = Convert.ToInt32(fid);
            try
            {
                ForumId = Convert.ToInt32(HttpContext.Request.Query["id"].ToString());
            }
            catch (System.FormatException)
            { 
            }
            if (ForumId != 0)
            {
                CurrentForum = LoadForum(ForumId);
            }
            if (ViewBag.Forum != null)
            {
                CurrentForum = ViewBag.forum;
            }
            if((Forum)TempData["Forum"] != null)
            {
                CurrentForum = (Forum)TempData["Forum"];
            }
            Person u = new PersonController().GetPerson(1);

            List<ForumItem> ItemList = GetAllReplies(CurrentForum);
            if (Content !=null)
            {
                Response.Redirect("Forum?id=" + ForumId);
                if (ItemList.Count == 0)
                {
                    ForumItem forumItem = new ForumItem(GetNewForumItemId(), u, Content, CurrentForum);
                    SaveForumItem(forumItem);

                }
                else
                {
                    ForumItem forumItem = new ForumItem(GetNewForumItemId(), u, Content, ItemList[ItemList.Count - 1]);
                    SaveForumItem(forumItem);
                }
            }


            ViewBag.Forum = CurrentForum;

            return View();
        }

            //pak alle Forums
            public List<Forum> GetAllForums()
        {
            List<Forum> FL = new List<Forum>();


            List<INode> nodeList = new List<INode>();

            var r = ConnectDb("MATCH (n:Forum) RETURN n");
            r.Wait();

            foreach (var result in r.Result) {

                string title = (string)result.Properties["Title"];
                string content = (string)result.Properties["Content"];
                int forumId = Convert.ToInt32((Int64)result.Properties["ForumId"]);
               



            var r2 = ConnectDb("MATCH (p:Person)-[Made]-(n:Forum) WHERE n.ForumId=" + forumId + " RETURN p");
                r2.Wait();
                Person owner = new Person();
                nodeList = r2.Result;
                foreach (var record in nodeList)
                {
                    var nodeprops = JsonConvert.SerializeObject(record.As<INode>().Properties);
                    owner = (JsonConvert.DeserializeObject<Person>(nodeprops));
                }
                Forum f = new Forum(forumId, owner, title, content);
                FL.Add(f);

            }



            

            return FL;
        }


        //Pak alle replies op een forum
        public List<ForumItem> GetAllReplies(Forum f)
        {
            ForumItem Fi;
            List<ForumItem> r = new List<ForumItem>();
            List<int> idList = new List<int>();
            Boolean s = true;
            Fi = LoadForumItem(f);

            if (Fi == null)
            {
                f.AantalReacties = r.Count();
                return r;
            }
            else
            {
                r.Add(Fi);
                idList.Add(Fi.ForumItemId);
            }

            while (s)
            {

                Fi = LoadForumItem(Fi);
                if (Fi == null)
                {
                    f.AantalReacties = r.Count();
                    return r;
                }

                if (idList.Contains(Fi.ForumItemId))
                {
                    f.AantalReacties = r.Count();
                    return r;
                }
                else
                {
                    r.Add(Fi);
                    idList.Add(Fi.ForumItemId);
                }
            }



            return r;



        }

        //Forums laden van de database
        public Forum LoadForum(int forumId)
        {
            List<INode> nodeList = new List<INode>();

            var r = ConnectDb("MATCH (n:Forum) WHERE n.ForumId="+forumId+" RETURN n");
            r.Wait();

            var r2 = ConnectDb("MATCH (p:Person)-[Made]-(n:Forum) WHERE n.ForumId="+forumId+" RETURN p");
            r2.Wait();
            Person owner = new Person();
            nodeList = r2.Result;
            foreach (var record in nodeList)
            {
                var nodeprops = JsonConvert.SerializeObject(record.As<INode>().Properties);
                owner = (JsonConvert.DeserializeObject<Person>(nodeprops));
            }

            string title = (string)r.Result[0].Properties["Title"];
            string content = (string)r.Result[0].Properties["Content"];

            



            return new Forum(forumId, owner, title, content); 
        }
       
        //ForumItems laden van de database voor reply of forum
        public ForumItem LoadForumItem(Forum replyOnForum)
        {
            try
            {
                List<INode> nodeList = new List<INode>();


            var r = ConnectDb("MATCH (p:ForumItem)-[]-(n:Forum) WHERE n.ForumId="+replyOnForum.ForumId+" RETURN p");
            r.Wait();
            int forumItemId = Convert.ToInt32((Int64)r.Result[0].Properties["ForumItemId"]);
            var r2 = ConnectDb("MATCH (p:Person)-[Made]-(n:ForumItem) WHERE n.forumItemId=" + forumItemId + " RETURN p");
            r2.Wait();
            Person owner = new Person();
            nodeList = r2.Result;
            foreach (var record in nodeList)
            {
                var nodeprops = JsonConvert.SerializeObject(record.As<INode>().Properties);
                owner = (JsonConvert.DeserializeObject<Person>(nodeprops));
            }


            string content = (string)r.Result[0].Properties["Content"];






            return new ForumItem(forumItemId, owner, content, replyOnForum);
            }
            catch (ArgumentOutOfRangeException)
            {
                return null;
            }
        }
        //ForumItems laden van de database voor reply op reply
        public ForumItem LoadForumItem(ForumItem replyOnForumItem)
        {
            try
            {
                List<INode> nodeList = new List<INode>();

            var r = ConnectDb("MATCH (p:ForumItem)-[]-(n:ForumItem) WHERE n.ForumItemId=" + replyOnForumItem.ForumItemId + " RETURN p");
            r.Wait();
            int forumItemId = Convert.ToInt32((Int64)r.Result[0].Properties["ForumItemId"]);

            var r2 = ConnectDb("MATCH (p:Person)-[Made]-(n:ForumItem) WHERE n.forumItemId=" + forumItemId + " RETURN p");
            r2.Wait();
            Person owner = new Person();
            nodeList = r2.Result;
            foreach (var record in nodeList)
            {
                var nodeprops = JsonConvert.SerializeObject(record.As<INode>().Properties);
                owner = (JsonConvert.DeserializeObject<Person>(nodeprops));
            }


            string content = (string)r.Result[0].Properties["Content"];



            return new ForumItem(forumItemId, owner, content, replyOnForumItem);
              }
            catch (ArgumentOutOfRangeException)
            {
                return null;
            }
        }

        //Forums saven naar de database
        public void SaveForum(Forum forum)
        {
            var r = ConnectDb("CREATE (F:Forum {ForumId: " + forum.ForumId + ",Title: '" + forum.Title + "', Content: '" + forum.Content + "',  LastEdit: '" + forum.lastEdit + "' }) RETURN F");
            r.Wait();
            var r2 = ConnectDb("MATCH (p:Person),(f:Forum) WHERE p.PersonId = " + forum.Owner.PersonId + " AND f.ForumId = " + forum.ForumId + " CREATE(p) -[r: Made]->(f) RETURN p, f");
            r2.Wait();


            //dit is om het de Neo4J ID te pakken
            // var GroupLong = r.Result[0].Id; 
            // int GroupId = unchecked((int)GroupLong);



        }
        //ForumItems saven naar de database
        public void SaveForumItem(ForumItem forumItem)
        {



            var r = ConnectDb("CREATE (F:ForumItem {ForumItemId: " + forumItem.ForumItemId + ",Content: '" + forumItem.Content + "'}) RETURN F");
            r.Wait();
            var r2 = ConnectDb("MATCH (p:Person),(f:ForumItem) WHERE p.PersonId = " + forumItem.Owner.PersonId + " AND f.ForumItemId = " + forumItem.ForumItemId + " CREATE(p) -[r: Made]->(f) RETURN p, f");
            r2.Wait();

            if (forumItem.ReplyOnForum == null)
            {
                var r3 = ConnectDb("MATCH (p:ForumItem),(f:ForumItem) WHERE p.ForumItemId = " + forumItem.ForumItemId + " AND f.ForumItemId = " + forumItem.ReplyOnForumItem.ForumItemId + " CREATE(p) -[r: RepliedOnForumItem]->(f) RETURN p, f");
                r3.Wait();
            }
            else
            {
                var r3 = ConnectDb("MATCH (p:ForumItem),(f:Forum) WHERE p.ForumItemId = " + forumItem.ForumItemId + " AND f.ForumId = " + forumItem.ReplyOnForum.ForumId + " CREATE(p) -[r: RelpiedOnForum]->(f) RETURN p, f");
                r3.Wait();
            }
           
           






        }
        //Forums delete van de database
        public void DeleteForum(Forum forum)
        {

            
        }
        //ForumItems delete van de database
        public void DeleteForumItem(ForumItem forumItem)
        {

            
        }
        //Forums Update van de database
        public void UpdateForum(Forum forum)
        {


        }
        //ForumItems Update van de database
        public void UpdateForumItem(ForumItem forumItem)
        {


        }

        //genereer nieuw ForumId
        public int GetNewForumId()
        {
            List<INode> postNodes = new List<INode>();
            var getPosts = ConnectDb("MATCH(p:Forum) RETURN p ORDER BY toInteger(p.ForumId) DESC LIMIT 1");
            var Forum = new Forum();

            postNodes = getPosts.Result;
            int r = 0;
            foreach (var record in postNodes)
            {
                var nodeprops = JsonConvert.SerializeObject(record.As<INode>().Properties);
                r = Convert.ToInt32(record.Properties.Values.ToArray().GetValue(3));
            }

            return r + 1;
        }

        //genereer nieuw ForumItemId
        public int GetNewForumItemId()
        {
            List<INode> postNodes = new List<INode>();
            var getPosts = ConnectDb("MATCH(p:ForumItem) RETURN p ORDER BY toInteger(p.ForumItemId) DESC LIMIT 1");
            var Forum = new Forum();

            postNodes = getPosts.Result;
            int r = 0;
            foreach (var record in postNodes)
            {
                var nodeprops = JsonConvert.SerializeObject(record.As<INode>().Properties);
                r = Convert.ToInt32(record.Properties.Values.ToArray().GetValue(0));
            }

            return r + 1;
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
        public IDriver CreateDriverWithBasicAuth(string uri, string Person, string password)
        {
            return GraphDatabase.Driver(new Uri(uri), AuthTokens.Basic(Person, password));
        }













    }
}