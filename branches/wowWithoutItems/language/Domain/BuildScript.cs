using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class BuildScript
    {
        private readonly Dictionary<string, Action> commands;

        public BuildScript()
        {
            commands = new Dictionary<string, Action>
                           {
                               {"get", GetLatestVersion},
                               {"build", Compile},
                               {"test", RunUnitTests},
                               {"deploy", DeployToProduction}
                           };
        }

        public void Run(params string[] args)
        {
            foreach (var arg in args)
                Execute(arg);
        }

        private void Execute(string command)
        {
            if (commands.ContainsKey(command))
            {
                commands[command]();
                //Alternative for readablility:
                //commands[command].Invoke();
            }
            else
            {
                var validCommands = string.Join(", ", commands.Keys.ToArray());
                throw new ArgumentException(string.Format("'{0}' is not a valid command. Valid commands are: {1}", command, validCommands));
            }
        }

        private static void GetLatestVersion()
        {
            Console.WriteLine("Getting the latest version from source control ...");
        }

        private static void Compile()
        {
            Console.WriteLine("Compiling the source code ...");
        }

        private static void RunUnitTests()
        {
            Console.WriteLine("Runnig the unit tests ...");
        }

        private static void DeployToProduction()
        {
            Console.WriteLine("Deploying the new assemblies ...");
        }
    }
}