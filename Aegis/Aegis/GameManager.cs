using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameBase;

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
            GameMap map = game.CreateMap(WINDOW_WIDTH, WINDOW_HEIGHT);

            GameBase.Graphics.Background background = new GameBase.Graphics.Background("background");
            map.AddObject(background);

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
            //NOOP
        }
    }
}
