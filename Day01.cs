namespace AdventOfCode2025
{
    public class Day01
    {
        public static void Part01()
        {
            using (var reader = File.OpenText("inputs/day01.txt"))
            {
                var dialValue = 50;
                var line = "";
                var numberOfZeros = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    var direction = line[0] == 'L' ? -1 : 1;
                    int.TryParse(line.Substring(1), out int distance);

                    if (distance > 100) distance = distance % 99 - distance / 99;

                    dialValue += direction * distance;

                    if (dialValue > 99) dialValue -= 100;
                    else if (dialValue < 0) dialValue += 100;
                    if (dialValue == 0) numberOfZeros++;
                }

                Console.WriteLine(numberOfZeros);
                Console.ReadKey();
            }
        }

        public static void Part02()
        {
            using (var reader = File.OpenText("inputs/day01.txt"))
            {
                var dialValue = 50;
                var line = "";
                var numberOfZeros = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    var direction = line[0] == 'L' ? -1 : 1;
                    int.TryParse(line.Substring(1), out int distance);

                    numberOfZeros += distance / 100;

                    distance = distance % 100;

                    var oldDial = dialValue;
                    var nextDial = direction * distance + dialValue;
                    dialValue = (nextDial + 100) % 100;

                    if (oldDial != 0 && (dialValue == 0 || dialValue != nextDial))
                    {
                        numberOfZeros++;
                    }
                }

                Console.WriteLine(numberOfZeros);
            }
        }
    }
}
