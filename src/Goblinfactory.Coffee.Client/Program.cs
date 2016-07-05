using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Akka.Actor;
using Coffee.Shared;
using Goblinfactory.Coffee.Shared;
using Goblinfactory.Coffee.Shared.Actors;
using Goblinfactory.Coffee.Shared.Messages;

namespace Goblinfactory.Coffee.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var system = ActorSystem.Create(ContainerNames.CoffeeClient, ConfigReader.AkkaConfig))
            {
                Thread.Sleep(500);
                Console.WriteLine();
                Console.WriteLine("Coffee client started.");
                Console.WriteLine("======================");
                Console.WriteLine();
                Console.WriteLine("(this is a dumb remote container for the server to send remote objects to.) Press any key to quit.");
                Console.ReadKey();
                system.Terminate();
            }
        }
    }
}
