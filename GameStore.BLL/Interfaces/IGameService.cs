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
        Task AddGameAsync(Game game);
        IEnumerable<string> GetGenres();
        IEnumerable<string> GetDevelopers();
        Game GetGame(int id); 
        
    }
}
