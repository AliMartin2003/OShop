using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;

namespace OShop.Core.Tools
{
    public static class PublicServicesTools
    {
        public static string SaveImage(IFormFile file,string saveLocation,string? subFolder, string? imageName)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("No file uploaded or file is empty.");
            }
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", saveLocation);
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }
            string uniqueFileName = imageName;
            if (string.IsNullOrEmpty(imageName))
            {
                uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            }
           
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return uniqueFileName;
        }
        public static IFormFile CompressImage(IFormFile file)
        {
            
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("No file uploaded or file is empty.");
            }

            using (var image = Image.FromStream(file.OpenReadStream()))
            using (var memoryStream = new MemoryStream())
            {
                var encoderParameters = new EncoderParameters(1);
                encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 70L);
                var jpegCodec = GetEncoderInfo("image/jpeg");
                image.Save(memoryStream, jpegCodec, encoderParameters);
                memoryStream.Position = 0;
                var compressedFile = new FormFile(
                    memoryStream,
                    0,
                    memoryStream.Length,
                    Path.GetFileNameWithoutExtension(file.FileName) + "_compressed.jpg",
                    "compressed_" + file.FileName)
                {
                    Headers = file.Headers,
                    ContentType = "image/jpeg"
                };

                return compressedFile;
            }
        }

        public static bool IsImage(IFormFile file)
        {
            try
            {

                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
                var extension = Path.GetExtension(file.FileName).ToLower();
                if (!allowedExtensions.Contains(extension))
                {
                    return false;
                }

                
                using (var image = Image.FromStream(file.OpenReadStream()))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        // Helper method to get the appropriate image encoder
        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            var codecs = ImageCodecInfo.GetImageEncoders();
            return codecs.FirstOrDefault(codec => codec.MimeType == mimeType);
        }
    }
}
