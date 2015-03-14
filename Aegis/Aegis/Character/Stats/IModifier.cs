using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aegis.Character.Stats
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
