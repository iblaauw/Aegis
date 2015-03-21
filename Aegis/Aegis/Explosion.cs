using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameBase;
using GameBase.Graphics;

namespace Aegis
{
    class Explosion : GameObject
    {
        Sprite2d spriteInternal;
        public Explosion(float x, float y)
        {
            this.position.X = x;
            this.position.Y = y;

            this.spriteInternal = new Sprite2d("explosion", 64, 64, 25);
            this.sprite = spriteInternal;
        }

        protected override void LoadObjectContent(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            //NOOP
        }

        protected override void UpdateObject(Microsoft.Xna.Framework.GameTime gameTime)
        {
            spriteInternal.StepAnimation();
            if (spriteInternal.StripPosition == 0)
                map.RemoveObject(this);
        }
    }
}
