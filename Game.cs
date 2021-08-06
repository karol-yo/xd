using System;

namespace ConsoleApp1
{
    class Game
    {
        public static int FirstLobby()
        {
            while (true)
            {
                if (User.NumberOfProfiles() == 0)
                {
                    Console.WriteLine("nie znaleziono zadnego profilu, musisz stworzyc nowy");
                    User.CreateProfile();
                }
                int choice = User.ChooseProfile();
                if (choice == (User.NumberOfProfiles() + 1))
                {
                    User.CreateProfile();
                }
                else if (choice == (User.NumberOfProfiles() + 2))
                {
                    Console.WriteLine("ktory profil chcesz usunac");
                    User.ListOfProfiles();
                    int deleting = Convert.ToInt32(Console.ReadLine());
                    User.DeleteProfile(deleting);
                }
                else if (choice > 0 & choice <= User.NumberOfProfiles())
                {
                    return choice;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
        }
        public static int SecondLobby(int whichOne)
        {
            while (true)
            {
                Console.WriteLine("[1] graj\n[2] sprawdz portfel\n[3] wyjdz");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    return choice;
                }
                else if (choice == 2)
                {
                    Console.WriteLine(User.GetBalance(whichOne));
                }
                else if (choice == 3)
                {
                    return -1;
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
        }
    }
}
