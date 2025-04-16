using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;

namespace OShop.Core.Tools
{
    public static class PublicServicesTools
    {
        public static string SaveImage(IFormFile file, string saveLocation, string? subFolder, string? imageName)
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

            string uniqueFileName = imageName ??
                Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

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

            using var image = Image.Load(file.OpenReadStream());
            using var memoryStream = new MemoryStream();

			// Resize if needed (example: resize to 800x600 maintaining aspect ratio)
			image.Mutate(x => x.Resize(new ResizeOptions
			{
				Size = new Size(800, 600),
				Mode = ResizeMode.Max
			}));

			var encoder = new JpegEncoder { Quality = 70 };
            image.Save(memoryStream, encoder);
            memoryStream.Position = 0;

            return new FormFile(
                memoryStream,
                0,
                memoryStream.Length,
                Path.GetFileNameWithoutExtension(file.FileName) + "_compressed.jpg",
                "compressed_" + file.FileName)
            {
                Headers = file.Headers,
                ContentType = "image/jpeg"
            };
        }

        public static bool IsImage(IFormFile file)
        {
            try
            {
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".webp" };
                var extension = Path.GetExtension(file.FileName).ToLower();

                if (!allowedExtensions.Contains(extension))
                {
                    return false;
                }

                // Attempt to load the image to verify it's actually an image file
                using var image = Image.Load(file.OpenReadStream());
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string ImageNameGenerator(IFormFile image)
        {
            return Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
        }
    }
}