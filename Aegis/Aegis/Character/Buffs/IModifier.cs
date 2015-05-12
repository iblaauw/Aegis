using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aegis.Character.Stats;

namespace Aegis.Character.Buffs
{
    public interface IModifier
    {
        //VisualBuff Visual { get; }
        //BuffProperties Properties { get; }
        bool IsGood { get; }
        void Attach(StatSet set);
        void Update();
        IEnumerable<StatAdjuster> GetAdjusters();
    }
}
