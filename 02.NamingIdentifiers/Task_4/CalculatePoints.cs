namespace MinesweeperGame
{
    public class CalculatePoints
    {
        public CalculatePoints()
        {
        }

        public CalculatePoints(string name, int points)
        {
            this.Name = name;
            this.Points = points;
        }

        public string Name { get; set; }

        public int Points { get; set; }
    }
}
