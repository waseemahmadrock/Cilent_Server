
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace ClientExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket dailer = new Socket(SocketType.Stream, ProtocolType.Tcp);
            //Socket listner = new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);
            Console.WriteLine("Socket Created");

            IPAddress ipAddress = IPAddress.Loopback;
            //IPAddress ipAddress=IPAddress.Parse("127.0.0.1");
            Console.WriteLine("IP Assigned");

            IPEndPoint ipendpoint = new IPEndPoint(ipAddress, 8001);
            Console.WriteLine("Endpint Ready");
           
            try
            {
                dailer.Connect(ipendpoint);
                Console.WriteLine("Connected To Server");
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to Connect");
            }


            NetworkStream ns = new NetworkStream(dailer);
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);

            //Communication
            sw.WriteLine();
            sw.Flush();

            sr.ReadLine();

            dailer.Close();
            Console.WriteLine("Closed!");

            Console.ReadKey();
        }
    }
}
