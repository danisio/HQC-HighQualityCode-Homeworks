namespace Methods.Number
{
    using System;

    public class TransformationMethods
    {
        public static string NumberToWord(int number)
        {
            string[] array = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            if (number < 0 || number > 9)
            {
                throw new ArgumentOutOfRangeException("The number has to be in range [0-9]." + number);
            }

            return array[number];
        }

        public static object NumberAsPercent(object number)
        {
            return string.Format("{0:p0}", number);
        }

        public static object NumberWithFixedPoint(object number)
        {
            return string.Format("{0:f2}", number);
        }

        public static object NumberWithRightAlignment(object number)
        {
            return string.Format("{0,8}", number);
        }
    }
}
