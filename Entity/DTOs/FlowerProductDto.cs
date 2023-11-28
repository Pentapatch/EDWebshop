namespace EDWebshop.Contracts.DTOs
{
    public class FlowerProductDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImagePath { get; set; }

        public string Description { get; set; }

        public string LongDescription { get; set; }

        public List<ProductVariantDto> Variants { get; set; }

        public int Length { get; set; }

        public int Weight { get; set; }
    }
}