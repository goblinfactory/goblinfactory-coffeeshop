using System;
using System.Threading;
using Akka.Actor;
using Goblinfactory.Coffee.Shared.Messages;

namespace Goblinfactory.Coffee.Shared.Actors
{
    public class BaristaActor : ReceiveActor
    {
        public BaristaActor()
        {
            Receive<MakeCoffee>(message =>
            {
                Console.WriteLine("BARISTA  Making {0}", message.Coffee);
                Thread.Sleep(new Random().Next(5000));
                Console.WriteLine("BARISTA  Finished making {0}", message.Coffee);
            });
        }

        public static IActorRef Create(ActorSystem system)
        {
            var actor = system.ActorOf(Props.Create(() => new BaristaActor()),NAME);
            return actor;
        }

        public static string NAME = "barista";
    }
}
