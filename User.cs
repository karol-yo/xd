using System;
using Newtonsoft.Json;
using System.IO;
namespace ConsoleApp1
{
    public class User
    {
        public int Balance  { get; set; }
        public string Name  { get; set; }
        /*public Guid Id { get; set; }
        public static int ProfileCounter { get; set; }
        public static void FirstOpen()
        {
            string Path = Directory.GetCurrentDirectory();
            if (File.Exists(Path + @"Users.json"))
            {
                Console.WriteLine("podaj nazwe profilu ");
                string Nickname = Console.ReadLine();
                Guid GuidId = Guid.NewGuid();
                ProfileCounter++;
                User user = new()
                {
                    Name = Nickname,
                    Balance = 1000,
                    Id = GuidId
                };

            }
        }*/
        public static int NumberOfProfiles()
        {
            string path = Directory.GetCurrentDirectory();
            int Amount = 0;
            while (true)
            {
                if (File.Exists(path + @"Users\user"+ Amount + ".json") == true)
                {
                    Amount += 1;
                }
                else
                {
                    break;
                }
            }
            return Amount;
        }
        public static void CreateProfile()
        {
            Console.WriteLine("podaj nazwe profilu ");
            string nickName = Console.ReadLine();
            User user = new()
            {
                Name = nickName,
                Balance = 1000
            };
            string userSerialized = JsonConvert.SerializeObject(user);
            string path = Directory.GetCurrentDirectory();
            File.WriteAllText(path + @"Users\user" + NumberOfProfiles() + ".json", userSerialized);
        }
        public static void DeleteProfile(int whichOne)
        {
            string path = Directory.GetCurrentDirectory();
            int numberOfProfiles = NumberOfProfiles();
            File.Delete(path + @"Users\user" + (whichOne - 1) + ".json");
            if (whichOne < numberOfProfiles)
            {
                for (int x = whichOne; x != numberOfProfiles; x++)
                {
                    File.Move(path + @"Users\user" + x + ".json", path + @"Users\user" + (x - 1) + ".json");
                }
            }
        }
        public static int ChooseProfile()
        {
            Console.WriteLine("wybierz profil, stworz nowy lub usun istniejacy ");
            int numberOfProfiles = NumberOfProfiles();
            ListOfProfiles();
            Console.WriteLine("[" + (numberOfProfiles + 1) + "] Stworz nowy profil");
            Console.WriteLine("[" + (numberOfProfiles + 2) + "] Usun istniejacy profil ");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice > 0 & choice <= (numberOfProfiles + 2))
            {
                return choice;
            }
            else
            {
                Console.WriteLine("error");
                return -1;
            }
        }
        /*public static string FirstOpen()
        {
            string path = Directory.GetCurrentDirectory();
            if (File.Exists(path + @"user1.json") == true)
            {
                return "not1st";
            }
            else
            {
                Console.WriteLine("podaj nazwe ");                                             PROTOTYP KREACJI PROFILU
                string nickName = Console.ReadLine();
                User user = new()
                {
                    Name = nickName,
                    Balance = 1000
                };
                string userSerialized = JsonConvert.SerializeObject(user);
                File.WriteAllText(path + @"user1.json", userSerialized);
                return "1st";
            }
        }*/
        public static string GetName(int whichOne)
        {
            string path = Directory.GetCurrentDirectory();
            string userSerialized = File.ReadAllText(path + @"Users\user" + whichOne + ".json");
            User userDeserialized = JsonConvert.DeserializeObject<User>(userSerialized);
            return userDeserialized.Name;
        }
        public static int GetBalance(int whichOne)
        {
            string path = Directory.GetCurrentDirectory();
            string userSerialized = File.ReadAllText(path + @"Users\user" + (whichOne) + ".json");
            User userDeserialized = JsonConvert.DeserializeObject<User>(userSerialized);
            return userDeserialized.Balance;
        }
        public static void ListOfProfiles()
        {
            Console.WriteLine("lista wszystkich profilow: ");
            int numberOfProfiles = NumberOfProfiles();
            for (int userIndex = 0; userIndex < numberOfProfiles; userIndex++)
            {
                Console.WriteLine("[" + (userIndex + 1) + "] " + GetName(userIndex));
            }
        }
        /*public static int Choice()                                                TUTAJ JAKIS SYF CO GO NIE POWINNO BYC W TEJ KLASIE
        {                                                                              TEZ PROTOTYPY CHYBA JAKIES W MIARE TAKIE
            var choice = Console.ReadLine();
            bool intTest = int.TryParse(choice, out int number);
            if (intTest == true & number > 0 & number < 37)
            {
                return number;
            }
            else
            {
                return 0;
            }
        }
        public static string TypeOfBet()
        {
            Console.WriteLine("[1] zero \n[2] parzyste\n[3] nieparzyste\n[4] konkretny numer\n[5] pierwsza polowa\n[6] druga polowa");
            var choice = Console.ReadLine();
            bool intTest = int.TryParse(choice, out int number);
            if (intTest == true)
            {
                switch (Convert.ToInt32(choice))
                {
                    case 1:
                        return "zero";
                    case 2:
                        return "parzyste";
                    case 3:
                        return "nieparzyste";
                    case 4:
                        return "konk";
                    case 5:
                        return "1sthalf";
                    case 6:
                        return "2ndhalf";
                    default:
                        return "error";

                }
            }
            else
            {
                return "error";
            }
        }
        public static string ChoiceOfBet2()
        {
            TypeOfBet();
        }
        */
    }
}
