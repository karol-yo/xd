using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
namespace ConsoleApp1
{
    class Table
    {
        public static List<string> Names = new() { "Emanuel", "Borys", "Alex", "Alan", "Fabian", "Konstanty", "Marcel", "Lucjan", "Michał", "Florian", "Eugeniusz", "Albert", "Oskar", "Anatol",
        "Bernadetta", "Kornelia", "Regina", "Wiktoria", "Agata","Maja", "Marcelina", "Ida", "Balbina", "Żaneta", "Kornelia", "Julita", "Honorata", "Oliwia"};
        public int HowMuch { get; set; }
        public int HowMany { get; set; }
        public string Winner { get; set; }
        public string Date { get; set; }
        public int WinningBet { get; set; }
        public int YourBet { get; set; }
        public int AllMoneyBet { get; set; }
        public static void NewTable(int playerIndex)
        {
            Table table = new()
            {
                HowMany = -1,
                HowMuch = -1,
                Date = Convert.ToString(DateTime.UtcNow),
                WinningBet = -1,
                YourBet = -1
            };
            while (true)
            {
                Console.WriteLine("ilu chcesz przeciwnikow ");
                table.HowMany = Convert.ToInt32(Console.ReadLine());
                if (table.HowMany <= 0)
                {
                    Console.WriteLine("liczba przeciwnikow musi byc wieksza niz 0");
                }
                else if (table.HowMany > 7)
                {
                    Console.WriteLine("stol ma tylko 7 miejsc");
                }
                else
                {
                    break;
                }
            }
            while (true)
            {
                Console.WriteLine("ile pieniedzy chcesz obstawic ");
                table.HowMuch = Convert.ToInt32(Console.ReadLine());
                if (table.HowMuch > User.GetBalance(playerIndex - 1))
                {
                    Console.WriteLine("nie masz tyle kasy (masz " + User.GetBalance(playerIndex - 1) + ")");
                }
                else if (table.HowMuch <= 0)
                {
                    Console.WriteLine("nie mozesz obstawic 0 lub mniej");
                }
                else
                {
                    break;
                }
            }
            Random random = new();
            table.WinningBet = random.Next(0, 36);
            Console.WriteLine("twoje obstawienie wyniku ruletki ");
            table.YourBet = Convert.ToInt32(Console.ReadLine());
            int amountOfNPCWinners = 0;
            int MoneyBet = 0;
            for (int x = 1; x <= table.HowMany; x++)
            {
                int BotBet = random.Next(0, 36);
                if (BotBet == table.WinningBet)
                {
                    amountOfNPCWinners++;
                }
                int BotMoneyBet = random.Next(69, 4200);
                MoneyBet += BotMoneyBet;
            }
            MoneyBet += table.HowMuch;
            table.AllMoneyBet = MoneyBet;
            string path = Directory.GetCurrentDirectory();
            string userSerialized = File.ReadAllText(path + @"Users\user" + (playerIndex - 1) + ".json");
            User userDeserialized = JsonConvert.DeserializeObject<User>(userSerialized);
            if (Convert.ToInt32(table.YourBet) == table.WinningBet)
            {
                userDeserialized.Balance += table.HowMuch * 2;
                if (amountOfNPCWinners == 0)
                {
                    Console.WriteLine("wygrales!");
                }
                else if (amountOfNPCWinners > 1)
                {
                    Console.WriteLine("wygrales, tak samo jak " + amountOfNPCWinners + " innych graczy!");
                }
                else
                {
                    Console.WriteLine("wygrales, tak samo jak 1 inny gracz!");
                }
                Console.WriteLine("w portfelu masz " + userDeserialized.Balance + " pieniedzy");
                table.Winner = userDeserialized.Name;
            }
            else if (amountOfNPCWinners != 0)
            {
                userDeserialized.Balance -= table.HowMuch;
                for (int x = 0; x != amountOfNPCWinners; x++)
                {
                    table.Winner += Names[random.Next(0, 27)];
                    if (x < amountOfNPCWinners - 1)
                    {
                        table.Winner += ", ";
                    }
                }
                Console.WriteLine("wygrywajacy numer to " + table.WinningBet + ", a wygrani to " + table.Winner + "\nty niestety przegrales, a w portfelu zostalo ci " + userDeserialized.Balance);
            }
            else
            {
                userDeserialized.Balance -= table.HowMuch;
                Console.WriteLine("wszyscy przegrali, w portfelu zostalo ci " + userDeserialized.Balance);
            }
            string userSerializedAfter = JsonConvert.SerializeObject(userDeserialized);
            File.WriteAllText(path + @"Users\user" + (playerIndex - 1) + ".json", userSerializedAfter);
            int tableCount = Convert.ToInt32(File.ReadAllText(path + @"Table Counter.txt"));
            tableCount++;
            string tableSerialized = JsonConvert.SerializeObject(table);
            File.WriteAllText(path + @"Match History\table " + tableCount + ".json", tableSerialized);
            File.WriteAllText(path + @"Table Counter.txt", Convert.ToString(tableCount));
        }
    }
}
