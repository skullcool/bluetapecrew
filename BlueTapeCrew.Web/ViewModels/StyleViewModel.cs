using BlueTapeCrew.Web.Models.Entities;

namespace BlueTapeCrew.Web.ViewModels
{
    public class StyleViewModel
    {
        public StyleViewModel(Style style)
        {
            Id = style.Id;
            ProductId = style.ProductId;
            SizeId = style.SizeId;
            SizeOrder = style.Size.SizeOrder;
            SizeText = style.Size.SizeText;
            ColorId = style.ColorId;
            ColorText = style.Color.ColorText;
            Price = style.Price;
            StyleText = $"{SizeText} / {ColorText}";
        }

        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public int SizeOrder { get; set; }
        public string SizeText { get; set; }
        public int ColorId { get; set; }
        public string ColorText { get; set; }
        public decimal Price { get; set; }
        public string StyleText { get; set; }
    }
}
