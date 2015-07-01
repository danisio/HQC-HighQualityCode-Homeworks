namespace Cooking
{
    public abstract class Vegetable
    {
        public Vegetable()
        {
        }

        public bool IsCooked { get; set; }

        public bool IsCutted { get; set; }

        public bool IsPeeled { get; set; }

        public bool IsRotten { get; set; }

        public void Cook()
        {
            this.IsCooked = true;
        }

        public void Cut()
        {
            this.IsCutted = true;
        }

        public void Peel()
        {
            this.IsPeeled = true;
        }
    }
}
