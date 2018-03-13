using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Kdb.Util;

namespace KDB_Test_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse("192.168.15.2"), 48484);
            Socket sck = new Socket(serverAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            //16
            var Alive =   "200d001030303138376265663238353430303030";
            //39
            var Access =  "2008002330303138376265663263623030303030011801181613000000000000000000FF008300";
            var Access2 = "2018002330303138376265663235666430303030011801181550545CEE1A2E00000000FF000101";
            //47자리
            var Event =   "2008002B30303138376265663439333530303030021801190030153233343520313820453332322030302043303030";
            var Event2 =  "2018002B30303138376265663235666430303030021801181502283233343520313820453131302030302043303033";

            try
            {
                sck.Connect(serverAddress);
                Console.WriteLine("소켓 연결");

                var socketStream = new NetworkStream(sck);
                var reader = new StreamReader(socketStream, Encoding.Default, true);
                var writer = new StreamWriter(socketStream, Encoding.Default, 1024*8);

                //Byte[]로 쏴주는게 아니라  string

                var byteData = HexConverter.ToHexBytes(Event);
                var stringData = HexConverter.ToString(byteData);
                writer.Write(stringData);
                writer.Flush();
                Console.WriteLine("Alilve Check Protocol Send");

                var readBuffer = reader.ReadLine();
                Console.WriteLine("Read : "+readBuffer);

            }
            catch
            {
                Console.Write("Unable to connect to remote end point!\r\n");
                Main(args);
            }

            Console.Write("Data Sent!\r\n");
            Console.Write("Press any key To continue...");
            Console.Read();
            sck.Close();

          
        }
    }
}
