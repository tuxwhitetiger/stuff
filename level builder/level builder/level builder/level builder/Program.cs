using System;

namespace level_builder
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (levelBuilder game = new levelBuilder())
            {
                game.Run();
            }
        }
    }
#endif
}

