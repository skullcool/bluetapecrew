namespace BlueTapeCrew.Web.Models.Entities.Joins
{
    public class ProductImage
    {
        public int ImageId { get; set; }
        public Image Image { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}