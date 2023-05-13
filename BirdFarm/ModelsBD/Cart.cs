namespace BirdFarm.ModelsBD
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EggsId { get; set; }
        public int CountEggs { get; set; }
        public double Price { get; set; }
    }
}
