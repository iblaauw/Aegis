using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameBase;
using Aegis.Cards;
using Keys = Microsoft.Xna.Framework.Input.Keys;

namespace Aegis.Cards
{
    class CardManager : GameObject
    {
        private Deck deck = new Deck();
        private Hand hand;
        private DiscardPile discardPile = new DiscardPile();

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
            var keyboardState = GameState.Keyboard;

                if (keyboardState.IsKeyDown(KeyBindings.Card1))
                {
                    try
                    {
                        Card card = hand.Play(0);
                        discardPile.graveyard.Add(card);
                    }
                    catch (Exception e)
                    {
                        //NOOP
                    }
                }
                else if (keyboardState.IsKeyDown(KeyBindings.Card2))
                {
                    try
                    {
                        Card card = hand.Play(1);
                        discardPile.graveyard.Add(card);
                    }
                    catch (Exception e)
                    {
                        //NOOP
                    }
                }
                else if (keyboardState.IsKeyDown(KeyBindings.Card3))
                {
                    try
                    {
                        Card card = hand.Play(2);
                        discardPile.graveyard.Add(card);
                    }
                    catch (Exception e)
                    {
                        //NOOP
                    }
                }
                else if (keyboardState.IsKeyDown(KeyBindings.Card4))
                {
                    try
                    {
                        Card card = hand.Play(3);
                        discardPile.graveyard.Add(card);
                    }
                    catch (Exception e)
                    {
                        //NOOP
                    }
                }
                else if (keyboardState.IsKeyDown(KeyBindings.StaticCard))
                {
                    Card card = hand.Play(Hand.STATIC);
                }
                else if (keyboardState.IsKeyDown(KeyBindings.AddCard))
                {
                    try
                    {
                        Card newCard = deck.DrawCard();
                        hand.AddToHand(newCard);
                    }
                    catch (Exception e)
                    {
                        //nOOP
                    }
                }
                else if (keyboardState.IsKeyDown(KeyBindings.ReshuffleDeck))
                {
                    if (discardPile.graveyard.Count != 0)
                    {
                        deck.ShuffleIn(discardPile.graveyard);
                        discardPile.graveyard.Clear();
                    }
                }
        }

        private void UpdateView()
        {
            // NOOP
        }
    }
}
