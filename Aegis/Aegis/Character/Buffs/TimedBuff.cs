using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aegis.Character.Stats;

namespace Aegis.Character.Buffs
{
    public abstract class TimedBuff : GeneralBuff
    {
        protected int counter;
        private int counterMax;

        public TimedBuff(int time)
        {
            counter = time;
            counterMax = time;
        }

        protected int CounterMax { get { return counterMax; } }

        public override bool AllowOverwrite(IBuff buffOverwriting)
        {
            counter = counterMax;
            return false;
        }

        public override void Update()
        {
            counter--;
            if (counter == 0)
            {
                RemoveSelf();
            }
        }
    }
}
