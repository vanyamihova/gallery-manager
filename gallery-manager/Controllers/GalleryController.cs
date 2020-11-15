using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using gallery_manager.Models;
using gallery_manager.Database.Repository;
using System.Threading.Tasks;
using gallery_manager.Validators;

namespace gallery_manager.Controllers
{
    public class GalleryController : Controller
    {
        private readonly ILogger<GalleryController> _logger;

        private GalleryRepository galleryRepository = new GalleryRepository();

        private GalleryValidator galleryValidator = new GalleryValidator();

        public GalleryController(ILogger<GalleryController> logger)
        {
            _logger = logger;
        }

        /*****************
         * LIST OF GALLERIES
         */
        public IActionResult Index()
        {
            GalleryListViewModel viewModel = new GalleryListViewModel();
            viewModel.Galleries = this.galleryRepository.FindAll();
            return View("Index", viewModel);
        }

        /*****************
         * CREATE
         */
        public IActionResult Create()
        {
            GalleryEditorViewModel viewModel = new GalleryEditorViewModel();
            return View("Editor", viewModel);
        }

        /*****************
         * UPDATE
         */
        public IActionResult Edit(int galleryId)
        {
            GalleryEntity entity = galleryRepository.FindById(galleryId);
            GalleryEditorViewModel viewModel = new GalleryEditorViewModel(entity.Id, entity.Label);
            return View("Editor", viewModel);
        }

        /*****************
        * ACTION FROM EDITOR
        */
        [HttpPost]
        public async Task<IActionResult> Save(GalleryEditorViewModel viewModel)
        {
            if (galleryValidator.isValid(viewModel))
            {
                galleryRepository.Save(viewModel.Id, viewModel.Label);
                return Redirect("~/");
            }
            viewModel.Message = galleryValidator.GetMessage();
            return View("Editor", viewModel);
        }

        /*****************
        * DELETE
        */
        public IActionResult Delete(int galleryId)
        {
            galleryRepository.Delete(galleryId);
            return Redirect("~/");
        }

        /*****************
        * ERROR HANDLER
        */
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
