using dnlib.DotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rage.Protections
{
    public class De4Dot
    {
        public static void RemoveAttributes(ModuleDefMD module)
        {
			int removed = 0;

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("\nRemoving AntiDe4Dot attributes...");


				foreach (TypeDef type in module.Types)
					if (type.HasInterfaces)
					{
						for (int j = 0; j < type.Interfaces.Count; j++)
						{
							if (type.Interfaces[j].Interface != null)
							{
								if (type.Interfaces[j].Interface.Name.Contains(module.Types[i].Name) || module.Types[i].Name.Contains(module.Types[i].Interfaces[j].Interface.Name))
								{
									module.Types.ToArray();
									module.Types.Remove(type);
									removed++;
								}
							}
						}
					}

			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine($"\nRemoved {removed} AntiDe4Dot Attributes !");
		}
    }
}
