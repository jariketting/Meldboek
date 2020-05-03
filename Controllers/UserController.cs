using System;
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
<<<<<<< HEAD
using System.Xml;
=======
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
>>>>>>> origin/chat

namespace meldboek.Controllers
{
    public class UserController : Controller
    {
        public IDriver Driver { get; set; }

        public IActionResult Index()
        {
            return View();
        }
<<<<<<< HEAD
        [Route("User/GroepenManagen")]
        public IActionResult GroepenManagen()
        {
            return View();
        }
=======
>>>>>>> origin/chat
        public IActionResult CreateAccount(string firstname, string lastname, string email, string password, string password2)
        {
            if (firstname != null & lastname != null & email != null & password != null & password == password2)
            {
                User u = new User()
                {
                    FirstName = firstname,
                    LastName = lastname,
                    Email = email,
                    Password = password

                };
<<<<<<< HEAD
                var r = ConnectDb("CREATE (p:Person { FirstName: '" + u.FirstName + "', LastName: '" + u.LastName + "' ,Email: '" + u.Email + "', Password: '" + u.Password + "' }) RETURN p");
=======
                var r = ConnectDb("CREATE (p:User { FirstName: '" + u.FirstName + "', LastName: '" + u.LastName + "' ,Email: '" + u.Email + "', Password: '" + u.Password + "' }) RETURN p");
>>>>>>> origin/chat
                r.Wait();
                return View();
            }
            else
            {
                //password incorrect
                return View();
            }
<<<<<<< HEAD


        }
        public IActionResult LogIn(string email, string password)
        {
            List<INode> nodeList = new List<INode>();
            if (email != null & password != null)
            {
                var results = ConnectDb("MATCH (a:Person) WHERE a.Email = '" + email + "' AND a.Password =  '" + password + "' RETURN a");
                var user = new User();

                nodeList = results.Result;
                foreach (var record in nodeList)
                {
                    var nodeprops = JsonConvert.SerializeObject(record.As<INode>().Properties);
                    user = (JsonConvert.DeserializeObject<User>(nodeprops));
                }
                //   Console.WriteLine(user.Email.ToString());


                if (email == user.Email & password == user.Password)
                {
                    RedirectToAction("Profile", "UserController");
                    Console.WriteLine("Redirect to profile");
                }
                else
                {
                    RedirectToAction("CreateAccount", "UserController");
                    Console.WriteLine("Redirect to CreateAccount");

                }
            }

            return View();
        }

        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Newsfeed()
        {
            // Default page is page with filter "Algemeen", which displays all the posts that are not posted in a group.
            TempData["Page"] = "Algemeen";

            // Before returning the view of the newsfeed, all the newsposts and groups need to be pulled from the database.
            dynamic model = new ExpandoObject();
            model.Post = GetFeed();

            model.Group = GetGroups();
            model.Friend = GetFriends();
=======
        

        }
        public IActionResult Profile ()
        {
            return View();
        }

        public ActionResult Login(string email, string password)
        {
            if (email != null & password != null)
            {

                List<INode> nodeList = new List<INode>();
                var results = ConnectDb("MATCH (a:Person) WHERE a.Email = '" + email + "' AND a.Password =  '" + password + "' RETURN a");
                var user = new User();
                
                    nodeList = results.Result;
                    foreach (var record in nodeList)
                    {
                        var nodeprops = JsonConvert.SerializeObject(record.As<INode>().Properties);
                        user = (JsonConvert.DeserializeObject<User>(nodeprops));
                    }
                if (user.Email != null)
                {

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, "User", ClaimValueTypes.String),
                        new Claim(ClaimTypes.NameIdentifier, user.Email.ToString(), ClaimValueTypes.String),
                        new Claim(ClaimTypes.Role, "User", ClaimValueTypes.String)
                    };
                    var userIdentity = new ClaimsIdentity(claims, "SecureLogin");
                    var userPrincipal = new ClaimsPrincipal(userIdentity);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        userPrincipal,
                        new AuthenticationProperties
                        {
                            ExpiresUtc = DateTime.UtcNow.AddMinutes(30),
                            IsPersistent = true,
                            AllowRefresh = false
                        });

                    return RedirectToAction("Profile", "User");
                }
                else
                {
                    return RedirectToAction("CreateAccount", "User");
                }
            }
            return View();
        }
       

        //public  IActionResult LogInPage(string email, string password)
        //{
        //    return View();
        //}
        //public IActionResult LogIn(string email, string password)
        //{
        //    List<INode> nodeList = new List<INode>();
        //    var results = ConnectDb("MATCH (a:User) WHERE a.Email = '" + email + "' AND a.Password =  '" + password + "' RETURN a");
        //    var user = new User();

        //    nodeList = results.Result;
        //    foreach (var record in nodeList)
        //    {
        //        var nodeprops = JsonConvert.SerializeObject(record.As<INode>().Properties);
        //        user = (JsonConvert.DeserializeObject<User>(nodeprops));
        //    }
        //    Console.WriteLine(user.Email.ToString());
        //    if (email != null & password != null)
        //    {
        //        if (email == user.Email & password == user.Password)
        //        {
        //              RedirectToAction("Profile", "User");
        //        }
        //        else
        //        {
        //              RedirectToAction("Newsfeed", "User");
        //        }
        //    }
        //    else
        //    {
        //              RedirectToAction("CreateAccount", "User");
        //    }
        //    return View();
        //}





        public IActionResult Newsfeed()
        {
            // Before returning the view of the newsfeed, all the newsposts and groups need to be pulled from the database
            dynamic model = new ExpandoObject();
            model.Post = GetFeed();

            // model.Post = GetGroupPosts(); TODO: Filter aanbrengen op aanvraag.

            model.Group = GetGroups();
>>>>>>> origin/chat

            return View(model);
        }

<<<<<<< HEAD
        public IActionResult FilteredNewsfeed(string filter)
        {
            // FilteredNewsfeed returns a newsfeed with a filter depending on what the user chose.

            if (filter == "Algemeen")
            {
                // Filter "Algemeen" is the default value, so this redirects to the original state of the newsfeed.
                TempData["Page"] = filter;
                return RedirectToAction("Newsfeed");
            }
            else if (filter == "Vrienden")
            {
                // If the user chose the filter "Vrienden", GetFriendPosts() is used to get the correct posts.
                dynamic model = new ExpandoObject();

                model.Post = GetFriendPosts();

                model.Group = GetGroups();
                model.Friend = GetFriends();

                TempData["Page"] = filter;
                return View("Newsfeed", model);
            }
            else
            {
                // If the chosen filter is neither "Algemeen" or "Vrienden" the user has chosen a filter for group [groupname].
                dynamic model = new ExpandoObject();

                model.Post = GetGroupPosts(filter);

                model.Group = GetGroups();
                model.Friend = GetFriends();

                TempData["Page"] = filter;
                return View("Newsfeed", model);
            }
        }

        public int GetMaxPostId()
        {
            // GetMaxPostId gets the newspost with the highest id from the database and returns the id.

            List<INode> postNodes = new List<INode>();
            var getPosts = ConnectDb("MATCH(p:Post) RETURN p ORDER BY toInteger(p.PostId) DESC LIMIT 1");
            var post = new Newspost();

            postNodes = getPosts.Result;
            foreach (var record in postNodes)
            {
                var nodeprops = JsonConvert.SerializeObject(record.As<INode>().Properties);
                post = (JsonConvert.DeserializeObject<Newspost>(nodeprops));
            }

            return post.PostId;
        }

        public async Task<IActionResult> AddPost(string title, string description, string group)
        {
            // AddPost adds a newspost the user creates to the database. It takes the given title + description and adds the current time itself.

            // Getting the id of most recent post node, so a new id can be automatically added to the newly created newspost.
            int newid = GetMaxPostId() + 1;

            string date = DateTime.Now.ToString("dd-MM-yyyy");
            string time = DateTime.Now.ToString("HH:mm:ss");

            await ConnectDb("CREATE(p:Post {Title: '" + title + "', Description: '" + description + "', PostId: '" + newid + "', DateAdded: '" + date + "', TimeAdded: '" + time + "'})");

            // After adding the post to the database, a relationship is created between the post and the user who made it. | (Person-[Posted]->Post)
            await ConnectDb("MATCH(u:Person), (p:Post) WHERE u.FirstName = 'Amy' AND p.Title = '" + title + "' CREATE(u)-[r:Posted]->(p)");

            // If the chosen category is not "general", the user has chosen to post in a group they are part of.
            if (group != "Algemeen")
            {
                // Because the post is meant to be for a specific group, a relationship type "HasPost" is created between the group and the newspost.
                await ConnectDb("MATCH(g:Group), (p:Post) WHERE g.GroupName = '" + group + "' AND p.Title = '" + title + "' CREATE(g) -[r:HasPost]->(p)");
                return RedirectToAction("FilteredNewsfeed", new { filter = group });
            }

            return RedirectToAction("FilteredNewsfeed", new { filter = "Algemeen" });
        }

        public async Task<IActionResult> DeletePost(string postid, string page)
        {
            await ConnectDb("MATCH(p:Post) WHERE p.PostId= '" + postid + "' DETACH DELETE p");

            return RedirectToAction("FilteredNewsfeed", new { filter = page });
=======
        [HttpPost]
        public IActionResult AddPost(string title, string description, string postid, string group)
        {
            // AddPost adds a newspost the user creates to the database. It takes the given title + description and adds the current time itself.

            string Timestamp = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            ConnectDb("CREATE (p:Post {title: '" + title + "', description: '" + description + "', postid: '" + postid + "', dateadded: '" + Timestamp + "'})");

            // After adding the post to the database, a relationship is created between the post and the user who made it | (Person-[Posted]->Post)
            ConnectDb("MATCH (u:Person),(p:Post) WHERE u.FirstName = 'Amy' AND p.title = '" + title + "' CREATE(u)-[r:Posted]->(p)");

            if (group != "general")
            {
               ConnectDb("MATCH (g:Group), (p:Post) WHERE g.name = '" + group + "' AND p.title = '" + title + "' CREATE(g) -[r:HasPost]->(p)");
            }

            return RedirectToAction("Newsfeed");
>>>>>>> origin/chat
        }

        public List<Newspost> GetFeed()
        {
<<<<<<< HEAD
            // GetFeed() get all the posts (that don't belong to a group) and their creators from the database and puts them in a list of Newspost objects.

            List<INode> postNodes = new List<INode>();
            var getPosts = ConnectDb("MATCH(p:Post) WHERE NOT ()-[:HasPost]-(p) RETURN (p)");
=======
            // GetPosts() get all the posts and their creators from the database and puts them in a list of Newspost objects.

            List<INode> postNodes = new List<INode>();
            var getPosts = ConnectDb("MATCH (p:Post) RETURN (p)");
>>>>>>> origin/chat
            var post = new Newspost();
            List<Newspost> postList = new List<Newspost>();

            postNodes = getPosts.Result;
            foreach (var record in postNodes)
            {
                var nodeprops = JsonConvert.SerializeObject(record.As<INode>().Properties);
                post = (JsonConvert.DeserializeObject<Newspost>(nodeprops));

                // Another query gets the related users to a post from the database thus finding its creator, the result is processed similarly.
                List<INode> userList = new List<INode>();
<<<<<<< HEAD
                var getuser = ConnectDb("MATCH(p: Post)--(u: Person) WHERE p.Title = '" + post.Title + "' RETURN u");
=======
                var getuser = ConnectDb("MATCH(p: Post)--(u: Person) WHERE p.title = '" + post.Title + "' RETURN u");
>>>>>>> origin/chat
                var user = new User();

                userList = getuser.Result;
                foreach (var person in userList)
                {
                    var userprops = JsonConvert.SerializeObject(person.As<INode>().Properties);
                    user = (JsonConvert.DeserializeObject<User>(userprops));
                }

<<<<<<< HEAD
                // After getting al the required data, it is put into a Newspost object and added to the list of newsposts.
=======
                // After getting al the required data, it is put in Newspost object and added to the list of newsposts.
>>>>>>> origin/chat
                postList.Add(new Newspost()
                {
                    PostId = post.PostId,
                    Title = post.Title,
                    Description = post.Description,
                    DateAdded = post.DateAdded,
<<<<<<< HEAD
                    TimeAdded = post.TimeAdded,
=======
>>>>>>> origin/chat
                    FirstName = user.FirstName,
                    LastName = user.LastName
                });

            }

            // The final list is put into a ordered list called feed, so the results will be displayed in the right order (newest first).
<<<<<<< HEAD
            List<Newspost> feed = postList.OrderBy(p => p.DateAdded).ThenByDescending(p => p.TimeAdded).ToList();
            return feed;
        }

        public List<Newspost> GetGroupPosts(string group)
        {
            // GetGroupPosts() gets all the posts that are posted in the chosen group (relationship type "HasPost") and their creators from the database and puts them in a list of Newspost objects.
            
            List<INode> postNodes = new List<INode>();
            var getPosts = ConnectDb("MATCH(g:Group)--(p:Post) WHERE g.GroupName = '" + group + "' RETURN p");
=======
            List<Newspost> feed = postList.OrderByDescending(p => p.DateAdded).ToList();
            //return View(feed);
            return feed;
        }

        public List<Newspost> GetGroupPosts()
        {
            List<INode> postNodes = new List<INode>();
            var getPosts = ConnectDb("MATCH(g: Group)--(p: Post) WHERE g.name = 'rdam' RETURN p");
>>>>>>> origin/chat
            var post = new Newspost();
            List<Newspost> postList = new List<Newspost>();

            postNodes = getPosts.Result;
            foreach (var record in postNodes)
            {
                var nodeprops = JsonConvert.SerializeObject(record.As<INode>().Properties);
                post = (JsonConvert.DeserializeObject<Newspost>(nodeprops));

                // Another query gets the related users to a post from the database thus finding its creator, the result is processed similarly.
                List<INode> userList = new List<INode>();
<<<<<<< HEAD
                var getuser = ConnectDb("MATCH(p:Post)--(u:Person) WHERE p.Title = '" + post.Title + "' RETURN u");
=======
                var getuser = ConnectDb("MATCH(p: Post)--(u: Person) WHERE p.title = '" + post.Title + "' RETURN u");
>>>>>>> origin/chat
                var user = new User();

                userList = getuser.Result;
                foreach (var person in userList)
                {
                    var userprops = JsonConvert.SerializeObject(person.As<INode>().Properties);
                    user = (JsonConvert.DeserializeObject<User>(userprops));
                }

<<<<<<< HEAD
                // After getting al the required data, it is put into a Newspost object and added to the list of newsposts.
=======
                // After getting al the required data, it is put in Newspost object and added to the list of newsposts.
>>>>>>> origin/chat
                postList.Add(new Newspost()
                {
                    PostId = post.PostId,
                    Title = post.Title,
                    Description = post.Description,
                    DateAdded = post.DateAdded,
<<<<<<< HEAD
                    TimeAdded = post.TimeAdded,
=======
>>>>>>> origin/chat
                    FirstName = user.FirstName,
                    LastName = user.LastName
                });

            }

            // The final list is put into a ordered list called feed, so the results will be displayed in the right order (newest first).
<<<<<<< HEAD
            List<Newspost> feed = postList.OrderBy(p => p.DateAdded).ThenByDescending(p => p.TimeAdded).ToList();

            return feed;
        }

        public List<Newspost> GetFriendPosts()
        {
            // GetFriendPosts() gets all the posts that are posted by the users' friends (relationship type "IsFriendsWith") and their creators from the database and puts them in a list of Newspost objects.
            // NOTE: Posts that a friends of the user have posted in a group will NOT be fetched.

            List<INode> postNodes = new List<INode>();
            var getPosts = ConnectDb("MATCH(a:Person {FirstName:'Amy'})--(b:Person)--(p:Post) WHERE NOT ()-[:HasPost]-(p) RETURN p");
            var post = new Newspost();
            List<Newspost> postList = new List<Newspost>();

            postNodes = getPosts.Result;
            foreach (var record in postNodes)
            {
                var nodeprops = JsonConvert.SerializeObject(record.As<INode>().Properties);
                post = (JsonConvert.DeserializeObject<Newspost>(nodeprops));

                // Another query gets the related users to a post from the database thus finding its creator, the result is processed similarly.
                List<INode> userList = new List<INode>();
                var getuser = ConnectDb("MATCH(p:Post)--(u:Person) WHERE p.Title = '" + post.Title + "' RETURN u");
                var user = new User();

                userList = getuser.Result;
                foreach (var person in userList)
                {
                    var userprops = JsonConvert.SerializeObject(person.As<INode>().Properties);
                    user = (JsonConvert.DeserializeObject<User>(userprops));
                }

                // After getting al the required data, it is put into a Newspost object and added to the list of newsposts.
                postList.Add(new Newspost()
                {
                    PostId = post.PostId,
                    Title = post.Title,
                    Description = post.Description,
                    DateAdded = post.DateAdded,
                    TimeAdded = post.TimeAdded,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                });

            }

            // The final list is put into a ordered list called feed, so the results will be displayed in the right order (newest first).
            List<Newspost> feed = postList.OrderBy(p => p.DateAdded).ThenByDescending(p => p.TimeAdded).ToList();
=======
            List<Newspost> feed = postList.OrderByDescending(p => p.DateAdded).ToList();
            //return View(feed);
>>>>>>> origin/chat
            return feed;
        }

        public List<Group> GetGroups()
        {
<<<<<<< HEAD
            // GetGroups() gets all the groups the user is part of (relationship type "IsInGroup") from the database and puts them in a list of Group objects.

=======
>>>>>>> origin/chat
            List<INode> groupNodes = new List<INode>();
            var getGroups = ConnectDb("MATCH(u:Person)--(g:Group) WHERE u.FirstName = 'Amy' RETURN g");
            var group = new Group();
            List<Group> groupList = new List<Group>();

            groupNodes = getGroups.Result;
            foreach (var record in groupNodes)
            {
                var nodeprops = JsonConvert.SerializeObject(record.As<INode>().Properties);
                group = (JsonConvert.DeserializeObject<Group>(nodeprops));

<<<<<<< HEAD
                // After getting al the required data, it is put into a Group object and added to the list of groups.
                groupList.Add(new Group()
                {

=======
                // After getting al the required data, it is put in Newspost object and added to the list of newsposts.
                groupList.Add(new Group()
                {
                    GroupId = group.GroupId,
>>>>>>> origin/chat
                    GroupName = group.GroupName
                });

            }

<<<<<<< HEAD
            // The final list is ordered by GroupName and put into a list called "final".
            List<Group> final = groupList.OrderBy(g => g.GroupName).ToList();
            return final;
        }

        public List<User> GetFriends()
        {
            // GetFriends() gets all the users the user is friends with (relationship type "IsFriendsWith") from the database and puts them in a list of User objects.
            // NOTE: This function is currently unused, but might come in handy for future functionalities.

            List<INode> friendNodes = new List<INode>();
            var getFriends = ConnectDb("MATCH(a:Person)--(b:Person) WHERE a.FirstName = 'Amy' RETURN b");
            var friend = new User();
            List<User> friendList = new List<User>();

            friendNodes = getFriends.Result;
            foreach (var record in friendNodes)
            {
                var nodeprops = JsonConvert.SerializeObject(record.As<INode>().Properties);
                friend = (JsonConvert.DeserializeObject<User>(nodeprops));

                // After getting al the required data, it is put into a User object and added to the list of friends.
                friendList.Add(new User()
                {
                    UserId = friend.UserId,
                    FirstName = friend.FirstName,
                    LastName = friend.LastName,
                    Email = friend.Email
                });

            }

            // The final list is ordered by FirstName and put into a list called "final".
            List<User> final = friendList.OrderBy(f => f.FirstName).ToList();
=======
            // The final list is put into a ordered list called feed, so the results will be displayed in the right order (newest first).
            List<Group> final = groupList.ToList();
>>>>>>> origin/chat
            return final;
        }

        public Boolean AddFriend(int userId, int friendId)
        {
            // maybe add check for if they already are friends

            var user = GetUser(userId);
            var userPending = GetUser(friendId);
            var Success = new Boolean();
            var userid = user.UserId;
            var frienduserid = userPending.UserId;
            Console.WriteLine(userid.ToString());
            Console.WriteLine(frienduserid.ToString());

            if (userid == userId & friendId == frienduserid)
            {
                var results = ConnectDb("MATCH (a:Person), (b:Person) WHERE a.UserId = " + userId.ToString() + " AND b.UserId = " + friendId.ToString() + " CREATE (a)-[r:FriendPending]->(b)" + " RETURN a");
                Success = true;
            }
            else
            {
                Success = false;
            }

            return Success;

        }

        public void AcceptFriend(User userRequested, User userAccepted)
        {
            var res = ConnectDb("MATCH (a:Person), (b:Person) WHERE a.UserId = " + userRequested.UserId.ToString() + " AND b.UserId = " + userAccepted.UserId.ToString() + " CREATE (a)-[r:IsFriendsWith]->(b)" + " RETURN a");
            res.Wait();
        }

        public User GetUser(int userId)
        {
            List<INode> nodeList = new List<INode>();
            var results = ConnectDb("MATCH (a:Person) WHERE a.UserId = " + userId.ToString() + " RETURN a");
            var user = new User();

            nodeList = results.Result;
            foreach (var record in nodeList)
            {
                var nodeprops = JsonConvert.SerializeObject(record.As<INode>().Properties);
                user = (JsonConvert.DeserializeObject<User>(nodeprops));
            }



            return user;
        }

<<<<<<< HEAD
        public IActionResult AddUserToGroup(int userId, int groupId)
        {
            var res = ConnectDb("MATCH (a:Person), (b:Group) WHERE a.UserId = " + userId.ToString() + " AND b.GroupId = " + groupId.ToString() + " CREATE (a)-[r:IsInGroup]->(b)" + " RETURN a");
            res.Wait();
            return RedirectToAction("GroepenManagen", "User");

        }
        public IActionResult DeleteUserFromGroup(int userId, int groupId)
        {
            var res = ConnectDb("MATCH (a:Person {UserId : " + userId.ToString() + "}) - [r:IsInGroup]->(b:Group{GroupId: " + groupId.ToString() + "}) DELETE r RETURN a");
            res.Wait();
            return RedirectToAction("GroepenManagen", "User");

=======
        public void AddUserToGroup(int userId, int groupId)
        {
            var res = ConnectDb("MATCH (a:Person), (b:Group) WHERE a.UserId = " + userId.ToString() + " AND b.GroupId = " + groupId.ToString() + " CREATE (a)-[r:IsInGroup]->(b)" + " RETURN a");
            res.Wait();
        }
        public void DeleteUserFromGroup(int userId, int groupId)
        {
            var res = ConnectDb("MATCH (a:Person {UserId : " + userId.ToString() + "}) - [r:IsInGroup]->(b:Group{GroupId: " + groupId.ToString() + "}) DELETE r RETURN a");
            res.Wait();
>>>>>>> origin/chat
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




        public IDriver CreateDriverWithBasicAuth(string uri, string user, string password)
        {
            return GraphDatabase.Driver(new Uri(uri), AuthTokens.Basic(user, password));
        }


    }
}