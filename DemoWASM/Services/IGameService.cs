using DemoWASM.Models;

namespace DemoWASM.Services
{
    public interface IGameService
    {
        List<Game> GetGames();
        Game GetGameById(int id);
        void Save(Game game);
        void Update(Game game);
    }
}
