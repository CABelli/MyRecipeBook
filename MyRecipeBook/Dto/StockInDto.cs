namespace MyRecipeBook.Dto
{
    public class StockInDto
    {
        public string NameProduct { get; set; }

        public string DescriptionStock { get; set; }

        public int QuantityAvailable { get; set; }

        public int QuantityUsed { get; set; }
    }
}
