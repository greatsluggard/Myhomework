using NUnit.Framework;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Task1TestUnit
{
    public class Tests
    {
        [Test]
        public void IsClientConnection()
        {
            Task serverTask = Task.Run(() => TCPServer.TCPServer.Main());

            string ip = "127.0.0.1";
            int port = 8080;

            using (TcpClient client = new TcpClient(ip, port))
            {
                Assert.IsTrue(client.Connected);
            }
        }

        [Test] 
        public void IsServerResponse()
        {
            Task serverTask = Task.Run(() => TCPServer.TCPServer.Main());

            string ip = "127.0.0.1";
            int port = 8080;
            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            tcpSocket.Connect(tcpEndPoint);

            var data = Encoding.UTF8.GetBytes("QUIT");
            tcpSocket.Send(data);

            var buffer = new byte[256];
            var size = 0;
            var answer = new StringBuilder();

            do
            {
                size = tcpSocket.Receive(buffer);
                answer.Append(Encoding.UTF8.GetString(buffer, 0, size));
            } while (tcpSocket.Available > 0);

            Assert.IsTrue(answer.ToString() == "QUIT");
        }
    }
}
