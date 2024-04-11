using GameZone.ViewModels;

namespace GameZone.Services
{
    public interface IGamesService
    {
        Task AddGame(CreateGameFormView model);
    }
}
