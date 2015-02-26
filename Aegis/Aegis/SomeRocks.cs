using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameBase;

namespace Aegis
{
    public class SomeRocks : GameObject
    {
        public SomeRocks(int x, int y)
        {
            this.position = new GameVector(x, y);

            //Something to note: this image is transparent, but because the background is bright pink.
            //Specifically the RGB has to be 255,0,255. It will by default choose that color as "transparent".
            this.sprite = new GameBase.Graphics.Sprite2d("rocks");

            //This shoves the rocks farther back as part of the background
            //If you don't do this, then it will have weird effects when two things are on top of each other
            this.Depth = 5;

            //for collision detection
            this.mask = new GameBase.Graphics.RectangleMask(0, 32, 0, 32);
        }

        protected override void LoadObjectContent(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            //NOOP
        }

        protected override void UpdateObject(Microsoft.Xna.Framework.GameTime gameTime)
        {
            //NOOP
            //Rocks don't do anything
        }
    }
}
