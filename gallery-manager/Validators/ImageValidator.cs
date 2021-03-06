﻿using System;
using gallery_manager.Models;

namespace gallery_manager.Validators
{
    public class ImageValidator
    {
        private const int MIN_LENGTH = 5;

        private const int MAX_LENGTH = 20;

        private string Message { get; set; }

        public ImageValidator()
        {
        }

        public Boolean isValid(ImageEditorViewModel viewModel) {
            Boolean result = viewModel.Label != null && viewModel.Label.Length >= MIN_LENGTH && viewModel.Label.Length <= MAX_LENGTH;
            if (!result)
            {
                this.Message = "The label must be with length from " + MIN_LENGTH + " to " + MAX_LENGTH;
            }
            return result;
        }

        public string GetMessage() {
            return Message;
        }
    }
}
