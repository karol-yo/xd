using System;

namespace ConsoleApp1
{
    public static class Program
    {

        static void Main(string[] args)
        {
            Initializing.FolderCheck();
            Console.WriteLine("ruleta siema");
            while (true)
            {
                int whosPlaying = Game.FirstLobby();
                Game.SecondLobby(whosPlaying);
                Table.NewTable(whosPlaying);
            }
        }
    }
}
