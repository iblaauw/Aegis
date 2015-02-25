using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameBase;

namespace Aegis
{
    class GameManager : IGameStateManager
    {
        const int mapSize = 640;
        GameBase.Game game;

        public GameManager()
        {
        }

        public GameMap InitializeFirstMap(Game game)
        {
            this.game = game;
            GameMap map = game.CreateMap(mapSize, mapSize);
            return map;
        }

        public void OnInitialize()
        {
            throw new NotImplementedException();
        }

        public void OnLoad()
        {
            throw new NotImplementedException();
        }

        public void OnUnload()
        {
            throw new NotImplementedException();
        }

        public void OnUpdate()
        {
            throw new NotImplementedException();
        }
    }
}
