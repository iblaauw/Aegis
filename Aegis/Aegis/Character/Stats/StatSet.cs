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

        private LinkedList<ModifierShell> modifiers;

        private Dictionary<Type, LinkedList<ModifierShell>> modifierMap;

        public StatSet()
        {
            Health = new Stat<int>(100);
            MaxHealth = new Stat<int>(100);
            Energy = new Stat<int>(100);
            Strength = new Stat<int>(10);

            modifiers = new LinkedList<ModifierShell>();
            modifierMap = new Dictionary<Type,LinkedList<ModifierShell>>();
        }
        
        public void AddBuff(IModifier buff)
        {
            ModifierShell shell = new ModifierShell(buff);
            modifiers.AddLast(shell);

            Type type = buff.GetType();
            LinkedList<ModifierShell> list;
            if (!modifierMap.TryGetValue(type, out list))
            {
                list = new LinkedList<ModifierShell>();
                modifierMap[type] = list;
            }
            list.AddLast(shell);
        }

        public void Update()
        {
            foreach (ModifierShell buff in modifiers.TraverseRemove(b => b.IsDestroyed))
            {
                buff.Update();
            }
        }

        /// <summary>
        /// Returns a list of all the modifiers which are of type T currently attached to this StatSet
        /// Takes inheritance into account.
        /// </summary>
        public IEnumerable<ModifierShell> GetModifiersForType<T>() where T : class, IModifier
        {
            foreach (var keyvalue in modifierMap)
            {
                Type type = keyvalue.Key;
                if (!typeof(T).IsAssignableFrom(type))
                    continue;

                foreach (ModifierShell mod in keyvalue.Value.TraverseRemove(m => m.IsDestroyed))
                {
                    yield return mod;
                }
            }
        }
    }
}
