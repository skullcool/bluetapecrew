using Api.Models.Entities;

namespace Api.ViewModels
{
    public class StyleListViewModel
    {
        public StyleListViewModel(Style style)
        {
            Id = style.Id;
            Size = style.Size.SizeText;
            Color = style.Color.ColorText;
            Price = $"${style.Price:n2}";
        }

        public int Id { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Price { get; set; }
    }
}
