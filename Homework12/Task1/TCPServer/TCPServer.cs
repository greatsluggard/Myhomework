using System;
using System.IO;
using System.Net;
using System.Text;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TCPServer
{
    public class TCPServer
    {
        static async Task<string> ListAsync()
        {
            Console.WriteLine("Укажите путь директории файлов: ");
            var path = Console.ReadLine();
            string response = await Task.Run(() => List(path));
            return response;
        }

        static string List(string path)
        {
            bool isDir;
            string response = "";
            string numberOfFilesInDirectory;

            if (Directory.Exists(path))
            {
                List<string> files = Directory.GetFiles(path).ToList();
                List<string> directories = Directory.GetDirectories(path).ToList();

                numberOfFilesInDirectory = (files.Count + directories.Count).ToString();

                response += numberOfFilesInDirectory + ": ";

                foreach (string dir in directories)
                {
                    response += " " + dir;
                    isDir = true;
                    response += " " + isDir.ToString() + " \n";
                }

                foreach (string file in files)
                {
                    response += " " + file;
                    isDir = false;
                    response += " " + isDir.ToString() + " \n";
                }
            }
            else
            {
                numberOfFilesInDirectory = "-1: ";
                response += numberOfFilesInDirectory + "Введённая вами директория не существует";
            }

            return response;
        }

        static async Task<string> GetAsync()
        {
            Console.WriteLine("Укажите путь к файлу: ");
            var path = Console.ReadLine();
            string response = await Task.Run(() => Get(path));
            return response;
        }

        static string Get(string path)
        {
            string response = "";

            if (File.Exists(path))
            {
                long size = new FileInfo(path).Length;
                response += "\n size: ";
                response += size.ToString() + " ";

                response += "\n content: ";
                byte[] content = File.ReadAllBytes(path);
                for (int i = 0; i < content.Length; i++)
                {
                    response += content[i].ToString();
                }
            }
            else
            {
                response += "-1: Указанный вами файл не существует";
            }

            return response;
        }

        public static void Main()
        {
            const string ip = "127.0.0.1";
            const int port = 8080;

            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

            var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            tcpSocket.Bind(tcpEndPoint);
            tcpSocket.Listen(5);
            var listener = tcpSocket.Accept();

            while (true)
            {
                var buffer = new byte[256];

                var size = 0;

                var data = new StringBuilder();

                do
                {
                    size = listener.Receive(buffer);
                    data.Append(Encoding.UTF8.GetString(buffer, 0, size));
                } while (listener.Available > 0);


                if (data.ToString() == "LIST")
                {
                    Task<string> response = ListAsync();
                    listener.Send(Encoding.UTF8.GetBytes(response.Result));
                }
                else if (data.ToString() == "GET")
                {
                    Task<string> response = GetAsync();
                    listener.Send(Encoding.UTF8.GetBytes(response.Result));
                }
                else if (data.ToString() == "QUIT")
                {
                    listener.Send(Encoding.UTF8.GetBytes("QUIT"));
                    listener.Shutdown(SocketShutdown.Both);
                    listener.Close();
                    break;
                }
            }
        }
    }
}