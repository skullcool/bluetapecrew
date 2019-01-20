using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BlueTapeCrew.Web.Utils
{
    public class ImageResult : ActionResult
    {
        private static readonly int BufferSize = 4096;

        public ImageResult(Stream imageStream, string contentType)
        {
            ImageStream = imageStream ?? throw new ArgumentNullException(nameof(imageStream));
            ContentType = contentType ?? throw new ArgumentNullException(nameof(contentType));
        }

        public Stream ImageStream { get; }
        public string ContentType { get; }

        public override async Task ExecuteResultAsync(ActionContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var response = context.HttpContext.Response;

            response.ContentType = ContentType;

            var buffer = new byte[BufferSize];
            try
            {
                while (true)
                {
                    var read = ImageStream.Read(buffer, 0, buffer.Length);
                    if (read == 0)
                        break;

                    await response.Body.WriteAsync(buffer, 0, read);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}