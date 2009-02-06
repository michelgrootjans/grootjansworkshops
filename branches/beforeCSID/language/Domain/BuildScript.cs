using System;

namespace Domain
{
    public class BuildScript
    {
        public void Run(params string[] args)
        {
            foreach (var arg in args)
                Execute(arg);
        }

        private static void Execute(string arg)
        {
            switch (arg)
            {
                case "getlatest":
                    GetLatestVersion();
                    break;
                case "compile":
                    Compile();
                    break;
                case "test":
                    RunUnitTests();
                    break;
                case "deploy":
                    Deploy();
                    break;
                default:
                    throw new ArgumentException(string.Format("'{0}' is not a valid command.", arg));

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

        private static void Deploy()
        {
            Console.WriteLine("Deploying the new assemblies ...");
        }
    }
}