namespace AdventOfCode2025
{
    public class Day04
    {
        public static void Part01()
        {
            var grid = wrapGrid(File.ReadAllLines("inputs/day04.txt"));
            var accesibleRolls = 0;
            for (int y = 1; y < grid.Length - 1; y++)
            {
                for (int x = 1; x < grid[y].Length - 1; x++)
                {
                    var cell = grid[y][x];
                    var tpCount = 0;
                    if (grid[y][x] == '@')
                    {
                        if (grid[y - 1][x - 1] == '@') tpCount++; // UL
                        if (grid[y - 1][x] == '@') tpCount++; // UM
                        if (grid[y - 1][x + 1] == '@') tpCount++; // UR
                        if (grid[y][x - 1] == '@') tpCount++; // L
                        if (grid[y][x + 1] == '@') tpCount++; // R
                        if (grid[y + 1][x - 1] == '@') tpCount++; // DL
                        if (grid[y + 1][x] == '@') tpCount++; //DM
                        if (grid[y + 1][x + 1] == '@') tpCount++; //DR
                    }

                    if (cell != '.' && tpCount < 4) accesibleRolls++;
                }
            }
            Console.WriteLine($"Found {accesibleRolls} accessible rolls of toilet paper");
            Console.ReadKey();
        }

        public static void Part02()
        {
            var grid = wrapGrid(File.ReadAllLines("inputs/day04.txt"));
            var totalRolls = 0;
            var accesibleRolls = 0;
            var nextGrid = new List<string>();
            do
            {
                accesibleRolls = 0;
                if (nextGrid.Count > 0) grid = wrapGrid(nextGrid.ToArray());
                nextGrid = new List<string>();
                for (int y = 1; y < grid.Length - 1; y++)
                {
                    var nextGridLine = "";
                    for (int x = 1; x < grid[y].Length - 1; x++)
                    {
                        var cell = grid[y][x];
                        var tpCount = 0;
                        if (grid[y][x] == '@')
                        {
                            if (grid[y - 1][x - 1] == '@') tpCount++; // UL
                            if (grid[y - 1][x] == '@') tpCount++; // UM
                            if (grid[y - 1][x + 1] == '@') tpCount++; // UR
                            if (grid[y][x - 1] == '@') tpCount++; // L
                            if (grid[y][x + 1] == '@') tpCount++; // R
                            if (grid[y + 1][x - 1] == '@') tpCount++; // DL
                            if (grid[y + 1][x] == '@') tpCount++; //DM
                            if (grid[y + 1][x + 1] == '@') tpCount++; //DR
                        }

                        if (cell != '.' && tpCount < 4)
                        {
                            accesibleRolls++;
                            nextGridLine += '.';
                        }
                        else
                        {
                            nextGridLine += cell;
                        }
                    }
                    nextGrid.Add(nextGridLine);
                }
                totalRolls += accesibleRolls;
            } while (accesibleRolls > 0);

            Console.WriteLine($"Found a total of {totalRolls} accessible rolls of toilet paper");
            Console.ReadKey();
        }

        public static string[] wrapGrid(string[] grid)
        {
            var result = new List<string>() { new string('.', grid[0].Length + 2) };

            foreach (string cell in grid)
            {
                result.Add($".{cell}.");
            }

            result.Add(new string('.', grid[0].Length + 2));
            return result.ToArray();
        }
    }
}
