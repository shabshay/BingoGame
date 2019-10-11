using Bingo52on25.Model;
using System;
using static System.Console;

namespace Bingo52on25
{
    public class Program
    {
        private const int range = 52;
        private const int size = 5;

        static void Main(string[] args)
        {
            StartBingoGame();
        }

        private static void StartBingoGame()
        {
            Clear();
            WriteLine("Starting a new game...");

            BingoGame game = new BingoGame(range, size);
            game.StartNewGame();

            PrintBoard(game.Board);

            while (!game.IsOver)
            {
                WriteLine("Press any key to draw a number...");
                ReadKey();
                Clear();

                int randNum = game.DrawNextNumber();
                WriteLine($"Drawn number is {randNum}");
                PrintBoard(game.Board);
            }

            WriteLine("Bingo! game is over...");
            CheckForRestart();
        }

        private static void CheckForRestart()
        {
            WriteLine("Would you like to start a new game? [y/n]");
            var input = ReadKey();
            WriteLine();

            switch (input.Key)
            {
                case ConsoleKey.Y:
                    StartBingoGame();
                    break;

                case ConsoleKey.N:
                    Environment.Exit(0);
                    break;
            }

            // continue while invalid input
            CheckForRestart();
        }

        private static void PrintBoard(BingoBoard board)
        {
            WriteLine("Board:");
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    var cell = board[i, j];
                    if (cell.IsMarked)
                    {
                        BackgroundColor = ConsoleColor.Blue;
                    }
                    Write($"{cell.Value}\t");
                    ResetColor();
                }
                WriteLine();
            }
        }
    }
}
