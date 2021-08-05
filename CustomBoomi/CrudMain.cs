using System;
using System.Linq;
using System.Reflection;

namespace CustomBoomi
{
    public class CrudMain
    {
        private static void Usage()
        {
            Console.Error.WriteLine("Usage: [OperationName] > ex. BoomiCRUD.Display");
            Environment.Exit(1);
        }

        public static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                Usage();
            }

            var split = args[0].Split(".");
            if (split.Length != 2)
            {
                Usage();
            }

            var assembly = Assembly.GetExecutingAssembly();
            var types    = assembly.GetTypes();
            var clsName  = split[0];
            var method   = split[1];

            var type = types.FirstOrDefault(x => x.Name == clsName);
            if (type != null)
            {
                var func = type.GetMethods().FirstOrDefault(x => x.Name == method);
                if (func != null)
                {
                    Console.WriteLine(func.Invoke(null, null));
                }
                else
                {
                    Console.Error.WriteLine($"{method} does not exist, exiting");
                }
            }
            else
            {
                Console.Error.WriteLine($"{clsName} does not exist, exiting");
            }

            return 0;
        }
    }
}
