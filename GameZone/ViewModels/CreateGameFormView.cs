using GameZone.Attributes;
using GameZone.Settings;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace GameZone.ViewModels
{
    public class CreateGameFormView
    {
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(2500)]
        public string Description { get; set; } = string.Empty;
        [AllowedExtensions(ValidationParameters.AllowedExttensions)]
        [MaxFileSize(ValidationParameters.MaxImgSizeInBytes)]
        public IFormFile Cover { get; set; } = default!;
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [Display(Name = "Supported Devices")]
        public List<int> SelectedDevicesIds { get; set; } = default!;

        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();
        public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();
    }
}
