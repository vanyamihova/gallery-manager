using System.Linq;
using System.Collections.Generic;
using gallery_manager.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace gallery_manager.Database.Repository
{
    public class ImageRepository
    {
        private DatabaseContext databaseContext = new DatabaseContext();

        public ImageRepository()
        {
        }

        public List<ImageEntity> FindAllByGalleryId(int galleryId)
        {
            return databaseContext.Image.Where(img => img.GalleryId == galleryId).ToList();
        }

        public ImageEntity FindById(int id)
        {
            return databaseContext.Image.Single(entity => entity.Id == id);
        }

        public void Save(int id, string label, string filename, int galleryId) {
            ImageEntity entity;
            if (id == 0)
            {
                entity = new ImageEntity();
                entity.Id = id;
                entity.Label = label;
                entity.Filename = filename;
                entity.GalleryId = galleryId;
                databaseContext.Image.Add(entity);
                databaseContext.SaveChanges();
                return;
            }
            entity = FindById(id);
            entity.Label = label;
            entity.Filename = filename;
            entity.GalleryId = galleryId;
            databaseContext.Image.Update(entity);
            databaseContext.SaveChanges();
        }

        public void Delete(int id)
        {
            ImageEntity entity = FindById(id);
            databaseContext.Image.Remove(entity);
            databaseContext.SaveChanges();
        }

    }
}
