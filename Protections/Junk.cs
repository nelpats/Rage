using dnlib.DotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Junk
{
    public static void RemoveJunk(ModuleDefMD module)
    {
        string id = "ＰＲＯＪＥＣＴ-ＺＥＮ";
        int removed = 0;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nRemoving Junk types...");


            foreach (TypeDef type in module.Types)
                if (type.Methods.Count == 0 && type.Name.Contains(id))
                {
                    module.Types.ToArray();
                    module.Types.Remove(type);
                    removed++;
                }
              
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"\nRemoved {removed} junk types !");
    }
}

