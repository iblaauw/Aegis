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
        private Dictionary<Type, IBuff> buffMap;

        public StatSet()
        {
            Health = new Stat<int>(100);
            MaxHealth = new Stat<int>(100);
            Energy = new Stat<int>(100);
            Strength = new Stat<int>(10);

            modifiers = new LinkedList<ModifierShell>();
            modifierMap = new Dictionary<Type,LinkedList<ModifierShell>>();
            buffMap = new Dictionary<Type, IBuff>();
        }
        
        public void AddModifier(IModifier modifier)
        {
            ModifierShell shell = new ModifierShell(modifier);

            modifiers.AddLast(shell);

            //Fire the event
            if (ModifierAdded != null)
                ModifierAdded(shell);

            Type type = modifier.GetType();
            LinkedList<ModifierShell> list;
            if (!modifierMap.TryGetValue(type, out list))
            {
                list = new LinkedList<ModifierShell>();
                modifierMap[type] = list;
            }
            list.AddLast(shell);
        }

        //TODO: the registration collection should be created inside here!!! Not passed in.
        public void AddBuff(IBuff buff, BuffRegistrationCollection eventSet)
        {
            //Fire the event! We want to fire it even if it gets ignored. It fires everytime someone tries to add one.
            if (BuffAdded != null)
                BuffAdded(buff);

            Type buffType = buff.GetType();
            if (buffMap.ContainsKey(buffType))
            {
                if (!buffMap[buffType].AllowOverwrite(buff))
                    return;
            }

            buffMap[buffType] = buff;

            buff.RegisterForEvents(eventSet);
        }

        public void RemoveBuff(IBuff buff)
        {
            if (buff == null)
                throw new ArgumentNullException();
            
            Type buffType = buff.GetType();
            
            if (buffMap[buffType].Equals(buff))
                buffMap.Remove(buffType);
        }

        public void RemoveBuffByType<T>() where T : IBuff
        {
            buffMap.Remove(typeof(T));
        }

        public void Update()
        {
            foreach (ModifierShell buff in modifiers.TraverseRemove(b => b.IsDestroyed))
            {
                buff.Update();
            }

            foreach (var keyvalue in buffMap)
            {
                keyvalue.Value.Update();
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

        /// <summary>
        /// If this stat set contains a buff of the given type, then it will return the one it has. Otherwise
        /// it returns null.
        /// 
        /// NOTE: This will NOT take inheritance into account!
        /// </summary>
        public T GetBuff<T>() where T : class, IBuff
        {
            if (!buffMap.ContainsKey(typeof(T)))
                return null;

            return buffMap[typeof(T)] as T;
        }

        public event Action<ModifierShell> ModifierAdded;
        public event Action<IBuff> BuffAdded;
    }
}
