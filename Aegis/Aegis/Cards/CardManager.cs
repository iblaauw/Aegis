using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameBase;
using Aegis.Cards;
using Aegis.Keyboard;
using Keys = Microsoft.Xna.Framework.Input.Keys;

namespace Aegis.Cards
{
    class CardManager : GameObject
    {
        private Deck deck = new Deck();
        private Hand hand;
        private DiscardPile discardPile = new DiscardPile();
        private ButtonState buttonState = new ButtonState();

        public CardManager(GameMap in_Map)
        {
            Card staticCard = new Card("staticCard");
            this.hand = new Hand(staticCard, in_Map);
            in_Map.AddObject(this.hand);
            in_Map.AddObject(this.deck);
        }

        protected override void LoadObjectContent(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            //NOOP
        }

        protected override void UpdateObject(Microsoft.Xna.Framework.GameTime gameTime)
        {
            if (buttonState.IsKeyPressedOnce(KeyBindings.Card1))
            {
                Card card = hand.Play(0);
                discardPile.Add(card);
            }
            else if (buttonState.IsKeyPressedOnce(KeyBindings.Card2))
            {
                Card card = hand.Play(1);
                discardPile.Add(card);
            }
            else if (buttonState.IsKeyPressedOnce(KeyBindings.Card3))
            {
                Card card = hand.Play(2);
                discardPile.Add(card);
            }
            else if (buttonState.IsKeyPressedOnce(KeyBindings.Card4))
            {
                Card card = hand.Play(3);
                discardPile.Add(card);
            }
            else if (buttonState.IsKeyPressedOnce(KeyBindings.StaticCard))
            {
                Card card = hand.Play(Hand.STATIC);
            }
            else if (buttonState.IsKeyPressedOnce(KeyBindings.AddCard))
            {
                if (!hand.HandFull() && !deck.Empty())
                {
                    Card newCard = deck.DrawCard();
                    hand.AddToHand(newCard);
                }
            }
            else if (buttonState.IsKeyPressedOnce(KeyBindings.ReshuffleDeck))
            {
                deck.ShuffleIn(discardPile.All());
                discardPile.Clear();
            }
        }

        private void UpdateView()
        {
            // NOOP
        }
    }
}
