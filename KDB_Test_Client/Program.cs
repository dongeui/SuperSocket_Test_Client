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


            /*
             719 장비 붙인 후에 프로토콜에 나와있는 사이즈대로 KDB 프로젝트 필터 렝스 수정해서 받아보고 
             요청 안받아지면 팀장님한테 문서 정확도 물어보기
             이것도 안되면 위아래로 +3정도까지 테스트 한 후에 문서랑 비교해보기

             되면 커맨드 하나하나에 대하여 작성
             다음주 수요일내로 커맨드에 대한 처리기반이 만들어져야 그걸 wcf라는 프레임웤에 어떻게 던져줄지 고민할 시간이 생김
             */
            

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

          
        }
    }
}
