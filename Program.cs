using dnlib.DotNet;
using Rage.Protections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rage
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Bad args ! Please drag and drop file to unpack.");
                Console.ReadKey();
                Environment.Exit(0);
            }

            if (!System.IO.File.Exists(args[0]))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("File does not exist !");
                Console.ReadKey();
                Environment.Exit(0);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Loading module...");

            ModuleDefMD module = ModuleDefMD.Load(args[0]);
            Console.WriteLine("Module loaded !");

            System.Threading.Thread.Sleep(1000);
            Console.Clear();

            Strings.Decrypt(module);
            De4Dot.RemoveAttributes(module);
            FakeAttributes.RemoveFakeAttributes(module);
            Junk.RemoveJunk(module);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n[Module saved.]");
            module.Write($"{Environment.CurrentDirectory}\\deZen.exe");
            Console.Read();



        }
    }
}
