using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlueTapeCrew.Web.Models.Entities
{
    public class Image
    {
        public Image()
        {
            Categories = new HashSet<Category>();
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public byte[] ImageData { get; set; }

        [Required]
        [StringLength(255)]
        public string MimeType { get; set; }

        public short? Width { get; set; }

        public short? Height { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}
