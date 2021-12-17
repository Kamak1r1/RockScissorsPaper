using ConsoleTableExt;
using System.Collections.Generic;


namespace RockScissorsPaper
{
    internal class Table
    {
        private static string[] nameOfColumns = new string[GameRules.possibleMoves[0].Count + 1];
        private static List<List<object>> roundTable;

        internal Table(List<List<object>> inputGameTable)
        {
            roundTable = inputGameTable;
        }
        internal void ShowTable()
        {
            RebuildTable();
            DrawTable();
        }
        private static void RebuildTable()
        {
            nameOfColumns[0] = $"Computer \\ Player";
            for (int i = 1; i < nameOfColumns.Length; i++)
            {
                nameOfColumns[i] = $"{i}";
                roundTable[i - 1].Insert(0, i);
            }
        }

        internal static void DrawTable()
        {
            ConsoleTableBuilder.From(roundTable).WithColumn(nameOfColumns).ExportAndWriteLine();
        }
    }
}
