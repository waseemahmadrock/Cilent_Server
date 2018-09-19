using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SeverExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket listner = new Socket(SocketType.Stream, ProtocolType.Tcp);
            //Socket listner = new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);
            Console.WriteLine("Socket Created");

            IPAddress ipAddress = IPAddress.Loopback;
            //IPAddress ipAddress=IPAddress.Parse("127.0.0.1");
            Console.WriteLine("IP Assigned");

            IPEndPoint ipendpoint = new IPEndPoint(ipAddress, 8001);
            Console.WriteLine("Endpint Ready");
            
            listner.Bind(ipendpoint);
            Console.WriteLine("Socket Bind");
            
            listner.Listen(1);
            Console.WriteLine("Now Listening...");

            Socket client=listner.Accept();
            Console.WriteLine("Client Connected");

            NetworkStream ns = new NetworkStream(client);
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);

            //Communication
            sr.ReadLine();

            sw.WriteLine();
            sw.Flush();

            listner.Close();
            Console.WriteLine("Closed!");

            Console.ReadKey();


        }
    }
}