using System;
using System.Collections.Generic;
using System.Linq;

namespace EventsAndDelegates
{
    public static class Helpers
    {
        public static Random random = new Random();
        public static char[] vowels = { 'A', 'E', 'I', 'O', 'U', 'a', 'e', 'i', 'o', 'u'};
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static bool IsFirstCaseWovel(string text)
        {
            return vowels.Any(c => c == text.ToCharArray()[0]); 
        }
    }
}
