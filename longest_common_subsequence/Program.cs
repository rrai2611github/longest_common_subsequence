using System;

namespace longest_common_subsequence
{

    class Program
    {
        static void Main()
        {
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                line = line.Trim();
                if (string.IsNullOrEmpty(line))
                    continue;

                string[] parts = line.Split(';');
                if (parts.Length != 2)
                {
                    Console.WriteLine("Invalid input format. Expected two semicolon-separated strings per line.");
                    continue;
                }

                string str1 = parts[0].Trim();
                string str2 = parts[1].Trim();

                string lcs = LongestCommonSubsequence(str1, str2);

                Console.WriteLine(lcs);
            }
        }

        static string LongestCommonSubsequence(string str1, string str2)
        {
            int m = str1.Length;
            int n = str2.Length;

            int[,] dp = new int[m + 1, n + 1];

            // Building the dynamic programming table
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (str1[i - 1] == str2[j - 1])
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    else
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }

            // Finding the longest common subsequence
            int index = dp[m, n];
            char[] lcs = new char[index];
            int p = m, q = n;

            while (p > 0 && q > 0)
            {
                if (str1[p - 1] == str2[q - 1])
                {
                    lcs[index - 1] = str1[p - 1];
                    p--;
                    q--;
                    index--;
                }
                else if (dp[p - 1, q] > dp[p, q - 1])
                    p--;
                else
                    q--;
            }

            return new string(lcs);
        }
    }
}
