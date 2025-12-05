namespace AdventOfCode2025
{
    public class Day05
    {
        public static void Part01()
        {
            using (var reader = File.OpenText("inputs/day05.txt"))
            {
                var freshIds = new List<IdRange>();
                var idsComplete = false;
                var line = "";
                var freshCount = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line == "")
                    {
                        idsComplete = true;
                        continue;
                    }
                    if (!idsComplete)
                    {
                        freshIds.Add(new IdRange(line));
                    }
                    else
                    {
                        var id = long.Parse(line);
                        if (freshIds.Any(x => x.IsInRange(id))) freshCount++;
                    }
                }
                Console.WriteLine(freshCount);
            }
        }
        public static void Part02()
        {
            using (var reader = File.OpenText("inputs/day05.txt"))
            {
                var freshIds = new List<IdRange>();
                var idsComplete = false;
                var line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    if (line == "")
                    {
                        idsComplete = true;
                        break;
                    }
                    if (!idsComplete)
                    {
                        var newRange = new IdRange(line);

                        var upperOverlap = freshIds.FirstOrDefault(x => x.IsInRange(newRange.upper));
                        var lowerOverlap = freshIds.FirstOrDefault(x => x.IsInRange(newRange.lower));

                        if (upperOverlap != null)
                        {
                            newRange.upper = upperOverlap.lower-1;
                                
                        }
                        if (lowerOverlap != null)
                        {
                            newRange.lower = lowerOverlap.upper+1;
                        }

                        if (newRange.upper > newRange.lower || newRange.lower == newRange.upper) 
                        {
                            freshIds.Add(newRange);
                        }
                    }
                }
                var orderd = freshIds.OrderByDescending(x => x.lower).ToList();
                var totalFresh = freshIds.Sum(x => x.NumberInRange());
                Console.WriteLine(totalFresh);
            }
        }

        public class IdRange
        {
            public IdRange() { }
            public IdRange(string line)
            {
                var split = line.Split('-');
                lower = long.Parse(split[0]);
                upper = long.Parse(split[1]);
            }
            public long lower { get; set; }
            public long upper { get; set; }
            public bool IsInRange(long id)
            {
                return id >= lower && id <= upper;
            }
            public long NumberInRange()
            {
                return upper - lower + 1;
            }
        }
    }
}
