namespace AdventOfCode2025
{
    public class Day03
    {
        public static void Part01()
        {
            using (var reader = File.OpenText("inputs/day03.txt"))
            {
                var totalJoltage = 0;
                var line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    char battery1 = line[0];
                    char battery2 = line[1];

                    for (int i = 2; i < line.Length; i++)
                    {
                        if (battery2 > battery1)
                        {
                            battery1 = battery2;
                            battery2 = line[i];
                        }
                        else battery2 = line[i] > battery2 ? line[i] : battery2;
                    }
                    totalJoltage += int.Parse($"{battery1}{battery2}");
                }

                Console.WriteLine(totalJoltage);
                Console.ReadKey();
            }
        }

        public static void Part02()
        {
            using (var reader = File.OpenText("inputs/day03.txt"))
            {
                long totalJoltage = 0;
                var line = "";
                var batterySize = 12;

                while ((line = reader.ReadLine()) != null)
                {
                    var lastPosition = 0;
                    var joltage = "";

                    for (int i = 0; i < batterySize; i++)
                    {
                        char biggest = '0';
                        for (int j = lastPosition; j < line.Length - batterySize + i + 1; j++)
                        {
                            if (line[j] > biggest)
                            {
                                biggest = line[j];
                                lastPosition = j;
                            }
                        }
                        lastPosition += 1;
                        joltage += biggest;
                    }
                    totalJoltage += long.Parse(joltage);
                }

                Console.WriteLine(totalJoltage);
                Console.ReadKey();
            }
        }
    }
}
