using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame_Pexeso
{
    static class MainMenu
    {
        public enum MenuStates
        {
            ClassicGame = 0,
            CustomGame = 1,
            HowToPlay = 2,
            End = 3
        }

        public static int ShowMainMenu()
        {

            int selectedItem = 0;
            int enumLenght;
            bool selectionFinished = false;
            ConsoleKeyInfo PressedKey;

            Console.Clear();

            while (!selectionFinished)
            {
                Console.SetCursorPosition(0, 3);
                enumLenght = Enum.GetNames(typeof(MenuStates)).Length; //Enum.GetNames(typeof(ManuStates)).Length return number of names is enum

                for (int i = 0; i < enumLenght; i++)  
                {
                    if (selectedItem == i)
                        Console.BackgroundColor = ConsoleColor.Blue;

                    Console.WriteLine((MenuStates)i);
                    Console.ResetColor();
                }

                PressedKey = Console.ReadKey(true); //when true => character wont show up in console

                if (PressedKey.Key == ConsoleKey.DownArrow && selectedItem < enumLenght - 1) //setup a limit so you cannot go out of selection menu
                    selectedItem++;

                else if (PressedKey.Key == ConsoleKey.UpArrow && selectedItem > 0) //setup a limit so you cannot go out of selection menu
                    selectedItem--;

                else if (PressedKey.Key == ConsoleKey.Enter) //confirm your selection
                    selectionFinished = true;
            }
            return selectedItem; //return selected item id
        }

        public static void Instructions()
        {
            Console.WriteLine("Goal of this game is to find 2 matching pairs of cards.");
            Console.WriteLine("Game ends when you find them all\n");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nPress any key to continue.");
            Console.ResetColor();
        }
    }
}
