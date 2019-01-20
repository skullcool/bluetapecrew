using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlueTapeCrew.Web.Models.Entities
{
    public class PageOpenGraphTag
    {
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PageId { get; set; }

        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OpenGraphTagId { get; set; }

        [Required]
        public string Content { get; set; }

        public virtual OpenGraphTag OpenGraphTag { get; set; }

        public virtual Page Page { get; set; }
    }
}
