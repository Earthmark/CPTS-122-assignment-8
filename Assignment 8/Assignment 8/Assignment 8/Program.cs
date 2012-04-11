using System;

namespace Assignment_8
{
#if WINDOWS || XBOX
    static class Program
    {
        //http://www.xnadevelopment.com/tutorials/theroadnottaken/theroadnottaken.shtml
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (GameTrack game = new GameTrack())
            {
                game.Run();
            }
        }
    }
#endif
}

