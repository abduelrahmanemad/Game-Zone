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
        [MaxLength(500)]
        public IFormFile Cover { get; set; } = default!;
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [Display(Name = "Supported Devices")]
        public List<int> SelectedDevicesIds { get; set; } = new List<int>();

        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();
        public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();
    }
}
