namespace Cooking
{
    public class Chef
    {
        public void Cook()
        {
            Potato potato = new Potato();
            Carrot carrot = new Carrot();
            Bowl bowl = new Bowl();
            
            potato.Peel();
            carrot.Peel();
            
            potato.Cut();
            carrot.Cut();
            
            bowl.Add(carrot);
            bowl.Add(potato);
        }
    }
}
