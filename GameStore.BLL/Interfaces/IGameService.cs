using GameStore.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.BLL.Interfaces
{
    public interface IGameService
    {
        IEnumerable<Game> GetAllGames();
        IEnumerable<Genre> GetAllGenres();
        IEnumerable<Developer> GetAllDevelopers();
        Task AddGame(Game game);
    }
}
