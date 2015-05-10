using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameBase;
using GameBase.Graphics;

namespace Aegis.Cards
{
    public class Card : GameObject
    {
        public const Card NO_CARD = null;
        protected string name;
        
        public Card(string in_Name)
        {
            this.name = in_Name;
            this.sprite = new GameBase.Graphics.Sprite2d(in_Name);
            this.position = new GameVector(300, 300);
            this.StaticView = true;
        }

        public string GetName()
        {
            return this.name;
        }

        public void SetLocation(float x, float y)
        {
            this.position.X = x;
            this.position.Y = y;
        }

        public void ModifyCard(string in_Name)
        {
            this.name = in_Name;
            this.sprite = new Sprite2d(in_Name);
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
