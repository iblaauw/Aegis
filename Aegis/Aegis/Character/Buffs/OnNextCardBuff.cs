using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aegis.Character.Buffs
{
    public abstract class OnNextCardBuff : TimedBuff
    {
        public OnNextCardBuff(int time)
            : base(time)
        { }

        public override void ActualRegisterForEvents()
        {
            RegistrationSet.hand.CardPlayed += this.InternalOnPlay;
        }

        private void InternalOnPlay(Cards.Card card)
        {
            OnPlay(card);

            RegistrationSet.hand.CardPlayed -= this.InternalOnPlay;
            RemoveSelf();
        }

        public abstract void OnPlay(Cards.Card card);
    }
}
