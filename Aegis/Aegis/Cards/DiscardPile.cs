using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aegis.Cards
{
    public class DiscardPile
    {
        public List<Card> graveyard = new List<Card>();

        public DiscardPile()
        {

        }

        public void Add(Card in_Card)
        {
            if (in_Card != Card.NO_CARD)
            {
                //Fire the event
                if (CardAdded != null)
                    CardAdded(in_Card);

                graveyard.Add(in_Card);
            }
        }

        public List<Card> All()
        {
            return graveyard;
        }

        public void Clear()
        {
            graveyard.Clear();
        }

        public event Action<Card> CardAdded;
    }
}
