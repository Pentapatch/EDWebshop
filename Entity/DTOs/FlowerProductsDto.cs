namespace EDWebshop.Contracts.DTOs
{
    public class FlowerProductsDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImagePath { get; set; }

        public List<ProductVaritantDto> Variants { get; set; }

    }
}
