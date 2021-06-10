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
            bool gameContinues = true;
            while (gameContinues)
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
                        gameContinues = false;
                        break;
                }
            }
        }
    }
}
