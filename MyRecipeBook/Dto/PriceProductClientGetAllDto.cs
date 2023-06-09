namespace MyRecipeBook.Dto
{
    public class PriceProductClientGetAllDto
    {
        public string? NameProduct { get; set; }

        public decimal ProductValue { get; set; }

        public DateTime? DateValidate { get; set; }

        public Guid IdPrice { get; set; }         
    }
}
