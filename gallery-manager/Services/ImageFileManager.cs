using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace gallery_manager.Services
{
    public class ImageFileManager
    {
        private string ROOT_IMAGE_PATH = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot", IMAGE_PATH);

        public static string IMAGE_PATH = @"images";

        public ImageFileManager()
        {
            System.IO.Directory.CreateDirectory(ROOT_IMAGE_PATH);
        }

        public async Task<String> copy(IFormFile file) {
            if (file == null || file.Length == 0) {
                return null;
            }

            string filename = DateTimeOffset.Now.ToUnixTimeMilliseconds() + "_" + file.FileName;
            var path = Path.Combine(ROOT_IMAGE_PATH, filename);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return filename;
        }

        public void Delete(string filename) {
            File.Delete(Path.Combine(ROOT_IMAGE_PATH, filename));
        }

    }
}
