using System;
using GameBase;

namespace Aegis
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            IGameStateManager manager = new GameManager();
            using (GameBase.Game game = new GameBase.Game(manager))
            {
                game.Run();
            }
        }
    }
#endif
}

