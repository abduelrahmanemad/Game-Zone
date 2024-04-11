using Microsoft.AspNetCore.Mvc;
using GameZone.ViewModels;
using GameZone.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using GameZone.Services;

namespace GameZone.Controllers
{
    public class GamesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICategoriesService _categoriesService;

        public GamesController(ApplicationDbContext applicationDbContext, ICategoriesService categoriesService)
        {
            _context = applicationDbContext;
            _categoriesService = categoriesService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var categories = _categoriesService.GetSelectList();

            var devices = _context.Devices.Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Name
            }).OrderBy(d => d.Text).ToList();
            CreateGameFormView model = new()
            {
                Categories = categories,
                Devices = devices,
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateGameFormView model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _categoriesService.GetSelectList();

                model.Devices = _context.Devices.Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Name
                }).OrderBy(d => d.Text).ToList();
                return View(model);
            }
            // Save the game to the database


            // Save cover image to the server
            return RedirectToAction(nameof(Index));
        }
    }
}
