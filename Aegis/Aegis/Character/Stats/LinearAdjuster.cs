using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aegis.Character.Buffs;

namespace Aegis.Character.Stats
{
    public class LinearAdjuster : StatAdjuster<int>
    {
        int value;
        public LinearAdjuster(Stat<int> stat, IModifier parent, int value) : base(stat, parent)
        {
            this.value = value;
        }

        public override void Adjust(ref int val)
        {
            val += value;
        }

        public override bool IsPersistent
        {
            get { return true; }
        }
    }
}
