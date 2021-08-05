using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace CustomBoomi
{
    public class CrudMain
    {
        private static void Usage()
        {
            Console.Error.WriteLine("Usage: [Class.Method] > ex. BoomiCRUD.Display");
            Environment.Exit(1);
        }

        private static void Error(string message)
        {
            Console.Error.WriteLine($"{message} does not exist, exiting");
            Environment.Exit(1);
        }

        public static void Main(string[] args)
        {
            if (args.Length == 0 || args[0].Split(".").Length != 2)
            {
                Usage();
            }

            var split    = args[0].Split(".");
            var assembly = Assembly.GetExecutingAssembly();
            var types    = assembly.GetTypes();
            var clsName  = split[0];
            var method   = split[1];

            var type = types.FirstOrDefault(x => x.Name == clsName);
            if (type == null)
            {
                Error(clsName);
            }
            else
            {
                var func = type.GetMethods().FirstOrDefault(x => x.Name == method);
                if (func == null)
                {
                    Error(method);
                }
                else
                {
                    var line = "";
                    var sb   = new StringBuilder();

                    while ((line = Console.ReadLine()) != null)
                    {
                        sb.Append(line + Environment.NewLine);
                    }

                    string json;
                    if (sb.ToString() == string.Empty)
                    {
                        json = JsonSerializer.Serialize(func.Invoke(null, null));
                    }
                    else
                    {
                        json = JsonSerializer.Serialize(func.Invoke(null, new object[] { sb.ToString() }));
                    }

                    Console.WriteLine(json);
                }
            }
        }
    }
}
