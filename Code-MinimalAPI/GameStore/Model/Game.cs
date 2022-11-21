namespace GameStore.Model
{
    public class Game
    {
        public string Upc { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string ShortDescription { get; set; } =default!;
        public int Price { get; set; }
        public DateTime ReleasedDate { get; set; }
    }
}