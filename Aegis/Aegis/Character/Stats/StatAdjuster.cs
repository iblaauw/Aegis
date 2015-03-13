using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aegis.Character.Stats
{
    abstract class StatAdjuster
    {
        protected IBuff parent;
        protected StatAdjuster(IBuff parent)
        {
            this.parent = parent;
            IsDestroyed = false;
        }

        public bool IsDestroyed { get; protected set; }

        //TODO: consider moving this into IBuff?
        public abstract bool IsGoodBuff { get; }

        public abstract bool IsPermanent { get; }

        public abstract void Destroy();
    }

    public abstract class StatAdjuster<T> : StatAdjuster
    {
        private Stat<T> stat;
        private IBuff parent;

        public StatAdjuster(Stat<T> stat, IBuff parent) : base(parent)
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
