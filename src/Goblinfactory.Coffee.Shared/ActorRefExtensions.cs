using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;

namespace Coffee.Shared
{
    public static class ActorRefExtensions
    {
        public static void TellAll(this IActorRef[] subscribers, object message)
        {
            foreach (IActorRef actor in subscribers) actor.Tell(message);
        }
    }
}
