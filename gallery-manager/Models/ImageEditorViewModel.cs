using System;
using System.IO;
using gallery_manager.Services;

namespace gallery_manager.Models
{
    public class ImageEditorViewModel
    {
        public string Message { set; get; }

        public int Id { get; set; }

        public string Label { get; set; }

        public string Filename { get; set; }

        public int GalleryId { get; set; }

        public ImageEditorViewModel()
        { }

        public ImageEditorViewModel(int galleryId)
        {
            this.GalleryId = galleryId;
        }

        public ImageEditorViewModel(int id, string label, string filename, int galleryId)
        {
            this.Id = id;
            this.Label = label;
            this.Filename = filename;
            this.GalleryId = galleryId;
        }

        public string GetFullPath()
        {
            return Path.Combine("/", ImageFileManager.IMAGE_PATH, Filename);
        }

    }
}
