using AutoMapper;
using GameStore.DAL.Entities;
using GameStore.UI.Models;

namespace GameStore.UI.Utils
{
    public class AutomapperConfiguration : Profile
    {
        public AutomapperConfiguration()
        {
            // GameViewModel <= Game
            CreateMap<Game, GameViewModel>()
                .ForMember(x => x.Developer, s => s.MapFrom(z => z.Developer.Name))
                .ForMember(x => x.Genre, s => s.MapFrom(z => z.Genre.Name));

            CreateMap<GameViewModel, Game>()
                .ForMember(x => x.Developer, s => s.MapFrom(z => new Developer { Name = z.Developer }))
                .ForMember(x => x.Genre, s => s.MapFrom(z => new Genre { Name = z.Name }));
        }
    }
}