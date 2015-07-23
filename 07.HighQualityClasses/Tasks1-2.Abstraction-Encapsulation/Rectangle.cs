namespace Abstraction
{
    using System;

    public class Rectangle : Figure
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Rectangle width cannot be less or equal to zero!");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Rectangle height cannot be less or equal to zero!");
                }

                this.height = value;
            }
        }

        public override double CalcPerimeter()
        {
            return 2 * (this.Width + this.Height);
        }

        public override double CalcSurface()
        {
            return this.Width * this.Height;
        }
    }
}
