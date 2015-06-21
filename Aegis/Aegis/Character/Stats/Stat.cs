using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Aegis.Character.Stats
{
    public class Stat<T> where T : struct
    {
        private T baseVal;
        private T value;
        private bool needsRefresh;
        private LinkedList<StatAdjuster<T>> adjusters;

        public Stat(T baseValue)
        {
            baseVal = baseValue;
            value = baseValue;
            needsRefresh = false;
            adjusters = new LinkedList<StatAdjuster<T>>();
        }

        public T Value
        {
            get { return GetValueInternal(); }
        }

        public void AddAdjuster(StatAdjuster<T> adj)
        {
            if (!adj.IsPersistent)
                adj.Adjust(ref baseVal);
            else
                adjusters.AddLast(adj);
            needsRefresh = true;
        }

        public void Refresh()
        {
            needsRefresh = true;
        }

        private T GetValueInternal()
        {
            if (!needsRefresh)
                return value;

            T originalValue = value;
            value = baseVal;

            foreach (StatAdjuster<T> adj in adjusters.TraverseRemove(a => a.IsDestroyed))
            {
                adj.Adjust(ref value);
            }

            needsRefresh = false;
            return value;
        }

    }
}
