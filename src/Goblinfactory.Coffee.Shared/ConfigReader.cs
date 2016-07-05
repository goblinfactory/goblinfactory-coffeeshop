﻿using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using Akka.Configuration;

namespace Coffee.Shared
{
    public static class ConfigReader
    {

        private static string Hocon (Assembly assembly)
        {
            var name = assembly.GetName().Name;
            var resourceName = string.Format("{0}.{1}", name, "akka.hocon");
            bool exists = assembly.GetManifestResourceNames().FirstOrDefault(r => r.EndsWith("akka.hocon")) != null;
            if (!exists) throw new MissingManifestResourceException("It's possible the akka.hocon file is missing, or not marked as an embedded resource. Right click file, properties, build action, select 'embedded resource'.");
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        /// <summary>
        /// create your hocon configuration, name it akka.hocon, and set to 'embedded resource'D:\git-bd\spikes\akka-coffee\src\Coffee.Server\akka.hocon
        /// </summary>
        public static Config AkkaConfig
        {
            get
            {
                var assembly = Assembly.GetCallingAssembly();
                var akkaHoconConfigText = Hocon(assembly);
                return ConfigurationFactory.ParseString(akkaHoconConfigText);
            }
        }

    }
}
