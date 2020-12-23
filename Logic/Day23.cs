using System.Collections.Generic;
using System.Linq;
using Logic.Helpers;

namespace Logic
{
    public class Day23
    {
        private Dictionary<int, CupNode> lookup;
        private CupNode[] cupArray;

        public long Part1(List<int> input, int moves)
        {
            Run(input, moves);

            var node = lookup[1];
            string result = string.Empty;

            for (int i = 0; i < 8; i++)
            {
                result += node.Next.Value;
                node = node.Next;
            }

            return long.Parse(result);
        }

        public long Part2(List<int> input, int moves)
        {
            input.AddRange(Enumerable.Range(input.Max() + 1, 1000000 - input.Count));

            Run(input, moves);

            var Node1 = lookup[1];
            return Node1.Next.Value * Node1.Next.Next.Value;
        }

        private void Run(List<int> input, int moves)
        {
            int highest = input.Max();

            cupArray = new CupNode[input.Count];

            InitLinkedList(input);

            lookup = cupArray.ToDictionary(x => x.Value, y => y);
            var currentNode = lookup[input[0]];

            for (int i = 0; i < moves; i++)
            {
                var cutpoint = currentNode.Next;
                currentNode.Next = currentNode.Next.Next.Next.Next;

                var destination = GetDestination(currentNode.Value, cutpoint, highest);
                var insertionPoint = lookup[destination];

                CupNode insertionPointNext = insertionPoint.Next;
                CupNode tail = cutpoint.Next.Next;
                tail.Next = insertionPointNext;
                insertionPoint.Next = cutpoint;

                currentNode = currentNode.Next;
            }
        }

        private void InitLinkedList(List<int> input)
        {
            cupArray[0] = new CupNode(input[1]);
            CupNode prev = cupArray[0];

            for (int i = 0; i < input.Count; i++)
            {
                var crabNode = new CupNode(input[i]);
                cupArray[i] = crabNode;
                prev.Next = crabNode;
                prev = crabNode;
            }

            prev.Next = cupArray[0];
        }

        private int GetDestination(int start, CupNode cuttingPoint, int highestId)
        {
            int dest = start == 1 ? highestId : start - 1;

            List<int> picks = new List<int>
            {
                cuttingPoint.Value,
                cuttingPoint.Next.Value,
                cuttingPoint.Next.Next.Value
            };

            while (picks.Contains(dest))
            {
                dest--;
                if (dest <= 0)
                {
                    dest = highestId;
                }
            }

            return dest;
        }
    }
}
