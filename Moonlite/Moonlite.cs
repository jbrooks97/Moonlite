using MonoMod.Cil;
using System;
using Terraria;
using Terraria.ModLoader;
using static Mono.Cecil.Cil.OpCodes;

namespace Moonlite
{
	public class Moonlite : Mod
	{

        public override void Load() {
            IL.Terraria.Main.UpdateSundial += HookUpdateSundial;
            base.Load();
        }

        private void HookUpdateSundial(ILContext il) {

            var c = new ILCursor(il);

            var label = c.DefineLabel();

            
            c.Emit(Ldsfld, typeof(Main).GetField(nameof(Main.dayRate))); // push Main.dayRate
            c.Emit(Brtrue_S, label); // this checks if bool is false or 0 and moves control where the label points to, but since bools under the hood are ints of 1 for true and 0 for false, you can say if(bool == false) is the same as if(int == 0)
                                         // so BrFalse also counts as == 0
            c.Emit(Ret); // return;

            c.Emit(Ldsfld, typeof(Main).GetField(nameof(Main.fastForwardTime)));
            c.Emit(Brfalse_S, label);

            c.Emit(Ldc_I4_S, (sbyte)60);
            c.Emit(Stsfld, typeof(Main).GetField(nameof(Main.dayRate)));

            c.Emit(Ret);

            c.Emit(Ldc_I4_1);
            c.Emit(Stsfld, typeof(Main).GetField(nameof(Main.dayRate)));

            c.Emit(Ret);

            c.MarkLabel(label);

            //var label = c.MarkLabel(); // mark first instruction in the method for this label (the ldsfld bool Terraria.Main::FastForwardTime)

            //throw new NotImplementedException();
        }
    }
}