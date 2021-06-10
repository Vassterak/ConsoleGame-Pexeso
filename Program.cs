using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame_Pexeso
{
    class Program
    {
        static GameWorld gameworld;
        static void Main(string[] args)
        {
            switch ((MainMenu.MenuStates)MainMenu.ShowMainMenu()) //MainMenu.ShowMainMenu() returns id of selected item that is instantly translated to string value of that id.
            {
                case MainMenu.MenuStates.ClassicGame: //ClassicGame has id 0;
                    Console.Clear();
                    gameworld = new GameWorld();

                    break;

                case MainMenu.MenuStates.CustomGame: //ClassicGame has id 1;

                    break;

                case MainMenu.MenuStates.HowToPlay: //ClassicGame has id 2;
                    Console.Clear();
                    MainMenu.Instructions();
                    Console.ReadKey(true);
                    break;

                case MainMenu.MenuStates.End: //ClassicGame has id 3;
                    System.Environment.Exit(0);
                    break;
            }

            while (!gameworld.AllShown())
            {
                gameworld.RenderMap();
                int x = -1, y = -1;

                do
                {
                    Console.Write("Enter the X(pos. in row, starts from 1) coordinaties of your card: ");
                    x = int.Parse(Console.ReadLine());
                    Console.Write("Enter the Y(pos in collum, starts from 1) coordinaties of your card: ");
                    y = int.Parse(Console.ReadLine());

                    if (!gameworld.CardValidityChecker(x, y)) //if y make a typo....                                  ←
                        Console.WriteLine("The coordinates which you entered are not valid! Please try it again.");

                } while (!gameworld.CardValidityChecker(x, y)); //same here. It was easier to make an extra condition ↑ to write down the error.
            }
        }
    }
}
