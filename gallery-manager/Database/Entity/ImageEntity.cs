using System;
using System.IO;
using gallery_manager.Services;

namespace gallery_manager.Database.Entity
{
    public class ImageEntity
    {
        public ImageEntity()
        {
        }

        public int Id { get; set; }

        public string Label { get; set; }

        public string Filename { get; set; }

        public int GalleryId { get; set; }

        public string GetFullPath() {
            return Path.Combine("/", ImageFileManager.IMAGE_PATH, Filename);
        }

    }
}
