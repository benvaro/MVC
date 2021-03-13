using System;
using System.Linq.Expressions;
using GameStore.DAL.Entities;

namespace GameStore.BLL.Filters
{
    public class GamesFilter
    {
        public string Type { get; set; }
        public string Name { get; set; }

        // x => x.Developer == 'Bogdan Zaremba'
        public Expression<Func<Game, bool>> Predicate { get; set; }
    }
}