using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aegis.Character.Stats
{
    public class StatSet
    {
        public Stat<int> Health { get; private set; }
        public Stat<int> MaxHealth { get; private set; }
        public Stat<int> Energy { get; private set; }
        public Stat<int> Strength { get; private set; }

        private LinkedList<BuffShell> buffs;

        public StatSet()
        {
            Health = new Stat<int>(100);
            MaxHealth = new Stat<int>(100);
            Energy = new Stat<int>(100);
            Strength = new Stat<int>(10);

            buffs = new LinkedList<BuffShell>();
        }
        
        public void AddBuff(IBuff buff)
        {
            BuffShell shell = new BuffShell(buff);
            buffs.AddLast(shell);
        }

        public void Update()
        {
            foreach (BuffShell buff in buffs.TraverseRemove(b => b.IsDestroyed))
            {
                buff.Update();
            }
        }
    }
}
