namespace MyRecipeBook.InfraSqlServer.Model
{
    public class PriceProductClient
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public decimal ProductValue { get; set; }

        public DateTime? DateValidate { get; set; }

        public string? IdProduct { get; set; }
    }
}
