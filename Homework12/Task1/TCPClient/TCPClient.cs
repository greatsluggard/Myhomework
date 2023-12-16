using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPClient
{
    public class TCPClient
    {
        public static void Main()
        {
            const string ip = "127.0.0.1";
            const int port = 8080;

            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

            var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            tcpSocket.Connect(tcpEndPoint);

            while (true)
            {
                string request;

                Console.WriteLine("Список команд: " +
                "\n LIST - листинг файлов в директории на сервере " +
                "\n GET - скачивание файла с сервера " +
                "\n QUIT - прервать соединение");

                Console.Write("Введите запрос: ");
                request = Console.ReadLine();

                if (request == "QUIT")
                {
                    tcpSocket.Shutdown(SocketShutdown.Both);
                    tcpSocket.Close();
                    break;
                }

                var data = Encoding.UTF8.GetBytes(request);

                tcpSocket.Send(data);

                var buffer = new byte[256];

                var size = 0;

                var answer = new StringBuilder();

                do
                {
                    size = tcpSocket.Receive(buffer);
                    answer.Append(Encoding.UTF8.GetString(buffer, 0, size));
                } while (tcpSocket.Available > 0);

                Console.WriteLine("Ответ: " +answer.ToString());
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
