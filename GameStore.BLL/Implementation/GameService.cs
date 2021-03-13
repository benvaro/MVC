using System;
using GameStore.BLL.Interfaces;
using GameStore.DAL.Entities;
using GameStore.DAL.Repository.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Binbin.Linq;
using GameStore.BLL.Filters;

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

        public IEnumerable<Game> GetAllGames(List<GamesFilter> filters)
        {
            if (filters == null)
            {
                return _gameRepository.GetAll();
            }

            // Filters
            // x => x.Developer.Name == "Ubisoft" ||
            // x => x.Developer.Name == "Zaremba"

            var predicates = new List<Expression<Func<Game, bool>>>();

            var builder = PredicateBuilder.Create(filters.FirstOrDefault().Predicate);

            for (int i = 1; i < filters.Count; i++)
            {
                builder = builder.Or(filters[i].Predicate);
            }

            return _gameRepository.GetAll().Where(builder.Compile());
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
