using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aegis.Character.Stats
{
    abstract class StatAdjuster
    {
        protected IModifier parent;
        protected StatAdjuster(IModifier parent)
        {
            this.parent = parent;
            IsDestroyed = false;
        }

        public bool IsDestroyed { get; protected set; }

        public abstract bool IsPersistent { get; }

        public abstract void Destroy();
    }

    public abstract class StatAdjuster<T> : StatAdjuster
    {
        private Stat<T> stat;

        public StatAdjuster(Stat<T> stat, IModifier parent) : base(parent)
        {
            this.stat = stat;
        }

        public abstract void Adjust(ref T val);

        public sealed override void Destroy()
        {
            IsDestroyed = true;
            stat.Refresh();
        }
    }
}
