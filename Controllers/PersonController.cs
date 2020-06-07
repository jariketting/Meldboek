﻿using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using meldboek.Models;
using Neo4j.Driver;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Neo4jClient;
using System.Collections;
using System.Reflection;
using System.Dynamic;
using System.Xml;
using meldboek.ViewModels;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;


namespace meldboek.Controllers
{
    public class PersonController : Controller
    {
        public IDriver Driver { get; set; }

        public IActionResult Index()
        {
            return View();
        }

        public Person GetCurrentPerson()
        {
            if (!User.Claims.Any(x => x.Type == ClaimTypes.Name))
            {
                return null;
            }
            else
            {
                var getClaims = User.Claims.First(x => x.Type == ClaimTypes.Name).Value;
                Person CurrentPerson = (JsonConvert.DeserializeObject<Person>(getClaims));

                return CurrentPerson;
            }
        }

        public string GetCurrentPersonRole()
        {
            if (!User.Claims.Any(x => x.Type == ClaimTypes.Role))
            {
                return null;
            }
            else
            {
                string CurrentPersonRole = User.Claims.First(x => x.Type == ClaimTypes.Role).Value;
                return CurrentPersonRole;
            }
        }

        [Route("Person/GroepenManagen")]
        public IActionResult GroepenManagen()
        {
            if (GetCurrentPerson() == null)
            {
                return RedirectToAction("LoginError", "Login");
            }

            dynamic model = new ExpandoObject();
            model.OwnedGroups = GetOwnedGroups();

            model.GroupsManagement = null;

            return View(model);
        }

        public IActionResult ManageGroup(int GroupId)
        {
            if (GetCurrentPerson() == null)
            {
                return RedirectToAction("LoginError", "Login");
            }

            dynamic model = new ExpandoObject();
            model.OwnedGroups = GetOwnedGroups();

            model.GroupsManagement = GetGroupsManagement(GroupId);

            return View("GroepenManagen", model);
        }
        public IActionResult AddFile()
        {
            return View();
        }
        [HttpPost]
        public async Task<Tuple<String,String>> FileUpload(IFormFile file, int NewspostId)
        {
            //would do Newspost post and then post.postid later

            Person person = GetCurrentPerson();
            var path = "";
            var filename= "";
            // var folder = "/Users/yasemin/Library/Application Support/Neo4j Desktop/Application/neo4jDatabases/database-a67a9b4b-e0cb-404c-99ce-fccc6509622f/installation-4.0.2/import/" + person.PersonId.ToString() + "/" + NewspostId.ToString();
            var folder = "C:/Users/amyno/.Neo4jDesktop/neo4jDatabases/database-666b6fd9-d2e9-4b34-8955-32a2590baa14/installation-4.0.3/import" + person.PersonId.ToString() + "/" + NewspostId.ToString();
            
            if (!System.IO.Directory.Exists(folder))
            {
                System.IO.Directory.CreateDirectory(folder);
            }
            if (file.Length > 0)
            {

                filename = file.FileName;


                // path = "/Users/yasemin/Library/Application Support/Neo4j Desktop/Application/neo4jDatabases/database-a67a9b4b-e0cb-404c-99ce-fccc6509622f/installation-4.0.2/import/" + person.PersonId.ToString() + "/" + NewspostId.ToString() + "/" + filename;
                path = "C:/Users/amyno/.Neo4jDesktop/neo4jDatabases/database-666b6fd9-d2e9-4b34-8955-32a2590baa14/installation-4.0.3/import" + person.PersonId.ToString() + "/" + NewspostId.ToString() + "/" + filename;

                using (var stream = System.IO.File.Create(path))
                {
                    await file.CopyToAsync(stream);
                }

            }
            Tuple<string,string> val = new Tuple<string, string>(folder,filename);
        

            return val;
        }
        [HttpGet("download")]
        public IActionResult GetDownload(string path, string filename)
        {
            //not done yet
            path = path + "/";
            byte[] fileBytes = System.IO.File.ReadAllBytes(path + filename);
          return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, filename);

        }
        public IActionResult DownloadFile()
        {
            return View();
        }

        //[Route("Person/Profile")]
        public IActionResult Profile()
        {   // De claims in de Login controller worden aangemaakt wanneer een user inlogt
            //Vervolgens wordt daar een cookie van gemaakt.
            // het komende regel hoort de ingelogd user te pakken van de claims maar die geeft een lege sequentie terug.

            if (GetCurrentPerson() == null)
            {
                return RedirectToAction("LoginError", "Login");
            }
            
            Person CurrentPerson = GetCurrentPerson();

            //grab a random person out of the DB until be have the claims
            int personid = CurrentPerson.PersonId;
            List<PersonInfo> personInfos = new List<PersonInfo>();
            List<Person> Relations = GetRelationsById(personid);
            Person person = GetPerson(personid);
            Profile profile = new Profile();
            profile.Name = person.FirstName + " " + person.LastName;
            profile.Email = person.Email;
            profile.Relaties = Relations;
            profile.PersonId = person.PersonId;

            foreach (var rela in Relations)
            {
                var statusreq = CheckFriendRequeststatus(person.PersonId, rela.PersonId);
                if (statusreq == "requested")
                {
                    personInfos.Add(new PersonInfo()
                    {
                        Person = rela,
                        Status = statusreq
                    });
                }
                else if (statusreq == "Friends")
                {
                    personInfos.Add(new PersonInfo()
                    {
                        Person = rela,
                        Status = "IsFriendsWith"
                    });
                }

                else personInfos.Add(new PersonInfo()
                {
                    Person = rela,
                    Status = CheckFriendStatus(person.PersonId, rela.PersonId)
                });

            };
            profile.PersonInfos = personInfos;


            return View(profile);
        }
        public IActionResult Logout()
        {
            //logs the user out
            HttpContext.SignOutAsync();
            return RedirectToAction("Index1", "Login");
        }

        public IActionResult CreateAccount(string firstname, string lastname, string email, string password, string password2, string ismanager)
        {
            if (GetCurrentPerson() == null)
            {
                return RedirectToAction("LoginError", "Login");
            }

            //maakt Person als alles ingevoerd is en wachtwoord klopt
            if (firstname != null & lastname != null & email != null & password != null & password == password2)
            {

                int persId = GetMaxPersonId();
                //stuurt Person naar database
                var a = ConnectDb("CREATE (p:Person { PersonId: " + persId + ", FirstName: '" + firstname + "', LastName: '" + lastname + "' ,Email: '" + email + "', Password: '" + password + "' }) RETURN p");
                a.Wait();
                if (ismanager == "true") { 
                    var b = ConnectDb("MATCH (p:Person), (r:Role) WHERE p.PersonId = " + persId + " AND r.RoleName = 'Manager' CREATE (p)-[:HasRole]->(r) RETURN p, r");
                    b.Wait();
                }
                else
                {
                    var b = ConnectDb("MATCH (p:Person), (r:Role) WHERE p.PersonId = " + persId + " AND r.RoleName = 'Medewerker' CREATE (p)-[:HasRole]->(r) RETURN p, r");
                    b.Wait();
                }
                return View();
            }
            else
            {
                return View();
            }


        }
        

        public IActionResult Home()
        {
            if (GetCurrentPerson() == null)
            {
                return RedirectToAction("LoginError", "Login");
            }

            return View();
        }

        public IActionResult Newsfeed()
        {
            if (GetCurrentPerson() == null)
            {
                return RedirectToAction("LoginError", "Login");
            }

            ViewData["CurrentPersonId"] = GetCurrentPerson().PersonId;

            // Default page is page with filter "Algemeen", which displays all the posts that are not posted in a group.
            TempData["Page"] = "Algemeen";

            // Before returning the view of the newsfeed, all the newsposts and groups need to be pulled from the database.
            dynamic model = new ExpandoObject();
            model.Post = GetFeed();

            model.Group = GetGroups();
            model.Friend = GetFriends();

            return View(model);
        }

        public IActionResult FilteredNewsfeed(string filter)
        {
            if (GetCurrentPerson() == null)
            {
                return RedirectToAction("LoginError", "Login");
            }

            // FilteredNewsfeed returns a newsfeed with a filter depending on what the Person chose.

            ViewData["CurrentPersonId"] = GetCurrentPerson().PersonId;

            if (filter == "Algemeen")
            {
                // Filter "Algemeen" is the default value, so this redirects to the original state of the newsfeed.
                TempData["Page"] = filter;
                return RedirectToAction("Newsfeed");
            }
            else if (filter == "Vrienden")
            {
                // If the Person chose the filter "Vrienden", GetFriendPosts() is used to get the correct posts.
                dynamic model = new ExpandoObject();

                model.Post = GetFriendPosts();

                model.Group = GetGroups();
                model.Friend = GetFriends();

                TempData["Page"] = filter;
                return View("Newsfeed", model);
            }
            else
            {
                // If the chosen filter is neither "Algemeen" or "Vrienden" the Person has chosen a filter for group [groupname].
                dynamic model = new ExpandoObject();

                model.Post = GetGroupPosts(filter);

                model.Group = GetGroups();
                model.Friend = GetFriends();

                TempData["Page"] = filter;
                return View("Newsfeed", model);
            }
        }

        public IActionResult Groepen()
        {
            if (GetCurrentPerson() == null)
            {
                return RedirectToAction("LoginError", "Login");
            }

            ViewData["CurrentPersonId"] = GetCurrentPerson().PersonId;
            ViewData["CurrentPersonRole"] = GetCurrentPersonRole();

            return View(GetGroupsData());
        }

        public IActionResult Personlist()
        {
            if (GetCurrentPerson() == null)
            {
                return RedirectToAction("LoginError", "Login");
            }

            ViewData["CurrentPersonRole"] = GetCurrentPersonRole();

            // Default page is page with filter "Alle gebruikers", which displays all the Persons from the database.
            TempData["Page"] = "Alle gebruikers";
            return View(GetPersonlist());
        }

        public IActionResult FilteredPersonlist(string filter)
        {
            if (GetCurrentPerson() == null)
            {
                return RedirectToAction("LoginError", "Login");
            }

            // FilteredPersonlist returns a personlist with a filter depending on what the Person chose.

            ViewData["CurrentPersonRole"] = GetCurrentPersonRole();

            if (filter == "Alle gebruikers")
            {
                // Filter "Alle gebruikers" is the default value, so this redirects to the original state of the personlist.
                TempData["Page"] = filter;
                return RedirectToAction("Personlist");
            }
            else if (filter == "Vrienden")
            {
                // If the Person chose the filter "Vrienden", GetFriends() is used to get the correct Persons.

                TempData["Page"] = filter;
                return View("Personlist", GetFriends());
            }
            else
            {
                return RedirectToAction("Personlist");
            }
        }

        public int GetMaxPostId()
        {
            int returnId = 0;
            // GetMaxPostId pakt een id die nog niet gebruikt wordt
            Random rnd = new Random();


            while (true)
            {
                returnId = rnd.Next(1000001, 999999999);
                var r = ConnectDb("MATCH (n:Post) WHERE n.PostId =" + returnId + " return n;");
                r.Wait();
                if (r.Result.Count == 0)
                {
                    return returnId;
                }
            }
        }
        public int GetMaxPersonId()
        {
            int returnId = 0;
            // GetMaxPostersonId pakt een id die nog niet gebruikt wordt
            Random rnd = new Random();


            while (true)
            {
                returnId = rnd.Next(1000001, 999999999);
                var r = ConnectDb("MATCH (n:Person) WHERE n.PersonId =" + returnId + " return n;");
                r.Wait();
                if (r.Result.Count == 0)
                {
                    return returnId;
                }
            }


        }

        [HttpPost]
        public async Task<IActionResult> AddPost(string title, string description, string group, IFormFile file)
        {
            // AddPost adds a newspost the Person creates to the database. It takes the given title + description and adds the current time itself.

            // Getting the id of most recent post node, so a new id can be automatically added to the newly created newspost.
            int newid = GetMaxPostId();
            var path = " ";
            var filename = " ";
            Tuple<string,string> fileVal = new Tuple<string, string>(path,filename);

            string datetime = DateTime.Now.ToString("d-M-yyyy HH:mm:ss");
            
            if (file != null)
            {
                fileVal = await FileUpload(file,newid);
            }

            await ConnectDb("CREATE(p:Post {Title: '" + title + "', Description: '" + description + "', PostId: " + newid + ", DateAdded: '" + datetime + "', Filename: '" + fileVal.Item2 + "', Path: '" + fileVal.Item1 +"'})");

            // After adding the post to the database, a relationship is created between the post and the Person who made it. | (Person-[Posted]->Post
            await ConnectDb("MATCH(u:Person), (p:Post) WHERE u.PersonId = " + GetCurrentPerson().PersonId + " AND p.Title = '" + title + "' CREATE(u)-[r:Posted]->(p)");

            // If the chosen category is not "general", the Person has chosen to post in a group they are part of.
            if (group != "Algemeen")
            {
                // Because the post is meant to be for a specific group, a relationship type "HasPost" is created between the group and the newspost.
                await ConnectDb("MATCH(g:Group), (p:Post) WHERE g.GroupName = '" + group + "' AND p.Title = '" + title + "' CREATE(g) -[r:HasPost]->(p)");
                return RedirectToAction("FilteredNewsfeed", new { filter = group });
            }

            return RedirectToAction("FilteredNewsfeed", new { filter = "Algemeen" });
        }

        public async Task<IActionResult> DeletePost(int PostId, string Path, string Filename, string page)
        {
            // DeletePost() deletes a Newspost using its id and redirects to the correct page (a filter might've been used beforehand).

            if (Path != null && Filename != null)
            {
                System.IO.File.Delete(Path + "/" + Filename);
                System.IO.Directory.Delete(Path);
            }

            await ConnectDb("MATCH(p:Post) WHERE p.PostId= " + PostId + " DETACH DELETE p");

            return RedirectToAction("FilteredNewsfeed", new { filter = page });
        }
        public string CheckFriendStatus(int PersonId, int FriendId)
        {
            var getStatus = ConnectDb2("MATCH(a:Person)-[r]->(b:Person) WHERE a.PersonId = " + PersonId + " AND b.PersonId = " + FriendId + " RETURN type(r)");
            string status = getStatus.Result;
            return status;
        }
        public string CheckFriendRequeststatus(int PersonId, int FriendId)
        {
            var res = "";
            var getStatus = ConnectDb2("MATCH(a:Person)-[r]->(b:Person) WHERE a.PersonId = " + FriendId + " AND b.PersonId = " + PersonId + " RETURN type(r)");
            string status = getStatus.Result;
            if (status == "FriendPending")
            {
                res = "requested";
            }
            if (status == "IsFriendsWith")
            {
                res = "Friends";
            }
            return res;
        }

        public List<Newspost> GetFeed()
        {
            // GetFeed() get all the posts (that don't belong to a group) and their creators from the database and puts them in a list of Newspost objects.

            List<INode> postNodes = new List<INode>();
            var getPosts = ConnectDb("MATCH(p:Post) WHERE NOT ()-[:HasPost]-(p) RETURN (p)");
            var post = new Newspost();
            List<Newspost> postList = new List<Newspost>();

            postNodes = getPosts.Result;
            foreach (var record in postNodes)
            {
                var nodeprops = JsonConvert.SerializeObject(record.As<INode>().Properties);
                post = (JsonConvert.DeserializeObject<Newspost>(nodeprops));

                DateTime datetime = DateTime.ParseExact(post.DateAdded.ToString(), "d-M-yyyy HH:mm:ss", new CultureInfo("nl-NL"));

                // Another query gets the related Persons to a post from the database thus finding its creator, the result is processed similarly.
                List<INode> creatorNode = new List<INode>();
                var getCreator = ConnectDb("MATCH(u:Person)-[:Posted]->(p:Post) WHERE p.PostId = " + post.PostId + " RETURN u");
                var creator = new Person();

                creatorNode = getCreator.Result;
                foreach (var person in creatorNode)
                {
                    var Personprops = JsonConvert.SerializeObject(person.As<INode>().Properties);
                    creator = (JsonConvert.DeserializeObject<Person>(Personprops));
                }

                // After getting al the required data, it is put into a Newspost object and added to the list of newsposts.
                postList.Add(new Newspost()
                {
                    PostId = post.PostId,
                    Title = post.Title,
                    Description = post.Description,
                    Creator = creator,
                    DateAdded = post.DateAdded,
                    TimeStamp = datetime,
                    Path = post.Path,
                    Filename = post.Filename
                }); ;
            }

            // The final list is put into a ordered list called feed, so the results will be displayed in the right order (newest first).
            List<Newspost> feed = postList.OrderByDescending(p => p.TimeStamp).ToList();
            return feed;
        }

        public List<Newspost> GetGroupPosts(string group)
        {
            // GetGroupPosts() gets all the posts that are posted in the chosen group (relationship type "HasPost") and their creators from the database and puts them in a list of Newspost objects.

            List<INode> postNodes = new List<INode>();
            var getPosts = ConnectDb("MATCH(g:Group)--(p:Post) WHERE g.GroupName = '" + group + "' RETURN p");
            var post = new Newspost();
            List<Newspost> postList = new List<Newspost>();

            postNodes = getPosts.Result;
            foreach (var record in postNodes)
            {
                var nodeprops = JsonConvert.SerializeObject(record.As<INode>().Properties);
                post = (JsonConvert.DeserializeObject<Newspost>(nodeprops));

                DateTime datetime = DateTime.ParseExact(post.DateAdded.ToString(), "d-M-yyyy HH:mm:ss", new CultureInfo("nl-NL"));

                // Another query gets the related Persons to a post from the database thus finding its creator, the result is processed similarly.
                List<INode> creatorNode = new List<INode>();
                var getCreator = ConnectDb("MATCH(u:Person)-[:Posted]->(p:Post) WHERE p.PostId = " + post.PostId + " RETURN u");
                var creator = new Person();

                creatorNode = getCreator.Result;
                foreach (var person in creatorNode)
                {
                    var Personprops = JsonConvert.SerializeObject(person.As<INode>().Properties);
                    creator = (JsonConvert.DeserializeObject<Person>(Personprops));
                }

                // After getting al the required data, it is put into a Newspost object and added to the list of newsposts.
                postList.Add(new Newspost()
                {
                    PostId = post.PostId,
                    Title = post.Title,
                    Description = post.Description,
                    Creator = creator,
                    DateAdded = post.DateAdded,
                    TimeStamp = datetime,
                    Path = post.Path,
                    Filename = post.Filename
                });

            }

            // The final list is put into a ordered list called feed, so the results will be displayed in the right order (newest first).
            List<Newspost> feed = postList.OrderByDescending(p => p.TimeStamp).ToList();
            return feed;
        }

        public List<Newspost> GetFriendPosts()
        {
            // GetFriendPosts() gets all the posts that are posted by the Persons' friends (relationship type "IsFriendsWith") and their creators from the database and puts them in a list of Newspost objects.
            // NOTE: Posts that a friends of the Person have posted in a group will NOT be fetched.

            List<INode> postNodes = new List<INode>();
            var getPosts = ConnectDb("MATCH(a:Person {PersonId:" + GetCurrentPerson().PersonId + "})-[:IsFriendsWith]-(b:Person)-[:Posted]->(p:Post) WHERE NOT (:Group)-[:HasPost]->(p) RETURN p");
            var post = new Newspost();
            List<Newspost> postList = new List<Newspost>();

            postNodes = getPosts.Result;
            foreach (var record in postNodes)
            {
                var nodeprops = JsonConvert.SerializeObject(record.As<INode>().Properties);
                post = (JsonConvert.DeserializeObject<Newspost>(nodeprops));

                DateTime datetime = DateTime.ParseExact(post.DateAdded.ToString(), "d-M-yyyy HH:mm:ss", new CultureInfo("nl-NL"));

                /// Another query gets the related Persons to a post from the database thus finding its creator, the result is processed similarly.
                List<INode> creatorNode = new List<INode>();
                var getCreator = ConnectDb("MATCH(u:Person)-[:Posted]->(p:Post) WHERE p.PostId = " + post.PostId + " RETURN u");
                var creator = new Person();

                creatorNode = getCreator.Result;
                foreach (var person in creatorNode)
                {
                    var Personprops = JsonConvert.SerializeObject(person.As<INode>().Properties);
                    creator = (JsonConvert.DeserializeObject<Person>(Personprops));
                }

                // After getting al the required data, it is put into a Newspost object and added to the list of newsposts.
                postList.Add(new Newspost()
                {
                    PostId = post.PostId,
                    Title = post.Title,
                    Description = post.Description,
                    Creator = creator,
                    DateAdded = post.DateAdded,
                    TimeStamp = datetime,
                    Path = post.Path,
                    Filename = post.Filename
                });

            }

            // The final list is put into a ordered list called feed, so the results will be displayed in the right order (newest first).
            List<Newspost> feed = postList.OrderByDescending(p => p.TimeStamp).ToList();
            return feed;
        }

        public List<GroupData> GetGroupById(int GroupId)
        {
            // GetGroupById() gets a Groups from the database using its id and puts all the info into a list of GroupData objects.

            List<INode> groupNodes = new List<INode>();
            var getGroups = ConnectDb("MATCH (g:Group) WHERE g.GroupId = " + GroupId + " RETURN g");
            var group = new GroupData();
            List<GroupData> groupList = new List<GroupData>();

            groupNodes = getGroups.Result;
            foreach (var record1 in groupNodes)
            {
                var nodeprops1 = JsonConvert.SerializeObject(record1.As<INode>().Properties);
                group = (JsonConvert.DeserializeObject<GroupData>(nodeprops1));

                // Another query gets all the Persons who are in the Group and puts them into a list of Person objects.
                List<INode> personNodes = new List<INode>();
                var getPersons = ConnectDb("MATCH (p:Person)-[r:IsInGroup]->(g:Group {GroupId: " + group.GroupId + "}) RETURN p");
                var person = new Person();
                List<Person> personList = new List<Person>();

                personNodes = getPersons.Result;
                foreach (var record2 in personNodes)
                {
                    var nodeprops2 = JsonConvert.SerializeObject(record2.As<INode>().Properties);
                    person = (JsonConvert.DeserializeObject<Person>(nodeprops2));

                    personList.Add(person);
                }
                List<Person> members = personList.OrderBy(p => p.FirstName).ThenBy(p => p.LastName).ToList();

                // After getting al the required data, it is put into a Group object and added to the list of groups.
                groupList.Add(new GroupData()
                {
                    GroupId = group.GroupId,
                    GroupName = group.GroupName,
                    Members = members
                });

            }

            // The final list is ordered by GroupName and put into a list called "final".
            List<GroupData> final = groupList.OrderBy(g => g.GroupName).ToList();
            return final;
        }

        public List<Group> GetGroups()
        {
            // GetGroups() gets all the groups the Person is part of or owns (relationship type "IsInGroup" or "IsOwner") from the database and puts them in a list of Group objects.

            List<INode> groupNodes = new List<INode>();
            var getGroups = ConnectDb("MATCH(p:Person)-[:IsInGroup|:IsOwner]->(g:Group) WHERE p.PersonId = " + GetCurrentPerson().PersonId + " RETURN DISTINCT g");
            var group = new Group();
            List<Group> groupList = new List<Group>();

            groupNodes = getGroups.Result;
            foreach (var record in groupNodes)
            {
                var nodeprops = JsonConvert.SerializeObject(record.As<INode>().Properties);
                group = (JsonConvert.DeserializeObject<Group>(nodeprops));

                // After getting al the required data, it is put into a Group object and added to the list of groups.
                groupList.Add(new Group()
                {
                    GroupId = group.GroupId,
                    GroupName = group.GroupName
                });

            }

            // The final list is ordered by GroupName and put into a list called "final".
            List<Group> final = groupList.OrderBy(g => g.GroupName).ToList();
            return final;
        }

        public List<GroupData> GetGroupsData()
        {
            /*  GetGroupsData() gets all the Persons' groups (relationship IsInGroup) from the database plus:
             *   - The creator of the group (relationship IsOwner)
             *   - All the members of the group (relationship IsInGroup)
            */

            // All the info is put into a seperate GroupsInfo object
            List<GroupData> groupsInfo = new List<GroupData>();


            // First, all the groups the Person is part of are fetched.
            List<INode> groupNodes = new List<INode>();
            var getGroups = ConnectDb("MATCH(p:Person)-[:IsInGroup|:IsOwner]->(g:Group) WHERE p.PersonId = " + GetCurrentPerson().PersonId + " RETURN DISTINCT g");
            var group = new Group();
            List<Group> groupList = new List<Group>();

            groupNodes = getGroups.Result;
            foreach (var record1 in groupNodes)
            {
                var nodeprops1 = JsonConvert.SerializeObject(record1.As<INode>().Properties);
                group = (JsonConvert.DeserializeObject<Group>(nodeprops1));

                // Second, the creator of the group is fetched and put into a Person object.
                List<INode> creatorNode = new List<INode>();
                var getCreator = ConnectDb("MATCH (p:Person) -[r:IsOwner]->(g:Group {GroupId: " + group.GroupId + "}) RETURN p");
                var creator = new Person();
                List<Person> creatorList = new List<Person>();

                creatorNode = getCreator.Result;
                foreach (var record2 in creatorNode)
                {
                    var nodeprops2 = JsonConvert.SerializeObject(record2.As<INode>().Properties);
                    creator = (JsonConvert.DeserializeObject<Person>(nodeprops2));
                }

                // Third, all the members of the group are fetched and put into a list of Person objects.
                List<INode> personNodes = new List<INode>();
                var getPersons = ConnectDb("MATCH (p:Person)-[r:IsInGroup]->(g:Group {GroupId: " + group.GroupId + "}) RETURN p");
                var person = new Person();
                List<Person> personList = new List<Person>();

                personNodes = getPersons.Result;
                foreach (var record3 in personNodes)
                {
                    var nodeprops3 = JsonConvert.SerializeObject(record3.As<INode>().Properties);
                    person = (JsonConvert.DeserializeObject<Person>(nodeprops3));

                    personList.Add(person);
                }
                List<Person> members = personList.OrderBy(p => p.FirstName).ThenBy(p => p.LastName).ToList();

                // Last, all the fetched information is put into a GroupData object and added to the list of GroupData objects.
                groupsInfo.Add(new GroupData()
                {
                    GroupId = group.GroupId,
                    GroupName = group.GroupName,
                    Creator = creator,
                    Members = members
                });
            }

            // The final list is ordered by GroupName and put into a list called "final".
            List<GroupData> final = groupsInfo.OrderBy(g => g.GroupName).ToList();
            return final;
        }

        public async Task<IActionResult> LeaveGroup(int GroupId)
        {
            // LeaveGroup() removes the current Person from the group (deletes relationship IsInGroup).

            await ConnectDb("MATCH (p:Person)-[r:IsInGroup]->(g:Group) WHERE p.PersonId = " + GetCurrentPerson().PersonId + " AND g.GroupId = " + GroupId + " DELETE r");

            return RedirectToAction("Groepen");
        }

        public List<Person> GetFriendsById()
        {

            List<INode> friendNodes = new List<INode>();
            var getFriends = ConnectDb("MATCH (a:Person {PersonId : " + GetCurrentPerson().PersonId + "}) - [r:IsFriendsWith]->(b:Person{}) RETURN b");
            var friend = new Person();
            List<Person> friendList = new List<Person>();

            friendNodes = getFriends.Result;
            foreach (var record in friendNodes)
            {
                var nodeprops = JsonConvert.SerializeObject(record.As<INode>().Properties);
                friend = (JsonConvert.DeserializeObject<Person>(nodeprops));

                // After getting al the required data, it is put into a Person object and added to the list of friends.
                friendList.Add(friend);

            }

            // The final list is ordered by FirstName and put into a list called "final".
            List<Person> final = friendList.OrderBy(p => p.FirstName).ThenBy(p => p.LastName).ToList();
            return final;
        }

        public List<Person> GetRelationsById(int id)
        {

            List<INode> friendNodes = new List<INode>();
            var getFriends = ConnectDb("MATCH (a:Person {PersonId : " + id.ToString() + "}) - [:IsFriendsWith| :FriendPending]-(b:Person{}) RETURN b");
            var friend = new Person();
            List<Person> friendList = new List<Person>();

            friendNodes = getFriends.Result;
            foreach (var record in friendNodes)
            {
                var nodeprops = JsonConvert.SerializeObject(record.As<INode>().Properties);
                friend = (JsonConvert.DeserializeObject<Person>(nodeprops));

                friendList.Add(friend);
            }

            List<Person> final = friendList.OrderBy(f => f.FirstName).ToList();
            return final;
        }

        public List<PersonInfo> GetPersonlist()
        {
            // GetPersonList() gets all the Persons except for the current Person from the database and puts them into a list of PersonInfo objects.

            List<INode> personNodes = new List<INode>();
            var getPersons = ConnectDb("MATCH(p:Person) WHERE NOT p.PersonId = " + GetCurrentPerson().PersonId + " RETURN p");
            var person = new Person();
            List<PersonInfo> personList = new List<PersonInfo>();

            personNodes = getPersons.Result;
            foreach (var record in personNodes)
            {
                var nodeprops = JsonConvert.SerializeObject(record.As<INode>().Properties);
                person = (JsonConvert.DeserializeObject<Person>(nodeprops));

                // After getting al the required data, it is put into a PersonInfo object and added to the list of persons.
                personList.Add(new PersonInfo()
                {
                    Person = person,
                    Status = CheckFriendStatus(person.PersonId)
                });
            }

            // The final list is ordered by FirstName and put into a list called "final".
            List<PersonInfo> final = personList.OrderBy(p => p.Person.FirstName).ThenBy(p => p.Person.LastName).ToList();
            return final;
        }

        public List<PersonInfo> GetFriends()
        {
            // GetFriends() gets all the Persons the Person is friends with (relationship type "IsFriendsWith") from the database and puts them in a list of Person objects.

            List<INode> friendNodes = new List<INode>();
            var getFriends = ConnectDb("MATCH(a:Person)-[:IsFriendsWith]-(b:Person) WHERE a.PersonId = " + GetCurrentPerson().PersonId + " RETURN b");
            var friend = new Person();
            List<PersonInfo> friendList = new List<PersonInfo>();

            friendNodes = getFriends.Result;
            foreach (var record in friendNodes)
            {
                var nodeprops = JsonConvert.SerializeObject(record.As<INode>().Properties);
                friend = (JsonConvert.DeserializeObject<Person>(nodeprops));

                // After getting al the required data, it is put into a PersonInfo object and added to the list of friends.
                friendList.Add(new PersonInfo()
                {
                    Person = friend,
                    Status = CheckFriendStatus(friend.PersonId)
                });
            }

            // The final list is ordered by FirstName and put into a list called final.
            List<PersonInfo> final = friendList.OrderBy(f => f.Person.FirstName).ThenBy(f => f.Person.LastName).ToList();
            return final;
        }

        public string CheckFriendStatus(int PersonId)
        {
            // CheckFriendStatus returns the relationship between the current Person and the Person requested by PersonId.

            var id = GetCurrentPerson().PersonId;
            var getStatus = ConnectDb2("MATCH(a:Person)-[r]-(b:Person) WHERE a.PersonId = " + id + " AND b.PersonId = " + PersonId + " RETURN type(r)");
            if (getStatus.Result == "FriendPending")
            {
                // If the relationship is FriendPending, another check determines whether the current Person is the one who sent the request.
                var requestCheck = ConnectDb2("MATCH(a:Person)-[r]->(b:Person) WHERE a.PersonId = " + PersonId + " AND b.PersonId = " + id + " RETURN type(r)");
                if (requestCheck.Result == "FriendPending")
                {

                    // If the current Person is the one who sent the request, the relationship string is expanded.
                    string status = requestCheck.Result + "Request";
                    return status;

                }
                else
                {
                    string status = getStatus.Result;
                    return status;
                }
            }
            else
            {
                string status = getStatus.Result;
                return status;
            }
        }

        public IActionResult Friend(int FriendId)
        {
            // Friend() uses AddFriend() to send a friendrequest and redirects back to the Personlist.

            if (AddFriend(GetCurrentPerson().PersonId, FriendId) == true)
            {
                return RedirectToAction("Personlist");
            }
            else
            {
                Console.WriteLine("Er is iets misgegaan.");
                return null;
            }
        }

        public Boolean AddFriend(int PersonId, int friendId)
        {
            // maybe add check for if they already are friends

            var Person = GetPerson(PersonId);
            var PersonPending = GetPerson(friendId);
            var Success = new Boolean();
            var Personid = Person.PersonId;
            var friendPersonid = PersonPending.PersonId;


            if (Personid == PersonId & friendId == friendPersonid)
            {
                var results = ConnectDb("MATCH (a:Person), (b:Person) WHERE a.PersonId = " + PersonId.ToString() + " AND b.PersonId = " + friendId.ToString() + " CREATE (a)-[r:FriendPending]->(b)" + " RETURN a");
                Success = true;
            }
            else
            {
                Success = false;
            }

            return Success;

        }

        public async Task<IActionResult> AcceptFriend(int PersonRequestedId, string page)
        {
            var PersonAcceptedId = GetCurrentPerson().PersonId;

            //delete relationship pending and add relation friendswith 
            await ConnectDb("MATCH (a:Person {PersonId : " + PersonRequestedId.ToString() + "}) - [r:FriendPending]->(b:Person{PersonId: " + PersonAcceptedId.ToString() + "}) DELETE r RETURN a");

            await ConnectDb("MATCH (a:Person), (b:Person) WHERE a.PersonId = " + PersonRequestedId.ToString() + " AND b.PersonId = " + PersonAcceptedId.ToString() + " CREATE (a)-[r:IsFriendsWith]->(b)" + " RETURN a");

            // var res2 = ConnectDb("MATCH (a:Person), (b:Person) WHERE a.PersonId = " + PersonAcceptedId.ToString() + " AND b.PersonId = " + PersonRequestedId.ToString() + " CREATE (a)-[r:IsFriendsWith]->(b)" + " RETURN a");
            // res2.Wait();
            return RedirectToAction(page, "Person");
        }

        public async Task<IActionResult> DeleteFriend(int FriendId, string page)
        {
            await ConnectDb("MATCH (a:Person {PersonId: " + GetCurrentPerson().PersonId + "})-[r:IsFriendsWith]-(b:Person {PersonId: " + FriendId + "}) DELETE r");

            return RedirectToAction("FilteredPersonlist", new { filter = page });
        }
        public async Task<IActionResult> RefuseFriendReq(int PersonId, string page)
        {
            await ConnectDb("MATCH (a:Person {PersonId: " + PersonId + "})-[r:FriendPending]-(b:Person {PersonId: " + GetCurrentPerson().PersonId + "}) DELETE r");

            return RedirectToAction(page, "Person");
        }

        public async Task<IActionResult> DeleteFriendProfile(int FriendId)
        {
            var PersonId = GetCurrentPerson().PersonId;

            await ConnectDb("MATCH (a:Person {PersonId: " + PersonId + "})-[r:IsFriendsWith]->(b:Person {PersonId: " + FriendId + "}) DELETE r");
            await ConnectDb("MATCH (a:Person {PersonId: " + FriendId + "})-[r:IsFriendsWith]->(b:Person {PersonId: " + PersonId + "}) DELETE r");

            return RedirectToAction("Profile");
        }

        public Person GetPerson(int PersonId)
        {
            List<INode> nodeList = new List<INode>();
            var results = ConnectDb("MATCH (a:Person) WHERE a.PersonId = " + PersonId.ToString() + " RETURN a");
            var Person = new Person();

            nodeList = results.Result;
            foreach (var record in nodeList)
            {
                var nodeprops = JsonConvert.SerializeObject(record.As<INode>().Properties);
                Person = (JsonConvert.DeserializeObject<Person>(nodeprops));
            }



            return Person;
        }

        public List<Group> GetOwnedGroups()
        {
            // GetOwnedGroups gets all the groups the Person owns and puts them into a list of Group object.

            List<INode> ownedGroupNodes = new List<INode>();
            var getOwnedGroups = ConnectDb("MATCH (g:Group) WHERE (:Person {PersonId: " + GetCurrentPerson().PersonId + "})-[:IsOwner]->(g) RETURN g");
            var group = new Group();
            List<Group> ownedGroupsList = new List<Group>();

            ownedGroupNodes = getOwnedGroups.Result;
            foreach (var record in ownedGroupNodes)
            {
                var nodeprops = JsonConvert.SerializeObject(record.As<INode>().Properties);
                group = (JsonConvert.DeserializeObject<Group>(nodeprops));

                // After getting al the required data, it is put into a Group object and added to the list of owned groups.
                ownedGroupsList.Add(new Group()
                {
                    GroupId = group.GroupId,
                    GroupName = group.GroupName
                });

            }

            // The final list is ordered by GroupName and put into a list called "final".
            List<Group> final = ownedGroupsList.OrderBy(g => g.GroupName).ToList();
            return final;
        }

        public List<GroepenManagen> GetGroupsManagement(int GroupId)
        {
            // GetGroupsManagement() gets the GroupData of a single group and the Persons who are not in the group from the database and puts it in a GroepenManagen object.

            List<GroepenManagen> groupsManagement = new List<GroepenManagen>();

            var getGroups = GetGroupById(GroupId);
            foreach (var record1 in getGroups)
            {
                // Getting all the Persons who are not in the group from the database and putting them into a list of Person objects.
                List<INode> nonmemberNodes = new List<INode>();
                var getNonMembers = ConnectDb("MATCH (p:Person) WHERE NOT (p)-[:IsInGroup]->(:Group {GroupId: " + record1.GroupId + "}) RETURN p");
                var nonMember = new Person();
                List<Person> personList = new List<Person>();

                nonmemberNodes = getNonMembers.Result;
                foreach (var record2 in nonmemberNodes)
                {
                    var nodeprops = JsonConvert.SerializeObject(record2.As<INode>().Properties);
                    nonMember = (JsonConvert.DeserializeObject<Person>(nodeprops));

                    personList.Add(nonMember);
                }

                // The list of non-members is sorted before being put into the final nonMemberList.
                List<Person> nonMemberList = personList.OrderBy(p => p.FirstName).ThenBy(p => p.LastName).ToList();

                // All the fetched data is put into a GroepenManagen object.
                groupsManagement.Add(new GroepenManagen()
                {
                    Group = record1,
                    NonMembers = nonMemberList
                });
            }

            return groupsManagement;
        }

        public async Task<IActionResult> DeleteGroup(int GroupId)
        {
            // DeleteGroup() deletes a group using its id.

            await ConnectDb("MATCH(g:Group) WHERE g.GroupId = " + GroupId + " DETACH DELETE g");

            return RedirectToAction("GroepenManagen");
        }

        public IActionResult AddPersonToGroup(int PersonId, int GroupId)
        {
            var res = ConnectDb("MATCH (a:Person), (b:Group) WHERE a.PersonId = " + PersonId.ToString() + " AND b.GroupId = " + GroupId.ToString() + " CREATE (a)-[r:IsInGroup]->(b)" + " RETURN a");
            res.Wait();

            return RedirectToAction("ManageGroup", new { GroupId });
        }

        public IActionResult DeletePersonFromGroup(int PersonId, int GroupId)
        {
            var res = ConnectDb("MATCH (a:Person {PersonId : " + PersonId.ToString() + "}) - [r:IsInGroup]->(b:Group{GroupId: " + GroupId.ToString() + "}) DELETE r RETURN a");
            res.Wait();

            return RedirectToAction("ManageGroup", new { GroupId });
        }

        public async Task<List<INode>> ConnectDb(string query)
        {
            Driver = CreateDriverWithBasicAuth("bolt://localhost:11005", "neo4j", "1234");
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

            Driver = CreateDriverWithBasicAuth("bolt://localhost:11005", "neo4j", "1234");
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