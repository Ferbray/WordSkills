using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ZMQP.Classes
{
    class DataBase
    {
        public static int ID;
        public static string Login;
        public static string GameTitle;
        //Строка подключения (ШАБЛОН: Data Source=Имя сервера; Initial Catalog=Имя базы данных; Integrated Security: True (Проверка подлинности))
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-UGB2T6S; Initial Catalog=ZMQP; Integrated Security=True");
        //Открываем подключение
        public void openConnection()
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
        }
        //Закрываем подключение
        public void closeConnection()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }
        //Регистрируем нового пользователя
        public bool createNewUser(string login, string email, string password)
        {
            bool isExist = false;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = $"SELECT * FROM Users";
            cmd.Connection = conn;

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string name = reader.GetString(1);
                string emaildb = reader.GetString(2);

                if (name == login || emaildb == email)
                {
                    isExist = true;
                    break;
                }
            }

            if (!isExist)
            {
                reader.Close();
                cmd.CommandText = $"INSERT INTO Users (Login, Email, Password) VALUES ('{login}', '{email}', '{password}')";
                cmd.ExecuteNonQuery();
            }
            
            return isExist;
        }
        //Проверка введеных данных
        public bool VerificationUser(string login, string password)
        {

            bool isExist = false;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = $"SELECT * FROM Users";
            cmd.Connection = conn;

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader["Login"].ToString();
                string pass = reader["Password"].ToString();

                if (name == login && pass == password)
                {
                    ID = id;
                    Login = name;
                    isExist = true;
                    break;
                }
            }

            reader.Close();

            return isExist;
        }

       
        public void GoOnline()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = $"UPDATE Profile SET Status=4 WHERE IDUser='{ID}'";
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
        }
        //Возвращает количество пользователей
        public int CountUsers()
        {
            int count = 0;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = $"SELECT COUNT (*) FROM Users";
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            string res = cmd.ExecuteScalar().ToString();
            count = int.Parse(res);
            return count;
        }

        public string[] Users()
        {
            int j = -1;
            int i = CountUsers();
            string[] res = new string[i];

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = $"SELECT Login FROM Users";
            cmd.Connection = conn;

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string login = reader["Login"].ToString();
                res[j + 1] = login;

                j += 1;
            }
            return res;
        }

        public int CountGames()
        {
            int count = 0;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = $"SELECT COUNT (*) FROM Games";
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            string res = cmd.ExecuteScalar().ToString();
            count = int.Parse(res);
            return count;
        }

        public string[] Games()
        {
            int g = -1;
            int i = CountGames();
            string[] res = new string[i];

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = $"SELECT * FROM Games";
            cmd.Connection = conn;

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                
                string elem = "";

                string company = reader["TitleCompany"].ToString();
                string game = reader["TitleGame"].ToString();
                string photo = reader["Photo"].ToString();
                string description = reader["Description"].ToString();
                string type = reader["Type"].ToString();
                string link = reader["DownloadLink"].ToString();

                elem += company + "|";
                elem += game + "|";
                elem += photo + "|";
                elem += description + "|";
                elem += type + "|";
                elem += link + "|";



                g += 1;

                res[g] = elem;
            }
            return res;
        }

        public void SetChoosenGame(string title)
        {
            DataBase.GameTitle = title;
        }

        public void GoOffline()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = $"UPDATE Profile SET Status=0 WHERE IDUser='{ID}'";
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
        }
    }
}
