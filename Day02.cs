namespace AdventOfCode2025
{
    public class Day02
    {
        public static void Part01()
        {
            using (var reader = File.OpenText("inputs/day02.txt"))
            {
                var line = reader.ReadToEnd();
                var items = line.Split(',');
                long invalidIdTotal = 0;
                int count = 0;

                foreach (var item in items)
                {
                    var split = item.Split('-');
                    var range = new List<int>();

                    var start = long.Parse(split[0]);
                    var end = long.Parse(split[1]);

                    for (long i = start; i <= end; i++)
                    {
                        var text = i.ToString();
                        if (text.Length % 2 != 0) continue;

                        var left = text.Substring(0, text.Length / 2);
                        var right = text.Substring(text.Length / 2);

                        if (left == right)
                        {
                            count++;
                            invalidIdTotal += i;
                        }
                    }
                }
                Console.WriteLine($"{count} palindromic numbers, Sum: {invalidIdTotal}");
            }
        }

        public static void Part02()
        {
            using (var reader = File.OpenText("inputs/day02.txt"))
            {
                var line = reader.ReadToEnd();
                var items = line.Split(',');
                long invalidIdCount = 0;
                long invalidIdTotal = 0;

                foreach (var item in items)
                {
                    var split = item.Split('-');
                    var start = long.Parse(split[0]);
                    var end = long.Parse(split[1]);

                    for (long i = start; i <= end; i++)
                    {
                        var num = i.ToString();
                        var maxDigit = num.Length;
                        for (var j = 1; j <= num.Length / 2; j++)
                        {
                            var subset = num.Substring(0, j);
                            if (num.Length % subset.Length == 0)
                            {
                                var copiesCount = num.Length / subset.Length;
                                var outstring = "";
                                for (var k = 0; k < copiesCount; k++) outstring += subset;
                                if(outstring == num)
                                {
                                    invalidIdCount++;
                                    invalidIdTotal += i;
                                    break;
                                }
                            }
                        }

                    }
                }

                Console.WriteLine($"{invalidIdCount} invalid Ids, totalling {invalidIdTotal}");
            }
        }
    }
}
