using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace BlueTapeCrew.Web.Utils
{ 
    public static class ControllerExtensions
    {
        public static ImageResult Image(this Controller controller, byte[] imageBytes, string contentType)
        {
            return new ImageResult(new MemoryStream(imageBytes), contentType);
        }
    }
}