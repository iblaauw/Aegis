using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aegis.Character.Stats
{
    public class BuffShell
    {
        IBuff buff;

        public BuffShell(IBuff buff)
        {
            this.buff = buff;
            this.IsDestroyed = false;
        }

        public bool IsDestroyed { get; private set; }

        public void Destroy()
        {
            this.IsDestroyed = true;
            foreach (StatAdjuster adj in buff.GetAdjusters())
                adj.Destroy();
        }

        public void Update()
        {
            buff.Update();
        }
    }
}
