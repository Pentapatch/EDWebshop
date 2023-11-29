namespace EDWebshop.Contracts.DTOs
{
    public class FlowerProductListDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImagePath { get; set; }

        public List<ProductVariantDto> Variants { get; set; }

    }
}
