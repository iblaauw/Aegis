using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameBase;
using Aegis.Character.Stats;
using Aegis.Character.Buffs;
using Aegis.Cards;

namespace Aegis.Character
{
    public abstract class GameCharacter : GameObject
    {
        public StatSet Stats { get; protected set; }
        protected Deck CharacterDeck { get; set; }
        protected Hand CharacterHand { get; set; }
        protected DiscardPile Discard { get; set; }

        //TODO: In the future add these here
        //  BuffBar

        public void AddBuff(IBuff buff)
        {
            this.Stats.AddBuff(buff, this.GenerateEventSet());
        }

        //TODO: Make it so that this doesn't regenerate a new one each time... It can be reused.
        private BuffRegistrationCollection GenerateEventSet()
        {
            return new BuffRegistrationCollection() { 
                deck = CharacterDeck, discard = Discard, 
                hand = CharacterHand, stats = Stats
            };
        }
    }
}
