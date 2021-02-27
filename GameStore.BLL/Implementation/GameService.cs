using GameStore.BLL.Interfaces;
using GameStore.DAL.Entities;
using GameStore.DAL.Repository.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.BLL.Implementation
{
    // Реалізувати нереалізовані методи інтерфейсу. Де потрібно - використати async await
    public class GameService : IGameService
    {
        private readonly IGenericRepository<Game> _gameRepository;
        private readonly IGenericRepository<Developer> _developerRepository;
        private readonly IGenericRepository<Genre> _genreRepository;

        // 2nd DI
        public GameService(IGenericRepository<Game> gameRepository,
            IGenericRepository<Developer> developerRepository,
            IGenericRepository<Genre> genreRepository)
        {
            _gameRepository = gameRepository;
            _developerRepository = developerRepository;
            _genreRepository = genreRepository;
        }

        public async Task AddGameAsync(Game game)
        {
            await _gameRepository.CreateAsync(game);
        }

        public IEnumerable<Developer> GetAllDevelopers()
        {
            return _developerRepository.GetAll();
        }

        public IEnumerable<Game> GetAllGames()
        {
            return _gameRepository.GetAll();
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return _genreRepository.GetAll();
        }

        public IEnumerable<string> GetDevelopers()
        {
            return _developerRepository.GetAll().Select(x => x.Name);
        }

        public Game GetGame(int id)
        {
            return _gameRepository.Get(id);
        }

        public IEnumerable<string> GetGenres()
        {
            return _genreRepository.GetAll().Select(x => x.Name);
        }
    }
}
