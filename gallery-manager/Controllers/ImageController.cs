using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using gallery_manager.Database.Entity;
using gallery_manager.Database.Repository;
using gallery_manager.Models;
using gallery_manager.Services;
using gallery_manager.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace gallery_manager.Controllers
{
    public class ImageController : Controller
    {
        private GalleryRepository galleryRepository = new GalleryRepository();

        private ImageRepository imageRepository = new ImageRepository();

        private ImageFileManager imageFileWriter = new ImageFileManager();

        private ImageValidator imageValidator = new ImageValidator();

        public ImageController()
        {
        }

        public IActionResult Index(int galleryId)
        {
            GalleryEntity galleryEntity = galleryRepository.FindById(galleryId);
            List<ImageEntity> imageEntities = imageRepository.FindAllByGalleryId(galleryId);
            GalleryViewModel viewModel = new GalleryViewModel(galleryEntity, imageEntities);
            return View("Index", viewModel);
        }

        public IActionResult NavigateToUploadNewImage(GalleryViewModel viewModel) {
            ImageEditorViewModel imageEditorViewModel = new ImageEditorViewModel(viewModel.Id);
            return View("Editor", imageEditorViewModel);
        }

        /*****************
         * CREATE
         */
        public IActionResult Add(int galleryId)
        {
            ImageEditorViewModel viewModel = new ImageEditorViewModel(galleryId);
            return View("Editor", viewModel);
        }

        /*****************
         * UPDATE
         */
        public IActionResult Edit(int galleryId, int imageId)
        {
            ImageEntity entity = imageRepository.FindById(imageId);
            ImageEditorViewModel viewModel = new ImageEditorViewModel(entity.Id, entity.Label, entity.Filename, entity.GalleryId);
            return View("Editor", viewModel);
        }

        /*****************
        * ACTION FROM EDITOR
        */
        [HttpPost]
        public async Task<IActionResult> Save(IFormFile file, ImageEditorViewModel viewModel)
        {
            if (imageValidator.isValid(viewModel)) {
                if (file != null) {
                    Task<string> task = imageFileWriter.copy(file);
                    await task;
                    viewModel.Filename = task.Result;
                }

                imageRepository.Save(viewModel.Id, viewModel.Label, viewModel.Filename, viewModel.GalleryId);
                return Redirect("/gallery/" + viewModel.GalleryId + "/images/");
            }

            viewModel.Message = imageValidator.GetMessage();
            return View("Editor", viewModel);
        }

        /*****************
        * DELETE
        */
        public IActionResult Delete(int galleryId, int imageId)
        {
            // TODO: Delete image file!
            imageRepository.Delete(imageId);
            return Redirect("/gallery/" + galleryId + "/images");
        }


    }

}
