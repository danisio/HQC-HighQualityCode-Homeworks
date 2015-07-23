namespace Methods.Geometry
{
    using System;

    public class GeometryMethods
    {
        public static double CalcTriangleArea(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new ArgumentOutOfRangeException("Sides should be positive.");
            }

            if (sideA >= sideB + sideC || sideB >= sideA + sideC || sideC >= sideA + sideB)
            {
                throw new ArgumentException("Unable to make a triangle from the given sizes.");
            }

            double semiPerimeter = (sideA + sideB + sideC) / 2;
            double area = Math.Sqrt(semiPerimeter * (semiPerimeter - sideA) * (semiPerimeter - sideB) * (semiPerimeter - sideC));

            return area;
        }

        public static double CalcDistance(Point p1, Point p2)
        {
            return Math.Sqrt((p2.X - p1.X) * (p2.X - p1.X) + (p2.Y - p1.Y) * (p2.Y - p1.Y));
        }

        public static bool CheckIsXAxisEqual(Point p1, Point p2)
        {
            return p1.X == p2.X;
        }

        public static bool CheckIsYAxisEqual(Point p1, Point p2)
        {
            return p1.Y == p2.Y;
        }
    }
}
