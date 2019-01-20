using BlueTapeCrew.Web.Data;
using BlueTapeCrew.Web.Models.Enums;
using BlueTapeCrew.Web.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTapeCrew.Web.Services
{
    public class ImageService : IImageService, IDisposable
    {
        private readonly ApplicationDbContext _db;

        public ImageService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<byte[]> ResizeImage(byte[] imageData, int width, int height, ImageFormat format)
        {
            return imageData;
            //using (var ms = new MemoryStream())
            //using (var mss = new MemoryStream())
            //{
            //    await ms.WriteAsync(imageData, 0, imageData.Length);
            //    var image = Image.FromStream(ms);
            //    var destRect = new Rectangle(0, 0, width, height);
            //    var destImage = new Bitmap(width, height);

            //    destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            //    using (var graphics = Graphics.FromImage(destImage))
            //    {
            //        graphics.CompositingMode = CompositingMode.SourceCopy;
            //        graphics.CompositingQuality = CompositingQuality.HighQuality;
            //        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //        graphics.SmoothingMode = SmoothingMode.HighQuality;
            //        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            //        using (var wrapMode = new ImageAttributes())
            //        {
            //            wrapMode.SetWrapMode(WrapMode.TileFlipXY);
            //            graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel,
            //                wrapMode);
            //        }
            //    }
            //    destImage.Save(mss, format);
            //    return mss.ToArray();
            //}
        }

        public async Task<Models.Entities.Image> GetProductImageByName(string name)
        {
            var linkName = name.Split('.')[0];
            var productImage = await _db.Products.Where(x => x.LinkName == linkName).Select(x => x.Image).FirstOrDefaultAsync();
            return productImage;
        }

        public async Task<Models.Entities.Image> GetImageById(int id)
        {
            return await _db.Images.FindAsync(id);
        }


        public void Dispose()
        {
            _db?.Dispose();
        }
    }
}