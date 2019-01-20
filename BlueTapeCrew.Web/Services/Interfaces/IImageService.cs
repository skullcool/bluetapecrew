using System.Threading.Tasks;
using BlueTapeCrew.Web.Models.Entities;
using BlueTapeCrew.Web.Models.Enums;

namespace BlueTapeCrew.Web.Services.Interfaces
{
    public interface IImageService
    {
        Task<byte[]> ResizeImage(byte[] imageData, int width, int height, ImageFormat format);
        Task<Image> GetProductImageByName(string name);
        Task<Image> GetImageById(int id);
    }
}