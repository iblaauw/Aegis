using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameBase;
using Aegis.Cards;

namespace Aegis
{
    class GameManager : IGameStateManager
    {
        public const int WINDOW_WIDTH = 800;
        public const int WINDOW_HEIGHT = 600;

        GameBase.Game game;

        public GameManager()
        {
        }

        public GameMap InitializeFirstMap(Game game)
        {
            this.game = game;
            GameMap map = game.CreateMap(2*WINDOW_WIDTH, 2*WINDOW_HEIGHT);
            
            //Setting up the view
            //NOTE: you almost always want the last two to be window width and height.
            //  If you don't you can get weird effects (which would be desirable only for things like split screen)
            MapView view = new MapView(new GameVector(0, 0), new GameVector(0, 0), WINDOW_WIDTH, WINDOW_HEIGHT);
            map.Views.Add(view);

            GameBase.Graphics.Background background = new GameBase.Graphics.Background("background");

            //Add all the objects to the map
            map.AddObject(background);
            map.AddObject(new Player(view));
            map.AddObject(new SomeRocks(300, 250));
            map.AddObject(new SomeRocks(1430, 500));
            map.AddObject(new SomeRocks(1050, 972));

            map.AddObject(new CardManager(map));

            return map;
        }

        public void OnInitialize()
        {
            //NOOP
        }

        public void OnLoad()
        {
            //NOOP
        }

        public void OnUnload()
        {
            //NOOP
        }

        public void OnUpdate()
        {
            if (GameState.Keyboard.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Escape))
                game.Exit();

            if (GameState.Keyboard.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.C))
            {
                GameMap newMap = game.CreateMap(WINDOW_WIDTH, WINDOW_HEIGHT);

                MapView view = new MapView(new GameVector(), new GameVector(), newMap.Width, newMap.Height);
                newMap.AddObject(new Player(view));
                newMap.AddObject(new SomeRocks(50, 50));

                GameMap oldMap = game.CurrentMap;
                game.SwitchToMap(newMap);
            }
        }
    }
}
