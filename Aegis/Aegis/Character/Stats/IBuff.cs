using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aegis.Character.Stats
{
    public interface IBuff
    {
        //VisualBuff Visual { get; }
        //BuffProperties Properties { get; }
        void Attach(StatSet set);
        void Update();
        IEnumerable<StatAdjuster> GetAdjusters();
    }
}
