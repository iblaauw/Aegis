using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameBase;

namespace Aegis.Cards
{
    public class Hand : GameObject
    {
        #region Statics
        public const int STATIC = -1;
        private static GameVector START_POSITION = new GameVector(290, 487);
        private static int CARD_WIDTH = 50;
        #endregion

        private Card staticCard;
        private SortedList<int, Card> cardsInHand = new SortedList<int, Card>();

        /// <summary>
        /// Initializes Hand object with a specified static card.
        /// GameMap argument is needed to initialize display of static card.
        /// </summary>
        /// <param name="in_staticCard"></param>
        /// <param name="in_Map"></param>
        public Hand(Card in_staticCard, GameMap in_Map)
        {
            for (int i = 0; i < 4; ++i)
                cardsInHand.Add(i, Card.NO_CARD);

            staticCard = in_staticCard;
            staticCard.SetLocation(START_POSITION.X - CARD_WIDTH, START_POSITION.Y);
            staticCard.status = STATUS.NORMAL;
            in_Map.AddObject(staticCard);
        }

        /// <summary>
        /// Adds in_Card to hand and displays the card to the screen.
        /// Throws Exception when hand is already full prior to call.
        /// </summary>
        /// <param name="in_Card">Card to add to hand</param>
        public void AddToHand(Card in_Card)
        {
            int cardIndex = cardsInHand.IndexOfValue(Card.NO_CARD);
            if (cardIndex == -1)
            {
                throw new Exception("Hand is full");
            }

            in_Card.SetLocation(cardIndex * CARD_WIDTH + START_POSITION.X, START_POSITION.Y);
            this.cardsInHand[cardIndex] = in_Card;
            in_Card.status = STATUS.NORMAL;
            this.map.AddObject(in_Card);
        }

        /// <summary>
        /// Executes the functionality of the card at the specified index in the hand.
        /// Removes the card from the hand and returns a reference to the played card.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Returns Card.NO_CARD if index is invalid</returns>
        public Card Play(int index)
        {
            Card playedCard = Card.NO_CARD;

            if (index == STATIC)
            {
                playedCard = staticCard;

                //Fire event
                if (StaticPlayed != null)
                    StaticPlayed(staticCard);
            }
            else if (cardsInHand[index] != Card.NO_CARD)
            {
                playedCard = cardsInHand[index];

                //Fire event
                if (CardPlayed != null)
                    CardPlayed(playedCard);

                Discard(index);
            }

            return playedCard;
        }

        /// <summary>
        /// Discards the card at the specified index by removing it from the hand.
        /// Returns a reference to the removed card.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Returns Card.NO_CARD when index is invalid.</returns>
        public Card Discard(int index)
        {
            Card discardedCard = cardsInHand[index];

            cardsInHand[index] = Card.NO_CARD;

            //Fire event
            if (CardDiscarded != null)
                CardDiscarded(discardedCard);

            if (discardedCard != Card.NO_CARD)
                this.map.RemoveObject(discardedCard);

            return discardedCard;
        }

        /// <summary>
        /// Returns true if hand has reached capacity. False otherwise.
        /// This call is O(n) unfortunately for the time being. This <i>should</i> be O(1).
        /// </summary>
        /// <returns></returns>
        public bool HandFull()
        {
            // If updated to be O(1) instead of O(n), modify XML documentation.
            return cardsInHand.IndexOfValue(Card.NO_CARD) == -1;
        }
        
        protected override void LoadObjectContent(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            //NOOP
        }

        protected override void UpdateObject(Microsoft.Xna.Framework.GameTime gameTime)
        {
            //NOOP
        }

        /// <summary>
        /// This does not include when the static is played!
        /// </summary>
        public event Action<Card> CardPlayed;
        public event Action<Card> StaticPlayed;
        public event Action<Card> CardDiscarded;
    }
}
