using GameZone.Data;
using GameZone.Models;
using GameZone.ViewModels;

namespace GameZone.Services
{
    public class GamesService : IGamesService
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _imgsPath;

        public GamesService(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _imgsPath = $"{_webHostEnvironment.WebRootPath}/assets/gamesImgs";
        }
        public async Task AddGame(CreateGameFormView game)
        {
            var coverName = Guid.NewGuid().ToString() + Path.GetExtension(game.Cover.FileName);
            var coverPath = Path.Combine(_imgsPath,coverName);
            using var stream = File.Create(coverPath);
            await game.Cover.CopyToAsync(stream);
            var gameToAdd = new Game
            {
                Name = game.Name,
                Description = game.Description,
                CategoryId = game.CategoryId,
                GameDevices = game.SelectedDevicesIds.Select(d => new GameDevice { DeviceId = d }).ToList(),
                Cover = coverName
            };
            _context.Games.Add(gameToAdd);
            await _context.SaveChangesAsync();

        }
    }
}
