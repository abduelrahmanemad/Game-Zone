using Microsoft.AspNetCore.Mvc;
using GameZone.ViewModels;
using GameZone.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using GameZone.Services;

namespace GameZone.Controllers
{
    public class GamesController : Controller
    {
        
        private readonly ICategoriesService _categoriesService;
        private readonly IDevicesService _devicesService;
        private readonly IGamesService _gamesService;

        public GamesController(ICategoriesService categoriesService, IDevicesService devicesService, IGamesService gamesService)
        {
            _categoriesService = categoriesService;
            _devicesService = devicesService;
            _gamesService = gamesService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var categories = _categoriesService.GetSelectList();

            var devices =  _devicesService.GetSelectList();
            CreateGameFormView model = new()
            {
                Categories = categories,
                Devices = devices,
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGameFormView model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _categoriesService.GetSelectList();

                model.Devices = _devicesService.GetSelectList();
                return View(model);
            }
            // Save the game to the database
            await _gamesService.AddGame(model);

            return RedirectToAction(nameof(Index));
        }
    }
}
