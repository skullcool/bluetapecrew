using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BlueTapeCrew.Web.Models.Entities.Joins;

namespace BlueTapeCrew.Web.Models.Entities
{
    public class Category
    {
        public Category()
        {
            CategoryImages = new HashSet<CategoryImage>();
            ProductCategories = new HashSet<ProductCategory>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; }

        public int? ImageId { get; set; }

        [StringLength(2083)]
        public string ImageUrl { get; set; }

        public bool Published { get; set; }

        public virtual Image Image { get; set; }

        public virtual ICollection<CategoryImage> CategoryImages { get; set; }

        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
    }
}