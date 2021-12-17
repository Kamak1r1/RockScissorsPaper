using System;
using System.Collections.Generic;

namespace RockScissorsPaper
{
    internal class GameRules
    {
        internal static string[] userInput;
        internal static int userInputLen;
        internal static int computerStep;
        internal static string key;
        internal static List<List<object>> possibleMoves = new List<List<object>>();

        public GameRules(string[] args, int len)
        {
            userInput = args;
            userInputLen = len;
        }

        internal void InputComputerStep()
        {
            computerStep = new Random().Next(userInputLen);
            key = HMAС.GenerateHMAC(userInput[computerStep]);
        }

        internal void Menu()
        {
            Console.WriteLine("\nAvailable moves:");
            for (int i = 0; i < userInputLen; i++)
            {
                Console.WriteLine($"{i + 1} - {userInput[i]}");
            }
            Console.WriteLine("0 - Exit\n? - Help\n");
        }

        public void TableGen()
        {
            possibleMoves.Add(FillField());
            for (int i = 1; i < userInputLen; i++)
            {
                possibleMoves.Add(ShiftField(possibleMoves[i - 1]));
            }
        }

        private List<object> FillField()
        {
            List<object> currentMoves = new List<object>();
            for (int i = 0; i < userInputLen; i++)
            {
                object temp = (i == 0) ? "Draw" :
                    (i <= (userInputLen - 1) / 2) ? "Win!" :
                        (i < userInputLen) ? "Lose!" : "";
                currentMoves.Add(temp);
            }
            return currentMoves;
        }
        private List<object> ShiftField(List<object> previousString)
        {
            List<object> temp = new List<object>();
            temp.AddRange(previousString.GetRange(userInputLen - 1, 1));
            temp.AddRange(previousString.GetRange(0, userInputLen - 1));
            return temp;
        }
        private void ShowComputerStep()
        {
            Console.WriteLine($"\nComputer move is No. {computerStep + 1}: {userInput[computerStep]}");
        }
        private void ShowUserStep()
        {
            Console.WriteLine($"Your move is No. {Program.userStep + 1}: {userInput[Program.userStep]}");
        }
        internal void AllSteps()
        {
            ShowComputerStep();
            ShowUserStep();
        }

        internal void Wins()
        {
            Console.WriteLine($"\n{possibleMoves[computerStep][Program.userStep]}\nKey: {key}\n");
        }
    }
}
