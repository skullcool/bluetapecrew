using System;
using System.Threading.Tasks;
using BlueTapeCrew.Web.Models.Enums;
using BlueTapeCrew.Web.Services.Interfaces;
using BlueTapeCrew.Web.Utils;
using Microsoft.AspNetCore.Mvc;

namespace BlueTapeCrew.Web.Controllers
{
    [ResponseCache(Duration = 3600)]
    public class ImagesController : Controller
    {
        private readonly IImageService _imageService;

        public ImagesController(IImageService imageService)
        {
            _imageService = imageService;
        }

        // GET: Images
        [Route("images/{name}")]
        public async Task<ActionResult> Images(string name)
        {
            try
            {
                var image = await _imageService.GetProductImageByName(name);
                return this.Image(image.ImageData, image.MimeType);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        public async Task<ActionResult> ProductThumb(int? id)
        {
            if (id == null) return null;
            var imageModel = await _imageService.GetImageById((int)id);
            return this.Image(await _imageService.ResizeImage(imageModel.ImageData, 75, 100, ImageFormat.Jpeg), "image/jpeg");
        }

    }
}