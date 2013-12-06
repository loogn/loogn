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
namespace ConsoleTest
{
    public class Log : IAspectAdvice
    {
        public void Before(object target, System.Reflection.MethodInfo mi, params object[] args)
        {
            Console.WriteLine("Before");
        }

        public void After(object target, System.Reflection.MethodInfo mi, params object[] args)
        {
            Console.WriteLine("After");
        }

        public void Throw(object target, System.Reflection.MethodInfo mi, params object[] args)
        {
            Console.WriteLine("Throw");
        }
    }

    public static class TT
    {
        public static void After(this Action act, params IAspectAdvice[] advices)
        {
            act();
            foreach (var ad in advices)
            {
                ad.After(act.Target, act.Method);
            }
        }
    }

    class Program
    {
        static string mgConn = "server=192.168.18.187:27017;database=papillon;username=pp;password=pp;connect=direct;maxPoolSize=200;connectTimeout=1m;";

        void F()
        {
            Console.WriteLine("Do F");
        }


        static void Main(string[] args)
        {
            Program p = new Program();

            var s = "sdfsdf".AsInt32();
            if (s != null)
            {
                Console.WriteLine(s.Value);
            }
            else {
                Console.WriteLine("null");
            }

            //AspectInvoker.AfterAction(F, new Log());

            //var stream = fs.Create("abc.txt", new MongoDB.Driver.GridFS.MongoGridFSCreateOptions()
            //{
            //    Aliases = new string[] { "ab", "bc" },
            //    ChunkSize = 1,
            //    UploadDate = DateTime.Now,
            //    Metadata = new BsonDocument { { "m1", 23 }, { "m2", "ab" } },
            //    ContentType = "txt",
            //});
            //var data=Encoding.ASCII.GetBytes("23423423434");
            //stream.Write(data, 0, data.Length);
            //stream.Close();
        }
    }
}
