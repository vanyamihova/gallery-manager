using System;
namespace gallery_manager.Models
{
    public class GalleryEditorViewModel
    {
        public string Message { set; get; }

        public int Id { get; set; }

        public string Label { get; set; }

        public GalleryEditorViewModel()
        {
        }

        public GalleryEditorViewModel(int Id, string Label)
        {
            this.Id = Id;
            this.Label = Label;
        }
    }
}
