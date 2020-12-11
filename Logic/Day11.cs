using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Logic
{
    public class Day11
    {
        private Dictionary<(int x, int y), char> prev;
        private Dictionary<(int x, int y), char> current;

        private List<(int, int)> directionModifiers = new List<(int, int)>
        {
            (-1, 0), (1, 0), (0, -1), (0, 1), (-1, -1), (-1, 1), (1, -1), (1, 1)
        };

        public int Part1()
        {
            current = ReadInput();
            prev = current.ToDictionary(entry => entry.Key, entry => entry.Value);

            while (true)
            {
                CheckOccupancy();

                if (Compare<(int, int), char>(prev, current))
                {
                    break;
                }

                prev = current.ToDictionary(entry => entry.Key, entry => entry.Value);
            }

            return current.Values.Count(x => x == '#');
        }

        public int Part2()
        {
            current = ReadInput();
            prev = current.ToDictionary(entry => entry.Key, entry => entry.Value);

            while (true)
            {
                CheckOccupancySecondRuleSet();

                if (Compare<(int, int), char>(prev, current))
                {
                    break;
                }

                prev = current.ToDictionary(entry => entry.Key, entry => entry.Value); 
            }

            return current.Values.Count(x => x == '#');
        }

        private void CheckOccupancy()
        {
            foreach (var a in prev.Keys)
            {
                // Check if empty should become occupied
                if (prev[a] == 'L')
                {
                    bool empty = true;
                    foreach (var m in directionModifiers)
                    {
                        prev.TryGetValue((a.x + m.Item1, a.y + m.Item2), out char e);
                        if (e == '#')
                        {
                            empty = false;
                        }
                    }

                    if (empty)
                    {
                        current[a] = '#';
                    }
                }
                else if (prev[a] == '#')
                {
                    if (directionModifiers.Sum(m => CountAdjacentOccupied(a, m.Item1, m.Item2)) >= 4)
                    {
                        current[a] = 'L';
                    }
                }
            }
        }

        private void CheckOccupancySecondRuleSet()
        {
            foreach (var k in prev.Keys.Where(k => prev[k] != '.'))
            {
                int count = directionModifiers.Sum(m => AdjacentOccupied(k, m.Item1, m.Item2));

                if (prev[k] == 'L')
                {
                    if (count == 0)
                    {
                        current[k] = '#';
                    }
                }
                else if (prev[k] == '#')
                {
                    if (count >= 5)
                    {
                        current[k] = 'L';
                    }
                }
            }

            return;
        }

        private int AdjacentOccupied((int x, int y) seat, int xModifier, int yModifier)
        {
            int yMod = yModifier;
            int xMod = xModifier;

            while (prev.TryGetValue((seat.x + xModifier, seat.y + yModifier), out char s))
            {
                if (s == '#')
                {
                    return 1;
                }

                if (s == 'L')
                {
                    return 0;
                }

                xModifier = xMod != 0 ? xModifier + xMod : xModifier;
                yModifier = yMod != 0 ? yModifier + yMod : yModifier;
            }

            return 0;
        }

        private int CountAdjacentOccupied((int, int) seat, int xMod, int yMod)
        {
            prev.TryGetValue((seat.Item1 + xMod, seat.Item2 +yMod), out char c);

            return c == '#' ? 1 : 0;
        }
 
        private Dictionary<(int, int), char> ReadInput()
        {
            var tmp = new Dictionary<(int, int), char>();

            var input = File.ReadAllLines(Environment.CurrentDirectory + "/Input/Input11.txt");

            int y = 0;
            foreach ( var line in input)
            {
                for(int x = 0; x < line.Length; x++)
                {
                    tmp.Add((x, y), line[x]);
                }
                y++;
            }

            return tmp;
        }

        public bool Compare<TKey, TValue>(Dictionary<TKey, TValue> d1, Dictionary<TKey, TValue> d2)
        {
            IEqualityComparer<TValue> valueComparer = EqualityComparer<TValue>.Default;

            return d1.Count == d1.Count &&
                    d1.Keys.All(key => d2.ContainsKey(key) && valueComparer.Equals(d1[key], d2[key]));
        }
    }
}