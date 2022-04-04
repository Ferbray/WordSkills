using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ZMQPServer.Classes
{
    class Handler
    {

        //public static Dictionary<int, Delegate> dict = new Dictionary<int, Delegate>();
        
        public static bool CheckIndenticalUser(string user, string password)
        {
            using (UserContext db = new UserContext())
            {
                var users = db.Users;
                foreach (User u in users)
                {
                    if (
                        u.Login == user && password == u.Password)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public static void SaveChanges(string photo, int id, string login, string description)
        {
           
            using (UserContext db = new UserContext())
            {
                var users = db.Users;
                foreach (var user in users)
                {
                    if (user.ID == id)
                    {
                        user.Login = login;
                        user.Description = description;
                        user.Photo = user.Photo != photo ?  photo: user.Photo;
                        break;
                    }
                }

                db.SaveChanges();
            }
        }

        public static bool CheckIndenticalUserRegisration(string user, string email)
        {
            using (UserContext db = new UserContext())
            {
                var users = db.Users;
                foreach (User u in users)
                {
                    if (
                        u.Login == user && email == u.Email)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        public static int GetID(string login)
        {
            int id = 0;
            using (UserContext db = new UserContext())
            {
                var users = db.Users;
                foreach (User u in users)
                {
                    if (u.Login == login)
                    {
                        id = u.ID;
                        break;
                    }
                }
            }
            return id;
        }
        public static string GetLogin(int id)
        {
            using (UserContext db = new UserContext())
            {
                var users = db.Users;
                foreach (User u in users)
                {
                    if (u.ID == id)
                    {
                        return u.Login;
                    }
                }
            }
            return "Unknown";
        }

        public static string GetFriend(int id)
        {
            string friend = "";
            using (FriendshipContext db = new FriendshipContext())
            {
                var users = db.Friendships;
                foreach (Friendship u in users)
                {
                    if (u.IDUser == id)
                    {
                        friend += u.IDFriend.ToString() + "|";
                    }
                }
            }
            return friend;
        }

        public static string CountUsers()
        {
            string login = "";
            using (UserContext db = new UserContext())
            {
                var users = db.Users;
                foreach (User u in users)
                {
                    login += u.ID.ToString() + "|";
                }
            }
            return login;
        }

        public static void RemoveFriend(int id, int friendId)
        {
            using (FriendshipContext db = new FriendshipContext())
            {
                var friends = db.Friendships;
                foreach (var friend in friends)
                {
                    if (id == friend.IDUser && friendId == friend.IDFriend)
                    {
                        db.Friendships.Remove(friend);
                    }
                }
                db.SaveChanges();
            }
        }

        public static void SendRequest(int id, int friendId)
        {
            using (RequestsContext db = new RequestsContext())
            {
                Request request = new Request();
                request.IDUser = id;
                request.IDFriend = friendId;
                db.Requests.Add(request);
                db.SaveChanges();
            }
        }

        public static void AcceptFriend(int idUser, int idFriend)
        {
            using (FriendshipContext db = new FriendshipContext())
            {

                Friendship friendshipUser = new Friendship();
                friendshipUser.IDUser = idUser;
                friendshipUser.IDFriend = idFriend;

                db.Friendships.Add(friendshipUser);

                Friendship friendshipSender = new Friendship();
                friendshipSender.IDUser = idFriend;
                friendshipSender.IDFriend = idUser;
                db.Friendships.Add(friendshipSender);
                db.SaveChanges();
                using (RequestsContext req = new RequestsContext())
                {
                    var friends = req.Requests;
                    foreach (var friend in friends)
                    {
                        if (idUser == friend.IDFriend && idFriend == friend.IDUser)
                        {
                            req.Requests.Remove(friend);
                        }
                    }
                    req.SaveChanges();
                }

            }
        }

        public static void DeleteRequest(int idUser, int idFriend)
        {
            using (RequestsContext db = new RequestsContext())
            {
                var friends = db.Requests;
                foreach (var friend in friends)
                {
                    if (idUser == friend.IDFriend && idFriend == friend.IDUser)
                    {
                        db.Requests.Remove(friend);
                    }
                }
                db.SaveChanges();
            }
        }

        public static void DeclineFriend(int idUser, int idFriend)
        {
            using (RequestsContext db = new RequestsContext())
            {
                var friends = db.Requests;
                foreach (var friend in friends)
                {
                    if (idUser == friend.IDUser && idFriend == friend.IDFriend)
                    {
                        db.Requests.Remove(friend);
                    }
                }
                db.SaveChanges();
            }
        }

        public static int GetStatus(int id)
        {
            int status = 0;
            using (UserContext db = new UserContext())
            {
                var users = db.Users;
                foreach (User u in users)
                {
                    if (u.ID == id)
                    {
                        status = u.status;
                        break;
                    }
                }
            }
            return status;
        }

        public static string GetDescription(int id)
        {
            string description = "unknown";
            using (UserContext db = new UserContext())
            {
                var users = db.Users;
                foreach (User u in users)
                {
                    if (u.ID == id)
                    {
                        description = u.Description;
                        break;
                    }
                }
            }
            return description;
        }

        public static bool isExistLogin(string login, string oldLogin)
        {

            using (UserContext db = new UserContext())
            {
                var users = db.Users;
                foreach (var user in users)
                {
                    if (user.Login == login && user.Login != oldLogin)
                    {
                        return true;
                    }
                }
            }

            return false;

        }

        public static bool isExistFriendship(int idUser, int idFriend)
        {

            using (FriendshipContext db = new FriendshipContext())
            {
                var users = db.Friendships;
                foreach (var user in users)
                {
                    if (user.IDUser == idUser && user.IDFriend != idFriend)
                    {
                        return true;
                    }
                }
            }

            return false;

        }

        public static bool isExistRequests(int idUser, int idFriend)
        {

            using (RequestsContext db = new RequestsContext())
            {
                var friends = db.Requests;

                foreach (var friend in friends)
                {
                    if (friend.IDUser == idUser && idFriend == friend.IDFriend)
                    {
                        return true;
                    }
                }

                return false;
            }

        }


        public static string GetRequests(int id)
        {
            string requests = "";
            using (RequestsContext db = new RequestsContext())
            {
                var friends = db.Requests;

                foreach (var friend in friends)
                {
                    if (friend.IDUser == id)
                    {
                        requests += friend.IDFriend + "|";
                    }
                }

                
            }
            return requests;
        }

        public static string GetResponse(int id)
        {
            string requests = "";
            using (RequestsContext db = new RequestsContext())
            {
                var friends = db.Requests;

                foreach (var friend in friends)
                {
                    if (friend.IDFriend == id)
                    {
                        requests += friend.IDUser + "|";
                    }
                }

                
            }
            return requests;
        }

        public static void SetActiveStatus(int id)
        {
            {
                using (UserContext db = new UserContext())
                {
                    var users = db.Users;
                    foreach (var user in users)
                    {
                        if (id == user.ID)
                        {
                            user.status = 1;
                        }
                    }
                    db.SaveChanges();
                }
            }
        }


        public static string GetProfileImage(int id)
        {
            using (UserContext db = new UserContext())
            {
                string path = "";
                var users = db.Users;
                foreach (var user in users)
                {
                    if (id == user.ID)
                    {
                        path = user.Photo;

                        return path;
                    }
                }
                return "Unknown";
                
            }
        }

        public static void RegistrateUser(string login, string email, string password)
        {
            using (UserContext db = new UserContext())
            {
                User user1 = new User
                {
                    Login = login,
                    Email = email,
                    Password = password,
                    isAdmin = 0,
                    Description = "No bio yet",
                    Photo = Convert.ToBase64String(File.ReadAllBytes(Environment.CurrentDirectory + @"\" + @"static\profilelogo\default.png"))
                };
                db.Users.Add(user1);
                db.SaveChanges();
            }
        }

        public static void SetInactiveStatus(int id)
        {
            {
                using (UserContext db = new UserContext())
                {
                    var users = db.Users;
                    foreach (var user in users)
                    {
                        if (id == user.ID)
                        {
                            user.status = 0;
                        }
                    }
                    db.SaveChanges();
                }
            }
        }
    }
}
