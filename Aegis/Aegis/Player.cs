using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameBase;
using GameBase.Graphics;

using Keys = Microsoft.Xna.Framework.Input.Keys;

namespace Aegis
{
    public class Player : GameObject
    {
        MapView view;

        public Player(MapView viewToManage)
        {
            this.sprite = new Sprite2d("temp");

            this.position.X = 100;
            this.position.Y = 100;

            this.view = viewToManage;
        }

        protected override void LoadObjectContent(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            //NOOP
        }

        protected override void UpdateObject(Microsoft.Xna.Framework.GameTime gameTime)
        {
            const float moveSpeed = 5;
            GameVector offset = new GameVector(0,0);

            var keyboardState = GameState.Keyboard;
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                offset.Y = -moveSpeed;
            }
            else if (keyboardState.IsKeyDown(Keys.Down))
            {
                offset.Y = moveSpeed;
            }

            if (keyboardState.IsKeyDown(Keys.Left))
            {
                offset.X = -moveSpeed;
            }
            else if (keyboardState.IsKeyDown(Keys.Right))
            {
                offset.X = moveSpeed;
            }

            this.position += offset;

            //Make a bullet
            if (keyboardState.IsKeyDown(Keys.Space))
            {
                this.map.AddObject(new Pew(this.position.X, this.position.Y));
            }

            //Move the camera
            UpdateView();
        }

        private void UpdateView()
        {
            const float cameraSpeed = 4.5f; //Set this to 5 to get rid of the slingshot effect
            const float cameraMargin = 0.45f;

            float xoff = this.position.X - view.GamePosition.X;
            float yoff = this.position.Y - view.GamePosition.Y;

            GameVector move = new GameVector(0, 0);
            if (xoff > (1-cameraMargin)*view.Width)
            {
                move.X = cameraSpeed;
            }
            else if (xoff < cameraMargin*view.Width)
            {
                move.X = -cameraSpeed;
            }

            if (yoff > (1 - cameraMargin) * view.Height)
            {
                move.Y = cameraSpeed;
            }
            else if (yoff < cameraMargin * view.Height)
            {
                move.Y = -cameraSpeed;
            }

            view.Move(move, this.map.Width, this.map.Height);
        }
    }
}
