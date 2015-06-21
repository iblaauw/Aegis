using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aegis.Character.Buffs;

namespace Aegis.Character.Stats
{
    public abstract class StatAdjuster
    {
        protected IModifier parent;
        protected StatAdjuster(IModifier parent)
        {
            this.parent = parent;
            IsDestroyed = false;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsDestroyed { get; protected set; }

        /// <summary>
        /// If this is false, then this adjuster is applied once, permanently. This case
        ///     is mainly used for Health
        /// If this is true, then the adjuster is kept in the system until it says that it is destroyed.
        /// </summary>
        public abstract bool IsPersistent { get; }

        public abstract void Destroy();
    }

    public abstract class StatAdjuster<T> : StatAdjuster where T : struct
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
