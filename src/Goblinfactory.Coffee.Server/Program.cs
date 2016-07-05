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

namespace Goblinfactory.Coffee.Server
{
    class Program
    {

        static void Main(string[] args)
        {

            using (var system = ActorSystem.Create(ContainerNames.CoffeeServer, ConfigReader.AkkaConfig))
            {
                Thread.Sleep(500);
                var barista = BaristaActor.Create(system);
                
                RunMenu(barista);
                system.Terminate();
            }

        }

        private static void RunMenu(IActorRef barista)
        {
            Console.WriteLine();
            Console.WriteLine("Coffee Server started.");
            Console.WriteLine("======================");
            Console.WriteLine();

            Console.WriteLine("Press 'c'uppacino, 'l'atte, 'q'uit.");
            char key;
            while ((key = Console.ReadKey().KeyChar) != 'q')
            {
                switch (key)
                {
                    case 'c':
                        barista.Tell(new MakeCoffee("Cuppucino"));
                        break;
                    case 'l':
                        barista.Tell(
                            new MakeCoffee(
                                "Double decaf non fat latte, medium foam, dusted with just the faintest whisper of cinnamon."));
                        break;
                }
            }
        }
    }
}
