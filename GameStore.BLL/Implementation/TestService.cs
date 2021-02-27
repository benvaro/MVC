using GameStore.BLL.Interfaces;
using GameStore.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.BLL.Implementation
{
    public class TestService //: IGameService
    {
        public Task AddGameAsync(Game game)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Developer> GetAllDevelopers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Game> GetAllGames()
        {
            return new List<Game>(){
                 new Game
                 {
                     Name = "Lorem",
                     Price = 1
                 },
                 new Game
                 {
                     Name = "Lorem",
                     Price = 3
                 },
                 new Game
                 {
                     Name = "Lorem",
                     Price = 2
                 },
                };

        }

        public IEnumerable<Genre> GetAllGenres()
        {
            throw new NotImplementedException();
        }
    }
}
