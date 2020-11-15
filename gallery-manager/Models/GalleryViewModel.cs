using System.Collections.Generic;
using gallery_manager.Database.Entity;

namespace gallery_manager.Models
{
    public class GalleryViewModel
    {
        public int Id { get; }

        public string Name { get; }

        public List<ImageEntity> Images { get; }

        public GalleryViewModel(GalleryEntity galleryEntity, List<ImageEntity> images)
        {
            this.Id = galleryEntity.Id;
            this.Name = galleryEntity.Label;
            this.Images = images;
        }
    }
}
