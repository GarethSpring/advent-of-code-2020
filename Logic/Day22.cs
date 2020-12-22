using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class Day22
    {
        List<int> p1;
        List<int> p2;
       
        public long Part1(List<int> p1, List<int> p2)
        {
            this.p1 = p1;
            this.p2 = p2;

            return Play1();
        }

        public long Part2(List<int> p1, List<int> p2)
        {
            int winner = 0;
            return Recurse2(p1, p2, ref winner);;
        }

        private long Recurse2(List<int> lp1, List<int> lp2, ref int winner)
        {
            List<List<int>> prevP1 = new List<List<int>>();
            List<List<int>> prevP2 = new List<List<int>>();

            while (lp1.Count != 0 && lp2.Count != 0)
            {

                for (int i = 0; i < prevP1.Count; i++)
                {
                    if (Enumerable.SequenceEqual(prevP1[i], lp1) && Enumerable.SequenceEqual(prevP2[i], lp2))
                    {
                        // Player 1 wins
                        winner = 1;
                        return CalcScore(lp1);
                    }
                }

                prevP1.Add(lp1.ToList());
                prevP2.Add(lp2.ToList());

                bool p1ShouldRecurse = lp1[0] <= lp1.Count - 1;
                bool p2ShouldRecurse = lp2[0] <= lp2.Count - 1;

                if (p1ShouldRecurse && p2ShouldRecurse)
                {
                    // New game
                    Recurse2(lp1.Skip(1).Take(lp1[0]).ToList(), lp2.Skip(1).Take(lp2[0]).ToList(), ref winner);

                    if (winner == 1)
                    {
                        lp1.Add(lp1[0]);
                        lp1.Add(lp2[0]);
                        lp1.RemoveAt(0);

                        lp2.RemoveAt(0);
                    }
                    else if (winner == 2)
                    {
                        lp2.Add(lp2[0]);
                        lp2.Add(lp1[0]);
                        lp2.RemoveAt(0);
                        lp1.RemoveAt(0);
                    }
                }
                else
                {
                    winner = ActionWin(lp1, lp2);
                }

            }

            if (lp1.Count == 0)
            {
                winner = 2;
                return CalcScore(lp2);
            }

            winner = 1;

            return CalcScore(lp1);
        }

        private int ActionWin(List<int> lp1, List<int> lp2)
        {
            if (lp1[0] > lp2[0])
            {
                lp1.Add(lp1[0]);
                lp1.Add(lp2[0]);
                lp1.RemoveAt(0);
                lp2.RemoveAt(0);
                return 1;
            }

            lp2.Add(lp2[0]);
            lp2.Add(lp1[0]);
            lp2.RemoveAt(0);
            lp1.RemoveAt(0);

            return 2;
        }

        private long Play1()
        {
            while (p1.Count != 0 && p2.Count != 0)
            {
                if (p1[0] > p2[0])
                {
                    p1.Add(p1[0]);
                    p1.Add(p2[0]);
                    p1.RemoveAt(0);

                    p2.RemoveAt(0);
                }
                else
                {
                    p2.Add(p2[0]);
                    p2.Add(p1[0]);
                    p2.RemoveAt(0);
                    p1.RemoveAt(0);
                }

            }

            return p1.Count == 0 ? CalcScore(p2) : CalcScore(p1);
        }

        private long CalcScore(List<int> cards)
        {
            long score = 0;
            int multiplier = 1;

            for (int i = cards.Count - 1; i >= 0; i--)
            {
                score += cards[i] * multiplier;
                multiplier++;
            }

            return score;
        }
    }
}
