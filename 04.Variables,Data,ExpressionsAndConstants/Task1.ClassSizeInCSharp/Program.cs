using System;

public class Size
{
    public Size(double width, double height)
    {
        this.Width = width;
        this.Height = height;
    }

    public double Width { get; set; }

    public double Height { get; set; }

    public static Size GetRotatedSize(Size size, double angleOfTheFigureThatWillBeRotated)
    {
        double newWidth = (Math.Abs(Math.Cos(angleOfTheFigureThatWillBeRotated)) * size.Width) +
                          (Math.Abs(Math.Sin(angleOfTheFigureThatWillBeRotated)) * size.Height);

        double newHeight = (Math.Abs(Math.Sin(angleOfTheFigureThatWillBeRotated)) * size.Width) +
                           (Math.Abs(Math.Cos(angleOfTheFigureThatWillBeRotated)) * size.Height);

        return new Size(newWidth, newHeight);
    }
}