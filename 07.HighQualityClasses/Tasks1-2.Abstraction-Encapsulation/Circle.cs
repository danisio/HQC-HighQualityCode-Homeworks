namespace Abstraction
{
    using System;

    public class Circle : Figure
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get 
            { 
                return this.radius; 
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Radius cannot be less or equal to zero!");
                }

                this.radius = value;
            }
        }

        public override double CalcPerimeter()
        {
            return 2 * Math.PI * this.Radius;
        }

        public override double CalcSurface()
        {
            return this.Radius * this.Radius * Math.PI;
        }
    }
}
