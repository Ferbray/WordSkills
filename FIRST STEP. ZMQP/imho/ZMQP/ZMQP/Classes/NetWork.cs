using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using ZMQP.Windows;


namespace ZMQP.Classes
{
    class NetWork
    {
        // 0
        public static bool CheckConnection()
        {
            try
            {
                const string ip = "127.0.0.1";
                const int port = 8080;

                var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

                var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                var message = $"0| {System.Net.Dns.GetHostName()} | {System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList[1]} | {port}";

                var data = Encoding.UTF8.GetBytes(message);


                tcpSocket.Connect(tcpEndPoint);
                tcpSocket.Send(data);


                var buffer = new byte[256];
                var size = 0;
                string answer;

                do
                {
                    size = tcpSocket.Receive(buffer);
                    answer = Encoding.UTF8.GetString(buffer, 0, size);
                }
                while (tcpSocket.Available > 0);

                tcpSocket.Shutdown(SocketShutdown.Both);
                tcpSocket.Close();

                return true;
            }
            catch
            {
                return false;
            }

        }
        // 1
        public static bool CheckProfile(string login, string password)
        {
            try
            {
                const string ip = "127.0.0.1";
                const int port = 8080;

                var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

                var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                var message = $"1|{login}|{password}";

                var data = Encoding.UTF8.GetBytes(message);


                tcpSocket.Connect(tcpEndPoint);
                tcpSocket.Send(data);


                var buffer = new byte[256];
                var size = 0;
                string answer;

                do
                {
                    size = tcpSocket.Receive(buffer);
                    answer = Encoding.UTF8.GetString(buffer, 0, size);
                }
                while (tcpSocket.Available > 0);

                tcpSocket.Shutdown(SocketShutdown.Both);
                tcpSocket.Close();


                if (answer == "Succeed!")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }
        // 2
        public static bool CheckProfileRegistration(string login, string email, string password)
        {
            try
            {
                const string ip = "127.0.0.1";
                const int port = 8080;

                var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

                var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                var message = $"2|{login}|{email}|{password}";

                var data = Encoding.UTF8.GetBytes(message);


                tcpSocket.Connect(tcpEndPoint);
                tcpSocket.Send(data);


                var buffer = new byte[256];
                var size = 0;
                string answer;

                do
                {
                    size = tcpSocket.Receive(buffer);
                    answer = Encoding.UTF8.GetString(buffer, 0, size);
                }
                while (tcpSocket.Available > 0);

                tcpSocket.Shutdown(SocketShutdown.Both);
                tcpSocket.Close();


                if (answer == "Succeed!")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }
        // 3
        public static int GetID(string login)
        {
            try
            {
                const string ip = "127.0.0.1";
                const int port = 8080;

                var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

                var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                var message = $"3|{login}";

                var data = Encoding.UTF8.GetBytes(message);


                tcpSocket.Connect(tcpEndPoint);
                tcpSocket.Send(data);


                var buffer = new byte[256];
                var size = 0;
                string answer;

                do
                {
                    size = tcpSocket.Receive(buffer);
                    answer = Encoding.UTF8.GetString(buffer, 0, size);
                }
                while (tcpSocket.Available > 0);

                tcpSocket.Shutdown(SocketShutdown.Both);
                tcpSocket.Close();


                return int.Parse(answer);
            }
            catch
            {
                return 0;
            }
        }
        // 4
        public static string GetProfileImage(string id)
        {
            try
            {
                const string ip = "127.0.0.1";
                const int port = 8080;

                var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

                var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                var message = $"4|{id}";

                var data = Encoding.UTF8.GetBytes(message);


                tcpSocket.Connect(tcpEndPoint);
                tcpSocket.Send(data);


                var buffer = new byte[10000000];
                var size = 0;
                string answer;

                do
                {
                    size = tcpSocket.Receive(buffer);
                    answer = Encoding.UTF8.GetString(buffer, 0, size);
                }
                while (tcpSocket.Available > 0);

                tcpSocket.Shutdown(SocketShutdown.Both);
                tcpSocket.Close();


                return answer;
            }
            catch
            {
                return "unknown";
            }
        }
        // 5
        public static void SetActiveStatus(int id)
        {
            try
            {
                const string ip = "127.0.0.1";
                const int port = 8080;

                var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

                var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                var message = $"5|{id}";

                var data = Encoding.UTF8.GetBytes(message);


                tcpSocket.Connect(tcpEndPoint);
                tcpSocket.Send(data);


                var buffer = new byte[256];
                var size = 0;
                string answer;

                do
                {
                    size = tcpSocket.Receive(buffer);
                    answer = Encoding.UTF8.GetString(buffer, 0, size);
                }
                while (tcpSocket.Available > 0);

                tcpSocket.Shutdown(SocketShutdown.Both);
                tcpSocket.Close();

            }
            catch
            {
                
            }
        }
        //6
        public static void SetInactiveStatus(int id)
        {
            try
            {
                const string ip = "127.0.0.1";
                const int port = 8080;

                var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

                var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                var message = $"6|{id}";

                var data = Encoding.UTF8.GetBytes(message);


                tcpSocket.Connect(tcpEndPoint);
                tcpSocket.Send(data);


                var buffer = new byte[256];
                var size = 0;
                string answer;

                do
                {
                    size = tcpSocket.Receive(buffer);
                    answer = Encoding.UTF8.GetString(buffer, 0, size);
                }
                while (tcpSocket.Available > 0);

                tcpSocket.Shutdown(SocketShutdown.Both);
                tcpSocket.Close();

            }
            catch
            {

            }
        }
        //7
        public static string GetDescription(string id)
        {
            try
            {
                const string ip = "127.0.0.1";
                const int port = 8080;

                var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

                var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                var message = $"7|{id}";

                var data = Encoding.UTF8.GetBytes(message);


                tcpSocket.Connect(tcpEndPoint);
                tcpSocket.Send(data);


                var buffer = new byte[100000];
                var size = 0;
                string answer;

                do
                {
                    size = tcpSocket.Receive(buffer);
                    answer = Encoding.UTF8.GetString(buffer, 0, size);
                }
                while (tcpSocket.Available > 0);

                tcpSocket.Shutdown(SocketShutdown.Both);
                tcpSocket.Close();


                return answer;
            }
            catch
            {
                return "unknown";
            }
        }
        //8
        public static bool isExistLogin(string login, string oldLogin)
        {
            try
            {
                const string ip = "127.0.0.1";
                const int port = 8080;

                var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

                var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                var message = $"8|{login}|{oldLogin}";

                var data = Encoding.UTF8.GetBytes(message);


                tcpSocket.Connect(tcpEndPoint);
                tcpSocket.Send(data);


                var buffer = new byte[256];
                var size = 0;
                string answer;

                do
                {
                    size = tcpSocket.Receive(buffer);
                    answer = Encoding.UTF8.GetString(buffer, 0, size);
                }
                while (tcpSocket.Available > 0);

                tcpSocket.Shutdown(SocketShutdown.Both);
                tcpSocket.Close();

                return answer == "Exist" ? true : false;
            }
            catch
            {
                return false;
            }
        }
        //9
        public static void SaveChanges(string photo, int id, string login, string description)
        {
            try
            {
                const string ip = "127.0.0.1";
                const int port = 8080;

                var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

                var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                var message = $"9|{photo}|{id}|{login}|{description}";

                var data = Encoding.UTF8.GetBytes(message);


                tcpSocket.Connect(tcpEndPoint);
                tcpSocket.Send(data);


                var buffer = new byte[256];
                var size = 0;
                string answer;

                do
                {
                    size = tcpSocket.Receive(buffer);
                    answer = Encoding.UTF8.GetString(buffer, 0, size);
                }
                while (tcpSocket.Available > 0);

                tcpSocket.Shutdown(SocketShutdown.Both);
                tcpSocket.Close();

            }
            catch
            {

            }
        }
        //10
        public static string GetLogin(int id)
        {
            try
            {
                const string ip = "127.0.0.1";
                const int port = 8080;

                var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

                var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                var message = $"10|{id}";

                var data = Encoding.UTF8.GetBytes(message);


                tcpSocket.Connect(tcpEndPoint);
                tcpSocket.Send(data);


                var buffer = new byte[256];
                var size = 0;
                string answer;

                do
                {
                    size = tcpSocket.Receive(buffer);
                    answer = Encoding.UTF8.GetString(buffer, 0, size);
                }
                while (tcpSocket.Available > 0);

                tcpSocket.Shutdown(SocketShutdown.Both);
                tcpSocket.Close();

                return answer;
            }
            catch
            {
                return "UNKNOWN";
            }
        }
        //11
        public static string GetFriend(int id)
        {
            try
            {
                const string ip = "127.0.0.1";
                const int port = 8080;

                var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

                var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                var message = $"11|{id}";

                var data = Encoding.UTF8.GetBytes(message);


                tcpSocket.Connect(tcpEndPoint);
                tcpSocket.Send(data);


                var buffer = new byte[256];
                var size = 0;
                string answer;

                do
                {
                    size = tcpSocket.Receive(buffer);
                    answer = Encoding.UTF8.GetString(buffer, 0, size);
                }
                while (tcpSocket.Available > 0);

                tcpSocket.Shutdown(SocketShutdown.Both);
                tcpSocket.Close();

                return answer;
            }
            catch
            {
                return "UNKNOWN";
            }
        }
        //12
        public static int GetStatus(int id)
        {
            try
            {
                const string ip = "127.0.0.1";
                const int port = 8080;

                var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

                var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                var message = $"12|{id}";

                var data = Encoding.UTF8.GetBytes(message);


                tcpSocket.Connect(tcpEndPoint);
                tcpSocket.Send(data);


                var buffer = new byte[256];
                var size = 0;
                string answer;

                do
                {
                    size = tcpSocket.Receive(buffer);
                    answer = Encoding.UTF8.GetString(buffer, 0, size);
                }
                while (tcpSocket.Available > 0);

                tcpSocket.Shutdown(SocketShutdown.Both);
                tcpSocket.Close();

                return int.Parse(answer);
            }
            catch
            {
                return 0;
            }
        }
        //13
        public static string CountUsers()
        {
            try
            {
                const string ip = "127.0.0.1";
                const int port = 8080;

                var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

                var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                var message = $"13|";

                var data = Encoding.UTF8.GetBytes(message);


                tcpSocket.Connect(tcpEndPoint);
                tcpSocket.Send(data);


                var buffer = new byte[256];
                var size = 0;
                string answer;

                do
                {
                    size = tcpSocket.Receive(buffer);
                    answer = Encoding.UTF8.GetString(buffer, 0, size);
                }
                while (tcpSocket.Available > 0);

                tcpSocket.Shutdown(SocketShutdown.Both);
                tcpSocket.Close();

                return answer;
            }
            catch
            {
                return "";
            }
        }
        //14
        public static bool isExistingFriendship(int idUser, int idFriend)
        {
            try
            {
                const string ip = "127.0.0.1";
                const int port = 8080;

                var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

                var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                var message = $"14|{idUser}|{idFriend}";

                var data = Encoding.UTF8.GetBytes(message);


                tcpSocket.Connect(tcpEndPoint);
                tcpSocket.Send(data);


                var buffer = new byte[256];
                var size = 0;
                string answer;

                do
                {
                    size = tcpSocket.Receive(buffer);
                    answer = Encoding.UTF8.GetString(buffer, 0, size);
                }
                while (tcpSocket.Available > 0);

                tcpSocket.Shutdown(SocketShutdown.Both);
                tcpSocket.Close();

                return answer == "Exist"?true:false;
            }
            catch
            {
                return false;
            }
        }
        //15
        public static bool isExistingRequest(int idUser, int idFriend)
        {
            try
            {
                const string ip = "127.0.0.1";
                const int port = 8080;

                var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

                var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                var message = $"15|{idUser}|{idFriend}";

                var data = Encoding.UTF8.GetBytes(message);


                tcpSocket.Connect(tcpEndPoint);
                tcpSocket.Send(data);


                var buffer = new byte[256];
                var size = 0;
                string answer;

                do
                {
                    size = tcpSocket.Receive(buffer);
                    answer = Encoding.UTF8.GetString(buffer, 0, size);
                }
                while (tcpSocket.Available > 0);

                tcpSocket.Shutdown(SocketShutdown.Both);
                tcpSocket.Close();

                return answer == "Exist" ? true : false;
            }
            catch
            {
                return false;
            }
        }
        //16
        public static void RemoveFriend(int id, int friendId)
        {
            try
            {
                const string ip = "127.0.0.1";
                const int port = 8080;

                var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

                var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                var message = $"16|{id}|{friendId}";

                var data = Encoding.UTF8.GetBytes(message);


                tcpSocket.Connect(tcpEndPoint);
                tcpSocket.Send(data);


                var buffer = new byte[256];
                var size = 0;
                string answer;

                do
                {
                    size = tcpSocket.Receive(buffer);
                    answer = Encoding.UTF8.GetString(buffer, 0, size);
                }
                while (tcpSocket.Available > 0);

                tcpSocket.Shutdown(SocketShutdown.Both);
                tcpSocket.Close();

            }
            catch
            {

            }
        }
        //17
        public static void SendRequests(int id, int friendId)
        {
            try
            {
                const string ip = "127.0.0.1";
                const int port = 8080;

                var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

                var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                var message = $"17|{id}|{friendId}";

                var data = Encoding.UTF8.GetBytes(message);


                tcpSocket.Connect(tcpEndPoint);
                tcpSocket.Send(data);


                var buffer = new byte[256];
                var size = 0;
                string answer;

                do
                {
                    size = tcpSocket.Receive(buffer);
                    answer = Encoding.UTF8.GetString(buffer, 0, size);
                }
                while (tcpSocket.Available > 0);

                tcpSocket.Shutdown(SocketShutdown.Both);
                tcpSocket.Close();

            }
            catch
            {

            }
        }
        //18
        public static void AcceptFriend(int id, int friendId)
        {
            try
            {
                const string ip = "127.0.0.1";
                const int port = 8080;

                var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

                var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                var message = $"18|{id}|{friendId}";

                var data = Encoding.UTF8.GetBytes(message);


                tcpSocket.Connect(tcpEndPoint);
                tcpSocket.Send(data);


                var buffer = new byte[256];
                var size = 0;
                string answer;

                do
                {
                    size = tcpSocket.Receive(buffer);
                    answer = Encoding.UTF8.GetString(buffer, 0, size);
                }
                while (tcpSocket.Available > 0);

                tcpSocket.Shutdown(SocketShutdown.Both);
                tcpSocket.Close();

            }
            catch
            {

            }
        }
        //19
        public static void DeleteRequest(int id, int friendId)
        {
            try
            {
                const string ip = "127.0.0.1";
                const int port = 8080;

                var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

                var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                var message = $"19|{id}|{friendId}";

                var data = Encoding.UTF8.GetBytes(message);


                tcpSocket.Connect(tcpEndPoint);
                tcpSocket.Send(data);


                var buffer = new byte[256];
                var size = 0;
                string answer;

                do
                {
                    size = tcpSocket.Receive(buffer);
                    answer = Encoding.UTF8.GetString(buffer, 0, size);
                }
                while (tcpSocket.Available > 0);

                tcpSocket.Shutdown(SocketShutdown.Both);
                tcpSocket.Close();

            }
            catch
            {

            }
        }
        //20
        public static void DeleteFriend(int id, int friendId)
        {
            try
            {
                const string ip = "127.0.0.1";
                const int port = 8080;

                var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

                var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                var message = $"20|{id}|{friendId}";

                var data = Encoding.UTF8.GetBytes(message);


                tcpSocket.Connect(tcpEndPoint);
                tcpSocket.Send(data);


                var buffer = new byte[256];
                var size = 0;
                string answer;

                do
                {
                    size = tcpSocket.Receive(buffer);
                    answer = Encoding.UTF8.GetString(buffer, 0, size);
                }
                while (tcpSocket.Available > 0);

                tcpSocket.Shutdown(SocketShutdown.Both);
                tcpSocket.Close();

            }
            catch
            {

            }
        }
        //21
        public static string GetRequests(int id)
        {
            try
            {
                const string ip = "127.0.0.1";
                const int port = 8080;

                var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

                var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                var message = $"21|{id}";

                var data = Encoding.UTF8.GetBytes(message);


                tcpSocket.Connect(tcpEndPoint);
                tcpSocket.Send(data);


                var buffer = new byte[256];
                var size = 0;
                string answer;

                do
                {
                    size = tcpSocket.Receive(buffer);
                    answer = Encoding.UTF8.GetString(buffer, 0, size);
                }
                while (tcpSocket.Available > 0);

                tcpSocket.Shutdown(SocketShutdown.Both);
                tcpSocket.Close();

                return answer;
            }
            catch
            {
                return "";
            }
        }

        public static string GetResponse(int id)
        {
            try
            {
                const string ip = "127.0.0.1";
                const int port = 8080;

                var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

                var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                var message = $"22|{id}";

                var data = Encoding.UTF8.GetBytes(message);


                tcpSocket.Connect(tcpEndPoint);
                tcpSocket.Send(data);


                var buffer = new byte[256];
                var size = 0;
                string answer;

                do
                {
                    size = tcpSocket.Receive(buffer);
                    answer = Encoding.UTF8.GetString(buffer, 0, size);
                }
                while (tcpSocket.Available > 0);

                tcpSocket.Shutdown(SocketShutdown.Both);
                tcpSocket.Close();

                return answer;
            }
            catch
            {
                return "";
            }
        }
    }
}
