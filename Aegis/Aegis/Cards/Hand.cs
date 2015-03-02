using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameBase;

namespace Aegis.Cards
{
    class Hand : GameObject
    {
        public const int STATIC = -1;
        private Card staticCard;
        private List<Card> cardsInHand = new List<Card>();
        private GameVector startPosition = new GameVector(290, 487);

        public Hand(Card in_staticCard, GameMap in_Map)
        {
            staticCard = in_staticCard;
            staticCard.SetLocation(startPosition.X - 50, startPosition.Y);
            staticCard.status = STATUS.NORMAL;
            in_Map.AddObject(staticCard);
        }

        public void AddToHand(Card inCard)
        {
            inCard.SetLocation(cardsInHand.Count * 50 + startPosition.X, startPosition.Y);
            this.cardsInHand.Add(inCard);
            inCard.status = STATUS.NORMAL;
            this.map.AddObject(inCard);
        }

        public Card Play(int index)
        {
            if (index != STATIC)
            {
                Card cardPlayed = cardsInHand[index];
                Discard(index);
                return cardPlayed;
            }
            else
            {
                return staticCard;
            }
        }

        public Card Discard(int index)
        {
            Card discardCard = cardsInHand.ElementAt(index);
            cardsInHand.RemoveAt(index);
            this.map.RemoveObject(discardCard);
            return discardCard;
        }
        
        protected override void LoadObjectContent(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            //NOOP
        }

        protected override void UpdateObject(Microsoft.Xna.Framework.GameTime gameTime)
        {
            //NOOP
        }

    }
}
