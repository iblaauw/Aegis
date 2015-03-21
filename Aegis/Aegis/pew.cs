using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameBase;
using GameBase.Graphics;

namespace Aegis
{
    public class Pew : GameObject
    {
        GameVector speed;
        bool fuse;
        int fuseLen;

        public Pew(float x, float y)
        {
            this.position.X = x;
            this.position.Y = y;

            this.speed = new GameVector(10, 0);

            this.sprite = new Sprite2d("pewpew");

            //For collision detection
            this.mask = new RectangleMask(0, 16, 0, 16);

            fuse = false;
            fuseLen = 100;
        }

        protected override void LoadObjectContent(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            //NOOP
        }

        protected override void UpdateObject(Microsoft.Xna.Framework.GameTime gameTime)
        {
            
            if (map.CollidingWith<SomeRocks>(this).Any())
            {
                Random rand = new Random();
                speed.X = rand.Next(-10, 10);
                speed.Y = rand.Next(-10, 10);
                fuse = true;
            }

            if (fuse)
            {
                fuseLen--;
                if (fuseLen == 0)
                {
                    map.AddObject(new Explosion(this.position.X, this.position.Y));
                    map.RemoveObject(this);
                }
            }

            this.position += speed;

            if (this.position.X > map.Width + 16)
                map.RemoveObject(this);
        }
    }
}
