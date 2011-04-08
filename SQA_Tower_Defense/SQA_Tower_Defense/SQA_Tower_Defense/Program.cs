using System;

namespace SQA_Tower_Defense
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Map game = new Map())
            {
                game.Run();
            }
        }
    }
#endif
}

