using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame_Pexeso
{
    class Program
    {
        static void Main(string[] args)
        {
            bool gameContinues = true;

            while (gameContinues)
            {
                switch ((MainMenu.MenuStates)MainMenu.ShowMainMenu())
                {
                    case MainMenu.MenuStates.ClassicGame:
                        Console.Clear();

                        break;

                    case MainMenu.MenuStates.CustomGame:

                        break;

                    case MainMenu.MenuStates.HowToPlay:
                        Console.Clear();
                        MainMenu.Instructions();
                        Console.ReadKey(true);
                        break;

                    case MainMenu.MenuStates.End:
                        gameContinues = false;
                        break;
                }
            }
        }
    }
}
