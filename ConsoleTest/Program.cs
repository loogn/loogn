using System;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using System.Text;
using Loogn.Common;
using MongoDB.Bson;
using Loogn.Common.Aspect;
using System.ComponentModel;
using System.Net.Sockets;
namespace ConsoleTest
{

    class Program
    {
        static string mgConn = "server=192.168.18.187:27017;database=papillon;username=pp;password=pp;connect=direct;maxPoolSize=200;connectTimeout=1m;";


        static void Main(string[] args)
        {

            while (true)
            {
                string msg = Console.ReadLine();
                var data = Encoding.UTF8.GetBytes(msg);
                using (TcpClient client = new TcpClient(AddressFamily.InterNetwork))
                {

                    client.Connect("127.0.0.1", 8181);
                    var stream = client.GetStream();
                    stream.Write(BitConverter.GetBytes(data.Length), 0, 4);
                    stream.Write(data, 0, data.Length);
                }
            }
        }
    }
}