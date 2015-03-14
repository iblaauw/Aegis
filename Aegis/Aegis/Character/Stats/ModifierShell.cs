using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aegis.Character.Stats
{
    public class ModifierShell
    {
        public IModifier Modifier { get; private set; }

        public ModifierShell(IModifier modifier)
        {
            this.Modifier = modifier;
            this.IsDestroyed = false;
        }

        public bool IsDestroyed { get; private set; }

        public void Destroy()
        {
            this.IsDestroyed = true;
            foreach (StatAdjuster adj in Modifier.GetAdjusters())
                adj.Destroy();
        }

        public void Update()
        {
            Modifier.Update();
        }
    }
}
