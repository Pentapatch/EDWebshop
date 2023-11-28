namespace EDWebshop.Contracts.Entities
{
    public class FlowerProduct : IEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImagePath { get; set; }

        public string Description { get; set; }

        public string LongDescription { get; set; }

        public List<ProductVariant> Variants { get; set; }

        public int Length { get; set; }

        public int Weight { get; set; }
    }
}