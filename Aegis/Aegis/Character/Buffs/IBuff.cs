using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aegis.Character.Stats;

namespace Aegis.Character.Buffs
{
    public class BuffRegistrationCollection
    {
        public Cards.Deck deck;
        public Cards.DiscardPile discard;
        public Cards.Hand hand;
        public StatSet stats;
    }

    public interface IBuff
    {
        /// <summary>
        /// This is called when the buff is added to a set. It is used to allow the buff to hook into the correct
        /// events for things like card drawing, attacks incoming, attacks outgoing, etc.
        /// </summary>
        void RegisterForEvents(BuffRegistrationCollection eventSet);

        /// <summary>
        /// This is called when a buff is applied to a character, but that buff already exists. It allows buffs 
        /// with stacking mechanisms to handle things themselves. 
        /// If false is returned, the new buff is discarded. If true is returned, this current buff will be immediately destroyed
        /// and replaced with the incoming one.
        /// </summary>
        /// <returns>Whether the incoming buff overwrites the current one.</returns>
        bool AllowOverwrite(IBuff buffOverwriting);

        /// <summary>
        /// Called per game tick.
        /// </summary>
        void Update();
    }

}
