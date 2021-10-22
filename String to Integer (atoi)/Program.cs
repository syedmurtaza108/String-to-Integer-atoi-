using System;

namespace String_to_Integer__atoi_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MyAtoi("20000000000000000000"));
        }

        static int MyAtoi(string s)
        {
            s = s.Trim();
            if (s.Length == 0) return 0;
            var isPositive = s[0] != '-';
            if (s[0] == '+' || s[0] == '-')
            {
                s = s.Substring(1);
            }
            int i = 0;
            while (i < s.Length && s[i] > 47 && s[i] < 58)
            {
                i++;
            }
            s = s.Substring(0, i);
            long l = 0;
            if (s.Length == 0) return 0;
            if (!long.TryParse(isPositive ? s : "-" + s, out l))
            {
                return isPositive ? int.MaxValue : int.MinValue;
            }
            if (isPositive)
                return l > int.MaxValue ? int.MaxValue : (int)l;
            return l < int.MinValue ? int.MinValue : (int)l;
        }

        static int a(int x)
        {
            long longX = x;
            if (x > int.MaxValue) return 0;
            string answer = "";
            bool isNegative = x < 0;
            if (isNegative)
            {
                longX = long.Parse(x.ToString().Substring(1));
                if (longX > int.MaxValue) return 0;
                else x = int.Parse(x.ToString().Substring(1));
            }
            int denominator = (int)(Math.Pow(10, x.ToString().Length - 1));
            while (x % denominator != 0)
            {
                answer = (x / denominator) + answer;
                int i = 1;
                while (i < x.ToString().Length && x.ToString()[i] == '0')
                {
                    answer = "0" + answer;
                    i++;
                }
                x = x % denominator;
                denominator = (int)Math.Pow(10, x.ToString().Length - 1);
            }
            answer = (x / denominator) + answer;
            var val = long.Parse(isNegative ? "-" + answer : answer);
            if (isNegative)
                return val < int.MinValue ? 0 : (int)val;
            return val > int.MaxValue ? 0 : (int)val;
        }
    }
}
