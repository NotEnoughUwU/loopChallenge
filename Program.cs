using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loppChallenge
{
    internal class Program
    {
        static int x = 0, y = 0;
        static bool gameOver;
        static void Main(string[] args)
        {
            while (true)
            {
                PlayerDraw();
                PlayerUpdate();
                if (gameOver)
                    break;
            }
            Console.Clear();
        }
        static void PlayerDraw()
        {
            Console.Clear();
            Console.SetCursorPosition(x,y);
            Console.Write("☻");
        }
        static void PlayerUpdate()
        {
            System.ConsoleKeyInfo inputKey = Console.ReadKey(true);
            char inputChar = inputKey.KeyChar;
            DecideAction(inputChar);

            if (inputKey.Key == ConsoleKey.Escape)
                gameOver = true;
        }
        static void DecideAction(char inputChar)
        {
            if (inputChar == 'w')
                y--;
            else if (inputChar == 's')
                y++;
            else if (inputChar == 'd')
                x++;
            else if (inputChar == 'a')
                x--;

            KeepInRange();
            ClearInputBuffer();
        }
        static void KeepInRange()
        {
            if (x < 1)
                x = 0;
            if (y < 0)
                y = 0;

            if (x >= Console.WindowWidth)
                x = Console.WindowWidth - 1;
            if (y >= Console.WindowHeight)
                y = Console.WindowHeight - 1;
        }
        static void ClearInputBuffer()
        {
            while (Console.KeyAvailable)
                Console.ReadKey(true);
        }
    }
}