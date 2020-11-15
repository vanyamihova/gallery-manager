using System.Collections.Generic;
using System.Linq;
using gallery_manager.Models;

namespace gallery_manager.Database.Repository
{
    public class GalleryRepository
    {
        private DatabaseContext databaseContext = new DatabaseContext();

        public GalleryRepository()
        {
        }

        public List<GalleryEntity> FindAll() {
            return databaseContext.Gallery.ToList();
        }

        public GalleryEntity FindById(int id) {
            return databaseContext.Gallery.Single(entity => entity.Id == id);
        }

        public void Save(int id, string label) {
            GalleryEntity entity;
            if (id == 0) {
                entity = new GalleryEntity();
                entity.Id = id;
                entity.Label = label;
                databaseContext.Gallery.Add(entity);
                databaseContext.SaveChanges();
                return;
            }
            entity = FindById(id);
            entity.Label = label;
            databaseContext.Gallery.Update(entity);
            databaseContext.SaveChanges();
        }

        public void Delete(int id) {
            GalleryEntity entity = FindById(id);
            databaseContext.Gallery.Remove(entity);
            databaseContext.SaveChanges();
        }

    }
}
