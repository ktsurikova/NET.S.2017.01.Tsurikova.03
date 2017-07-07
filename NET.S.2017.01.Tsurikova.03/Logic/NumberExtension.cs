using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// provides additional methods for numbers
    /// </summary>
    public class NumberExtension
    {
        #region Insertion

        const int MaxNumber = 0x7fffffff;
        const int MaxNumberOfBit = 31;

        /// <summary>
        /// inserts second number from i to j bits in first number
        /// </summary>
        /// <param name="num1">number to be inserted</param>
        /// <param name="num2">inserted number</param>
        /// <param name="i">start index</param>
        /// <param name="j">end index</param>
        /// <exception cref="ArgumentException">throws when j less then i</exception>>
        /// <exception cref="ArgumentOutOfRangeException">throws when i,j doesn't belong to [0,31]</exception>>
        /// <returns>obtained number</returns>
        public static int Insertion(int num1, int num2, int i, int j)
        {
            if (i < 0 || i > MaxNumberOfBit) throw new ArgumentOutOfRangeException($"{nameof(i)} doesn't belong to allowable range");
            if (j < 0 || j > MaxNumberOfBit) throw new ArgumentOutOfRangeException($"{nameof(j)} doesn't belong to allowable range");
            if (j < i) throw new ArgumentException($"{nameof(i)} must be less then {nameof(j)}");

            int amount = j - i + 1;
            int mask;

            mask = MaxNumber >> (MaxNumberOfBit - amount);
            int num2Tail = num2 & mask;

            mask = MaxNumber >> (MaxNumberOfBit - i);
            int num1Tail = num1 & mask;

            num2Tail = num2Tail << i;
            num2Tail = num2Tail | num1Tail;

            mask = MaxNumber >> (MaxNumberOfBit - j - 1);
            return (num1 & ~mask) | num2Tail;
        }

        #endregion

        #region NextBiggerNumber

        /// <summary>
        /// finds next bigger number
        /// </summary>
        /// <param name="number">initial number</param>
        /// <returns>bigger number if it exists, otherwise -1</returns>
        public static int NextBiggerNumber(int number)
        {
            string str = number.ToString();
            int index;

            for (index = str.Length - 1; index > 0; index--)
            {
                if (str[index] > str[index - 1]) break;
            }
            if (index == 0) return -1;

            char[] array = str.ToCharArray();

            if (array[index - 1] < array[array.Length - 1])
                Swap(ref array[index - 1], ref array[array.Length - 1]);
            else
                Swap(ref array[index], ref array[index - 1]);

            Array.Reverse(array, index, array.Length - index);

            str = string.Concat(array);
            return int.Parse(str);
            //return Convert.ToInt32(new string(array));
        }

        /// <summary>
        /// finds next bigger number and time elapsed
        /// </summary>
        /// <param name="number">initial number</param>
        /// <returns>tuple: bigger number if it exists, otherwise -1 and elapsed time</returns>
        public static Tuple<int, TimeSpan> NextBiggerNumberAndTimeTuple(int number)
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();
            number = NextBiggerNumber(number);
            watch.Stop();

            return new Tuple<int, TimeSpan>(number, watch.Elapsed);
        }
        /// <summary>
        /// finds next bigger number and time elapsed
        /// </summary>
        /// <param name="number">initial number</param>
        /// <param name="time">time elapsed</param>
        /// <returns>bigger number if it exists, otherwise -1</returns>
        public static int NextBiggerNumberAndTimeOutParametr(int number, out TimeSpan time)
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();
            number = NextBiggerNumber(number);
            watch.Stop();
            time = watch.Elapsed;

            return number;
        }

        private static void Swap(ref char a, ref char b)
        {
            char temp = a;
            a = b;
            b = temp;
        }

        #endregion

        #region Root
        /// <summary>
        /// calculates root of given degree
        /// </summary>
        /// <param name="number">number from which root is extracted</param>
        /// <param name="degree">degree of root</param>
        /// <param name="precision">precision of calculation</param>
        /// <exception cref="ArgumentOutOfRangeException">throws when precision isn't positive</exception>
        /// <returns>value of the root with a given precision</returns>
        public static double Root(double number, int degree, double precision = 0.0001)
        {
            if (precision < 0) throw new ArgumentOutOfRangeException($"{nameof(precision)} must be positive");

            if (degree < 0)
            {
                number = 1.0 / number;
                degree *= -1;
            }

            double x0 = 1;
            double xk = 1.0 / degree * ((degree - 1) * x0 + number / Math.Pow(x0, degree - 1));

            while (Math.Abs(xk - x0) > precision)
            {
                x0 = xk;
                xk = 1.0 / degree * ((degree - 1) * x0 + number / Math.Pow(x0, degree - 1));
            }

            return xk;
        }

        #endregion
    }
}
