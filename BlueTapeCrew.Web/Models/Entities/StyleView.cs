using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlueTapeCrew.Web.Models.Entities
{
    [Table("StyleView")]
    public class StyleView
    {
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductId { get; set; }

        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SizeId { get; set; }

        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SizeOrder { get; set; }

        [Column(Order = 4)]
        [StringLength(20)]
        public string SizeText { get; set; }

        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ColorId { get; set; }

        [Column(Order = 6)]
        [StringLength(25)]
        public string ColorText { get; set; }

        [Column(Order = 7, TypeName = "smallmoney")]
        public decimal Price { get; set; }

        [Column(Order = 8)]
        [StringLength(48)]
        public string StyleText { get; set; }
    }
}
