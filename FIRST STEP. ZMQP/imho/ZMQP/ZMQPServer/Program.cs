using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ZMQPServer
{
    class Program
    {
        static void Main(string[] args)
        {
            const string ip = "127.0.0.1";
            const int port = 8080;

            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

            var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            tcpSocket.Bind(tcpEndPoint);
            tcpSocket.Listen(10);

            

            while (true)
            {
                string message = "Unknown";
                var listener = tcpSocket.Accept();
                var buffer = new byte[10000000];
                var size = 0;
                var data = new StringBuilder();

                do
                {
                    size = listener.Receive(buffer);
                    data.Append(Encoding.UTF8.GetString(buffer, 0, size));
                }
                while (listener.Available > 0);

                var getMessage = data.ToString().Split('|');
                if (getMessage[0] == "0")
                {
                    Console.WriteLine($"[+] Запрос от {getMessage[1]}, IP:{getMessage[2]}, PORT:{getMessage[3]}");
                    message = "Success";
                }
                if (getMessage[0] == "1")
                {
                    message = Classes.Handler.CheckIndenticalUser(getMessage[1], getMessage[2]) ? "Succeed!": "Failed";
                }
                if (getMessage[0] == "2")
                {
                    message = Classes.Handler.CheckIndenticalUserRegisration(getMessage[1], getMessage[2]) ? "Succeed!" : "Failed";
                    if (!Classes.Handler.CheckIndenticalUserRegisration(getMessage[1], getMessage[2])) Classes.Handler.RegistrateUser(getMessage[1], getMessage[2], getMessage[3]);
                }
                if (getMessage[0] == "3")
                {
                    message = Classes.Handler.GetID(getMessage[1]).ToString();
                }
                if (getMessage[0] == "4")
                {
                    message = Classes.Handler.GetProfileImage(int.Parse(getMessage[1]));
                }
                if (getMessage[0] == "5")
                {
                    Classes.Handler.SetActiveStatus(int.Parse(getMessage[1]));
                }
                if (getMessage[0] == "6")
                {
                    Classes.Handler.SetInactiveStatus(int.Parse(getMessage[1]));
                }
                if (getMessage[0] == "7")
                {
                    message = Classes.Handler.GetDescription(int.Parse(getMessage[1]));
                }
                if (getMessage[0] == "8")
                {
                    message = Classes.Handler.isExistLogin(getMessage[1], getMessage[2]) == true ? "Exist" : "NotExist";

                }
                if (getMessage[0] == "9")
                {
                    Classes.Handler.SaveChanges(getMessage[1], int.Parse(getMessage[2]), getMessage[3], getMessage[4]);
                    message = "Success";
                }
                if (getMessage[0] == "10")
                {
                    message = Classes.Handler.GetLogin(int.Parse(getMessage[1]));
                }
                if (getMessage[0] == "11")
                {
                    message = Classes.Handler.GetFriend(int.Parse(getMessage[1]));
                }
                if (getMessage[0] == "12")
                {
                    message = Classes.Handler.GetStatus(int.Parse(getMessage[1])).ToString();
                }
                if (getMessage[0] == "13")
                {
                    message = Classes.Handler.CountUsers().ToString();
                }
                if (getMessage[0] == "14")
                {
                    message = Classes.Handler.isExistFriendship(int.Parse(getMessage[1]), int.Parse(getMessage[2])) == true ? "Exist" : "NotExist";
                }
                if (getMessage[0] == "15")
                {
                    message = Classes.Handler.isExistRequests(int.Parse(getMessage[1]), int.Parse(getMessage[2])) == true ? "Exist" : "NotExist";
                }
                if (getMessage[0] == "16")
                {
                    Classes.Handler.RemoveFriend(int.Parse(getMessage[1]), int.Parse(getMessage[2]));
                    message = "Success";
                }
                if (getMessage[0] == "17")
                {
                    Classes.Handler.SendRequest(int.Parse(getMessage[1]), int.Parse(getMessage[2]));
                    message = "Success";
                }
                if (getMessage[0] == "18")
                {
                    Classes.Handler.AcceptFriend(int.Parse(getMessage[1]), int.Parse(getMessage[2]));
                    message = "Success";
                }
                if (getMessage[0] == "19")
                {
                    Classes.Handler.DeleteRequest(int.Parse(getMessage[1]), int.Parse(getMessage[2]));
                    message = "Success";
                }
                if (getMessage[0] == "20")
                {
                    Classes.Handler.DeclineFriend(int.Parse(getMessage[1]), int.Parse(getMessage[2]));
                    message = "Success";
                }
                if (getMessage[0] == "21")
                {
                    message = Classes.Handler.GetRequests(int.Parse(getMessage[1]));
                }
                if (getMessage[0] == "22")
                {
                    message = Classes.Handler.GetResponse(int.Parse(getMessage[1]));
                }

                listener.Send(Encoding.UTF8.GetBytes(message));
                listener.Shutdown(SocketShutdown.Both);
                listener.Close();
            }
        }
    }
}
