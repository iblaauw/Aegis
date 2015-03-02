using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameBase;
using GameBase.Graphics;

namespace Aegis.Cards
{
    class Deck : GameObject
    {
        private List<Card> library = new List<Card>();
            
        public Deck()
        {
            Random r = new Random(DateTime.Now.Millisecond);

            for (int i =0; i < 10; ++i)
            {
                Card card;
                int rand = r.Next(100);
                if (rand > 75)
                    card = new Card("redCard");
                else if (rand > 50)
                    card = new Card("staticCard");
                else if (rand > 25)
                    card = new Card("emptyCard");
                else
                    card = new Card("rocks");

                library.Add(card);
            }
            this.sprite = new Sprite2d("Deck");
            this.position = new GameVector(550, 330);
            this.StaticView = true;
        }

        public Deck(List<Card> in_Library)
        {
            library = in_Library;
            this.sprite = new Sprite2d("Deck");
            this.position = new GameVector(550, 330);
            this.StaticView = true;
        }

        public List<Card> DrawCards(int count)
        {
            List<Card> drawnCards = library.GetRange(0, count);
            library.RemoveRange(0, count);
            return drawnCards;
        }

        public Card DrawCard()
        {
            Card drawnCard = library.First();
            library.RemoveAt(0);
            return drawnCard;
        }

        public void PutOnTop(Card in_Card)
        {
            library.Insert(0, in_Card);
            //this.sprite = new Sprite2d(library.Count.ToString());
        }

        public void ShuffleIn(List<Card> in_List)
        {
            library.AddRange(in_List);
            Shuffle(library);
            //this.sprite = new Sprite2d(library.Count.ToString());
        }

        public void ShuffleIn(Card in_Card)
        {
            library.Add(in_Card);
            Shuffle(library);
            //this.sprite = new Sprite2d(library.Count.ToString());
        }

        public void Shuffle()
        {
            Shuffle(library);
        }

        static public void Shuffle(List<Card> list)
        {
            Random rand = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rand.Next(n + 1);
                Card value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
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
