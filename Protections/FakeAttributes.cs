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

                foreach (TypeDef type in module.Types)
                {
                    for (int j = 0; j < attributes.Length; j++)
                    {
                        if (type.Methods.Count == 0
                            && type.Name.Equals(attributes[j])
                            || type.Name.Contains(attributes[j]))
                        {
                            module.Types.ToArray();
                            module.Types.Remove(type);
                            removed++;
                        }
                    }

                }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\nRemoved {removed} Fake Attributes !");
        }
    }
}
