using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Shapes;
namespace ZMQP.Classes
{
public class Getter
    {
        public static int GetFriendStatus(int id)
        {
            using (UserContext db = new UserContext())
            {

                var users = db.Users;
                foreach (var user in users)
                {
                    if (user.ID == id)
                    {
                        return user.status;
                    }
                }
            }

            return 2;
        }
        public static int GetFriendId(string login)
        {
            using (UserContext db = new UserContext())
            {

                var users = db.Users;
                foreach (var user in users)
                {
                    if (user.ID == int.Parse(login.Remove(0, 2)))
                    {
                        return user.ID;
                    }
                }
            }

            return 0;
        }

        public static string GetNameFriend(int id)
        {
            UserContext uc = new UserContext();
            var users = uc.Users.ToList();
            foreach (var user in users)
            {
                if (user.ID == id)
                {
                    return user.Login;
                }
            }

            return "Unknown";
        }

        public static string GetDescriptionFriend(int id)
        {
            UserContext uc = new UserContext();
            var users = uc.Users.ToList();
            foreach (var user in users)
            {
                if (user.ID == id)
                {
                    return user.Description;
                }
            }

            return "Unknown";
        }

        public static string GetProfilePhoto(int id)
        {
            string photopath = "unknown";
            using (UserContext db = new UserContext())
            {
                var users = db.Users;
                foreach (User u in users)
                {
                    if (id == u.ID)
                    {
                        photopath = u.Photo;
                        break;
                    }
                }
            }
            return photopath;
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

        public static void RememberMe()
{
            using (StreamWriter writer = new StreamWriter(Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.Length - 9) + "userdata/config.ini", false))
            {
                writer.WriteLine(Classes.Hndr.id);
                writer.WriteLine(Classes.Hndr.login);
                writer.WriteLine(Classes.Hndr.photo);
            }
        }

        public static void ForgetMe()
        {
            using (StreamWriter writer = new StreamWriter(Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.Length - 9) + "userdata/config.ini", false))
            {
                writer.Write("");
            }
        }

        public static void RememberFunc()
        {
            using (StreamReader reader = new StreamReader(Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.Length - 9) + "userdata/config.ini", false))
            {
                Classes.Hndr.id = int.Parse(reader.ReadLine());
                Classes.Hndr.login = reader.ReadLine();
                Classes.Hndr.photo = reader.ReadLine();
            }
        }

        public static void DownloadGame(string title, string path, string executeFile)
        {
            using (FileStream fstream = new FileStream(Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.Length - 9) + "userdata/games.ini", FileMode.OpenOrCreate))
            {
                byte[] input = Encoding.Default.GetBytes($"{title} &*^, {path} &*^, {executeFile}" + Environment.NewLine);
                fstream.Seek(0, SeekOrigin.End);
                fstream.Write(input, 0, input.Length);
            }
        }

        public static bool IsDownload(string title)
        {
            using (StreamReader reader = new StreamReader(Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.Length - 9) + "userdata/games.ini", false))
            {
                string line;
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    if (line.Split(new string[] { "&*^" }, StringSplitOptions.None)[0].Contains(title)) 
                    {
                        return true;
                            }
                }
                return false;
            }
        }
    }


}
