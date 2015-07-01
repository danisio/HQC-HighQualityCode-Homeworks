namespace Cooking
{
    public class Task2
    {
        public static void Test()
        {
            // First part

            /*Potato potato;
            //... 
            if (potato != null)
                if (!potato.HasNotBeenPeeled && !potato.IsRotten)
                    Cook(potato);
            */

            Potato potato = new Potato();
            if (potato != null)
            {
                if (!potato.IsPeeled && !potato.IsRotten)
                {
                    potato.Cook();
                }
            }

            // Second part

            /*if (x >= MIN_X && (x =< MAX_X && ((MAX_Y >= y && MIN_Y <= y) && !shouldNotVisitCell)))
            {
               VisitCell();
            }
            */

            const int MIN_X = 0;
            const int MAX_X = 100;
            const int MIN_Y = 101;
            const int MAX_Y = 200;
            int x = 5;
            int y = 10;
            bool shouldVisitCell = true;

            if (MIN_X <= x && x <= MAX_X && 
                MIN_Y <= y && y <= MAX_Y && 
                shouldVisitCell)
            {
                VisitCell();
            }
        }

        private static void VisitCell()
        {
        }
    }
}