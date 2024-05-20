using System.Collections.Generic;

using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Collections.Generic;
using MonoMod.Utils;

#if MELONLOADER

using System.Reflection;

using MelonLoader;

[assembly: MelonInfo(typeof(TemplateModPatcher.Patcher), "TemplateModPatcher", "0.1.0", "Kaden5480")]
[assembly: MelonGame("TraipseWare", "Peaks of Yore")]

#endif

namespace TemplateModPatcher {

#if BEPINEX

    public static class Patcher {
        /**
         * <summary>
         * The DLLs this patcher targets.
         * </summary>
         */
        public static IEnumerable<string> TargetDLLs { get; } = new string[] {
            "Assembly-CSharp.dll",
        };

#elif MELONLOADER

    public class Patcher : MelonPlugin {

#endif
        /**
         * <summary>
         * Patches the game.
         * </summary>
         * <param name="assembly">The assembly to patch</param>
         */
        public static void Patch(AssemblyDefinition assembly) {
            ModuleDefinition main = assembly.MainModule;

            //PatchExample(main.GetType("SomeClass"));
        }

#if MELONLOADER
        public override void OnPreInitialization() {
            AssemblyDefinition assembly = AssemblyDefinition.ReadAssembly("./Peaks of Yore_Data/Managed/Assembly-CSharp.dll");

            Patch(assembly);

            assembly.Write("MelonLoader/Managed/TemplateMod-Assembly-CSharp.dll");
            assembly.Dispose();

            Assembly.LoadFile("MelonLoader/Managed/TemplateMod-Assembly-CSharp.dll");
        }
#endif
    }
}
