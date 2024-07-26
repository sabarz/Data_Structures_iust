using System;
using System.Collections.Generic;

namespace _3_hash_substring
{
    class Program
    {
        public static long PolyHash(string s)
        {
            long ans = 0, x = 256, pmode = (long)Math.Pow(10, 9) + 7;

            for (int i = s.Length - 1; i >= 0; i--)
            {
                ans = (ans * x + s[i]) % pmode;
            }
            return ans;
        }
        public static long[] PreComputeHashes(string T, int patternSize)
        {
            int textSize = T.Length;
            long y = 1, x = 256, pmode = (long)Math.Pow(10, 9) + 7;

            long[] H = new long[textSize - patternSize + 1];
            string sub = T.Substring(textSize - patternSize);
            H[textSize - patternSize] = PolyHash(sub);

            for (int i = 0; i < patternSize; i++)
            {
                y = (y * x) % pmode;
            }

            for (int i = textSize - patternSize - 1; i >= 0; i--)
            {
                H[i] = ((x * H[i + 1]) + T[i] - (y * T[i + patternSize])) % pmode;

                while (H[i] < 0)
                    H[i] += pmode;
            }
            return H;
        }
        static void Main(string[] args)
        {
            string pattern = Console.ReadLine();
            string text = Console.ReadLine();

            List<long> occurrences = new List<long>();
            int textSize = text.Length;
            int patternSize = pattern.Length;

            long Phash = PolyHash(pattern);
            long[] H = PreComputeHashes(text, patternSize);

            for (int i = 0; i <= textSize - patternSize; i++)
            {
                if (Phash != H[i])
                {
                    continue;
                }
                if (text.Substring(i, patternSize) == pattern)
                {
                    occurrences.Add(i);
                }
            }
            foreach (long item in occurrences)
            {
                Console.Write(item + " ");
            }
        }
    }
}
