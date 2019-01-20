using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlueTapeCrew.Web.Models.Entities
{
    public class Style
    {
        public Style()
        {
            Carts = new HashSet<Cart>();
        }

        public int Id { get; set; }

        public int ProductId { get; set; }

        public int SizeId { get; set; }

        public int ColorId { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal Price { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }

        public virtual Color Color { get; set; }

        public virtual Product Product { get; set; }

        public virtual Size Size { get; set; }
    }
}