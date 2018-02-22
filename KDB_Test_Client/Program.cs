using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace KDB_Test_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse("192.168.15.2"), 48484);

            try
            {
                sck.Connect(localEndPoint);
            }
            catch
            {
                Console.Write("Unable to connect to remote end point!\r\n");
                Main(args);
            }

            Console.Write("Enter Text: ");
            string text = Console.ReadLine();
            byte[] data = Encoding.UTF8.GetBytes(text);

            sck.Send(data);
            Console.Write("Data Sent!\r\n");
            Console.Write("Press any key To continue...");
            Console.Read();
            sck.Close();

            //Console.WriteLine("클라소켓");
            /// 소켓 설정
            // EndPoint serverAddress = new IPEndPoint(IPAddress.Parse("192.168.15.2"), 48484);

            //using (Socket socket = new Socket(serverAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp))
            //{
            //    socket.Connect(serverAddress);
            //    Console.WriteLine("SOCKET 연결 성공");

            //    for (int i = 0; i < 5; i++)
            //    {
            //        Stream socketStream = new NetworkStream(socket);
            //        using (StreamReader reader = new StreamReader(socketStream, Encoding.Default, true))
            //        using (StreamWriter writer = new StreamWriter(socketStream, Encoding.Default, 1024 * 8))
            //        {

            //            string command = "HELLO ";
            //            string[] parameters = new string[] { "Kerry", "Jiang", "China", "Shanghai" };
            //            string parameter = Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Join(" ", parameters)));
            //            writer.WriteLine(command);
            //            writer.Flush();
            //            Console.WriteLine(i + "번째 HELLO 보내기 완료");

            //        }
            //    }


            //}//using
        }
    }
}
