using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aegis.Character.Buffs
{
    public abstract class StackingBuff : TimedBuff
    {
        private int maxStacks;
        protected int stacks;

        StackingBuff(int maxStacks, int time)
            : base(time)
        {
            this.maxStacks = maxStacks;
            this.stacks = 0;
        }

        protected int MaxStacks { get { return maxStacks; } }

        public override bool OnOverwrite(IBuff buffOverwriting)
        {
            if (stacks < maxStacks)
                stacks++;

            return base.OnOverwrite(buffOverwriting);
        }
    }
}
