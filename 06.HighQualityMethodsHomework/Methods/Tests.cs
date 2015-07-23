namespace Methods
{
    using System;
    using Methods.Array;
    using Methods.Geometry;
    using Methods.Number;

    public class Tests
    {
        public static void Main()
        {
            // test the Geometry methods
            Console.WriteLine("Calculate triangle area: " + GeometryMethods.CalcTriangleArea(3, 4, 5));
            Point p1 = new Point(3, -1);
            Point p2 = new Point(3, 2);
            Console.WriteLine("Calculate distance: " + GeometryMethods.CalcDistance(p1, p2));
            Console.WriteLine("The points have equal X-axis: " + GeometryMethods.CheckIsXAxisEqual(p1, p2));
            Console.WriteLine("The points have equal Y-axis: " + GeometryMethods.CheckIsYAxisEqual(p1, p2));
            Console.WriteLine();

            // test the Number methods
            Console.WriteLine("Number 5 to word: " + TransformationMethods.NumberToWord(5));
            Console.WriteLine("Numer 1.3 with fixed point: " + TransformationMethods.NumberWithFixedPoint(1.3));
            Console.WriteLine("Number 0.75 as percent: " + TransformationMethods.NumberAsPercent(0.75));
            Console.WriteLine("Number 2.30 with right alignment: " + TransformationMethods.NumberWithRightAlignment(2.30));
            Console.WriteLine();

            // test the Array methods
            Console.WriteLine("The max element is: " + ArrayMethods.FindMaxElementInArray(5, -1, 3, 2, 14, 2, 3));
        }
    }
}
