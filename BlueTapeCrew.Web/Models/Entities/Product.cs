using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BlueTapeCrew.Web.Models.Entities.Joins;

namespace BlueTapeCrew.Web.Models.Entities
{
    public class Product
    {
        public Product()
        {
            AzImages = new HashSet<AzImage>();
            CartImages = new HashSet<CartImage>();
            Reviews = new HashSet<Review>();
            Styles = new HashSet<Style>();
            ProductCategories = new HashSet<ProductCategory>();
            ProductImages = new HashSet<ProductImage>();
        }

        public int Id { get; set; }

        public int? ImageId { get; set; }

        [Required]
        [StringLength(255)]
        public string ProductName { get; set; }

        public string Description { get; set; }

        [StringLength(255)]
        public string LinkName { get; set; }

        public virtual ICollection<AzImage> AzImages { get; set; }

        public virtual ICollection<CartImage> CartImages { get; set; }

        public virtual Image Image { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<Style> Styles { get; set; }

        public virtual ICollection<ProductCategory> ProductCategories { get; set; }

        public virtual ICollection<ProductImage> ProductImages { get; set; }
    }
}