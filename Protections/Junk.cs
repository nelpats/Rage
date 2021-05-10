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

        for (int j = 0; j < 6; j++)
        {
            for (int i = 0; i < module.Types.Count; i++)
            {
                if (module.Types[i].Methods.Count == 0 && module.Types[i].Name.Contains(id))
                {
                    module.Types.RemoveAt(i);
                    removed++;
                }
            }
        }
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"\nRemoved {removed} junk types !");
    }
}

