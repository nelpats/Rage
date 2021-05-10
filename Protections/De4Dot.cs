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

			for (int k = 0; k < 6; k++)
			{
				for (int i = 0; i < module.Types.Count; i++)
				{
					if (module.Types[i].HasInterfaces)
					{
						for (int j = 0; j < module.Types[i].Interfaces.Count; j++)
						{
							if (module.Types[i].Interfaces[j].Interface != null)
							{
								if (module.Types[i].Interfaces[j].Interface.Name.Contains(module.Types[i].Name) || module.Types[i].Name.Contains(module.Types[i].Interfaces[j].Interface.Name))
								{
									module.Types.RemoveAt(i);
									removed++;
								}
							}
						}
					}
				}
			}
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine($"\nRemoved {removed} AntiDe4Dot Attributes !");
		}
    }
}
