using GameStore.BLL.Interfaces;
using GameStore.DAL.Entities;
using GameStore.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.BLL.Implementation
{
    // Реалізувати нереалізовані методи інтерфейсу. Де потрібно - використати async await
    public class GameService : IGameService
    {
        private readonly IGenericRepository<Game> _gameRepository;

        // 2nd DI
        public GameService(IGenericRepository<Game> gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task AddGame(Game game)
        {
            await _gameRepository.CreateAsync(game);
        }

        public IEnumerable<Developer> GetAllDevelopers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Game> GetAllGames()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            throw new NotImplementedException();
        }
    }
}
