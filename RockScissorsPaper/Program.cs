using System;
using System.Linq;

namespace RockScissorsPaper
{
    internal class Program
    {
        internal static int userStep;
        static void Main(string[] args)
        {
            var userInputArgs = args;
            var userInputArgsLen = userInputArgs.Length;

            if (userInputArgsLen < 3 || (userInputArgsLen % 2 == 0))
            {
                Console.WriteLine("Incorrect number of parameters. Please enter 3 or more moves (odd number). Example: \"Rock Scissor Parper\"");
                Environment.Exit(0);
            }
            else if (args.Length != userInputArgs.Distinct().Count())
            {
                Console.WriteLine("Parameters contain duplicate values. Please enter 3 or more moves (odd number). Example: \"Rock Scissor Parper\"");
                Environment.Exit(0);
            }

            GameRules currentGame = new GameRules(userInputArgs, userInputArgsLen);

            currentGame.InputComputerStep();
            currentGame.Menu();
            currentGame.TableGen();
            inputUserStep(userInputArgsLen);

            currentGame.AllSteps();
            currentGame.Wins();
        }

        private static void inputUserStep(int userInputArgsLen)
        {
            Console.Write("Please, enter your move: ");
            var input = Console.ReadLine();

            if (int.TryParse(input, out userStep))
            {
                if (userStep == 0)
                {
                    Environment.Exit(0);
                }
                else if (userStep <= userInputArgsLen & userStep > 0)
                {
                    userStep--;
                }
                else
                {
                    Console.WriteLine($"Please choose one of Menu options.");
                }
            }
            else if (input == "?")
            {
                Table table = new Table(GameRules.possibleMoves);
                table.ShowTable();
                inputUserStep(userInputArgsLen);
            }
            else
            {
                Console.WriteLine($"Please choose one of Menu options.");
            }
        }
    }
}
