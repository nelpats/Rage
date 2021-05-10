using dnlib.DotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rage.Protections
{
    public class FakeAttributes
    {
        public static void RemoveFakeAttributes(ModuleDefMD module)
        {
            int removed = 0;

            string[] attributes =
            {
                "AssemblyInfoAttribute",
                "BabelAttribute",
                "BabelObfuscatorAttribute",
                "ConfusedByAttribute",
                "ProtectedWithCryptoObfuscatorAttribute",
                "DotfuscatorAttribute",
                "DotNetPatcherObfuscatorAttribute",
                "DotNetPatcherPackerAttribute",
                "dotNetProtector",
                "NetGuard",
                "Evaluation",
                "ObfuscatedByGoliath",
                "PoweredByAttribute",
                "ZYXDNGuarder",
                "YanoAttribute",
                "Xenocode.Client.Attributes.AssemblyAttributes.ProcessedByXenocode",


            };


            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nRemoving Fake Attributes...");
            for (int k = 0; k < 6; k++)
            {
                for (int i = 0; i < module.Types.Count; i++)
                {
                    for (int j = 0; j < attributes.Length; j++)
                    {
                        if (module.Types[i].Methods.Count == 0 && module.Types[i].Name.Equals(attributes[j]) || module.Types[i].Name.Contains(attributes[j]))
                        {
                            module.Types.RemoveAt(i);
                            removed++;
                        }
                    }

                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\nRemoved {removed} Fake Attributes !");
        }
    }
}
