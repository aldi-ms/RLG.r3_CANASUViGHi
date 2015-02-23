using System;
using System.Collections.Generic;
using System.Linq;

using RLG.R3_CANASUViGHi.Engine;

namespace RLG.R3_CANASUViGHi
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class GameMain
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            using (var game = new GameEngine())
            {
                game.Run();
            }
        }
    }
#endif
}
