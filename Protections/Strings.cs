using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rage.Protections
{
    public class Strings
    {
        public static void Decrypt(ModuleDefMD module)
        {
            Console.WriteLine("Running String Decryption...");
            foreach (TypeDef type in module.Types)
                foreach (MethodDef method in type.Methods)
                {
                    if (method.HasBody)
                        if (method.Body.HasInstructions)
                        {
                            IList<Instruction> IL = method.Body.Instructions;
                            for (int i = 0; i < IL.Count; i++)
                            {
                                if (IL[i].OpCode == OpCodes.Ldstr)
                                {

                                    if (IL[i - 1].OpCode == OpCodes.Call && IL[i - 1].Operand.ToString().Contains("Encoding::get_UTF8()"))
                                        if (IL[i + 1].OpCode == OpCodes.Call && IL[i + 1].Operand.ToString().Contains("System.Convert::FromBase64String(System.String)"))
                                        {
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine($"\nFixing string at {method.Name} ({method.MDToken})");
                                            IL[i].Operand = Encoding.UTF8.GetString(Convert.FromBase64String(IL[i].Operand.ToString()));

                                            IL[i + 1].OpCode = OpCodes.Nop;
                                            IL[i - 1].OpCode = OpCodes.Nop;
                                            IL[i + 2].OpCode = OpCodes.Nop;

                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            Console.WriteLine($"\nString fixed !");
                                        }
                                }
                            }

                        }

                    method.Body.KeepOldMaxStack = true;
                }
                  
        }
    }
}
