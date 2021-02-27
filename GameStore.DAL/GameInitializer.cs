using GameStore.DAL.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GameStore.DAL
{
    // Додати початкові дані Розробники: 8 штук, Жанри: 6; Ігри - 10
    public class GameInitializer : DropCreateDatabaseAlways<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            var devs = new List<Developer> {
                new Developer() { Name = "Bogdan Zaremba" },
                new Developer() { Name = "Ubisoft" },
                new Developer() { Name = "Rockstar" },
                new Developer() { Name = "Bethesda" },
                new Developer() { Name = "Playrix" }
            };

            var genres = new List<Genre> {
                new Genre { Name = "RPG" },
                new Genre { Name = "Shooter" },
                new Genre { Name = "Sport Simulator" },
                new Genre { Name = "Action" }
            };

            var games = new List<Game>
            {
                new Game
                {
                    Name = "Super Unity",
                    Description = "Lorem ipsum",
                    Price = 100,
                    Year = 2019,
                    Image = "https://i.ytimg.com/vi/rYHn6KAhHwc/hqdefault.jpg",
                    Genre = genres.FirstOrDefault(x => x.Name == "RPG"),
                    Developer = devs.FirstOrDefault(x => x.Name == "Bogdan Zaremba")
                },
                new Game
                {
                    Name = "Super Unity",
                    Description = "Lorem ipsum",
                    Price = 100,
                    Year = 2019,
                    Image = "https://image.api.playstation.com/vulcan/ap/rnd/202009/2419/BWMVfyxONkIAlAJVQd96qPuN.png",
                    Genre = genres.FirstOrDefault(x => x.Name == "RPG"),
                    Developer = devs.FirstOrDefault(x => x.Name == "Bogdan Zaremba")
                },
                new Game
                {
                    Name = "Super Unity",
                    Description = "Lorem ipsum",
                    Price = 100,
                    Year = 2019,
                    Image = "https://ichef.bbci.co.uk/news/976/cpsprodpb/13729/production/_112375697_1331db7a-17c0-4401-8cac-6a2309ff49b6.jpg",
                    Genre = genres.FirstOrDefault(x => x.Name == "RPG"),
                    Developer = devs.FirstOrDefault(x => x.Name == "Bogdan Zaremba")
                },
                new Game
                {
                    Name = "Cyberpank",
                    Description = "Lorem ipsum",
                    Price = 100,
                    Year = 2019,
                    Image = "https://i.guim.co.uk/img/media/c6f7b43fa821d06fe1ab4311e558686529931492/168_84_1060_636/master/1060.jpg?width=1200&height=900&quality=85&auto=format&fit=crop&s=fd98bc73a66809dbb678b1a88aa6f96c",
                    Genre = genres.FirstOrDefault(x => x.Name == "RPG"),
                    Developer = devs.FirstOrDefault(x => x.Name == "Bogdan Zaremba")
                },
                new Game
                {
                    Name = "Super Unity",
                    Description = "Lorem ipsum",
                    Price = 100,
                    Year = 2019,
                    Image = "https://cdn57.androidauthority.net/wp-content/uploads/2020/04/FortNite-Mobile-video-screenshot-Apps-Weekly-920x470.jpg",
                    Genre = genres.FirstOrDefault(x => x.Name == "RPG"),
                    Developer = devs.FirstOrDefault(x => x.Name == "Bogdan Zaremba")
                },
                new Game
                {
                    Name = "Super Unity",
                    Description = "Lorem ipsum",
                    Price = 100,
                    Year = 2019,
                    Image = "https://static01.nyt.com/images/2020/03/24/arts/gaming-newbies-clashclans/gaming-newbies-clashclans-mobileMasterAt3x.jpg",
                    Genre = genres.FirstOrDefault(x => x.Name == "RPG"),
                    Developer = devs.FirstOrDefault(x => x.Name == "Bogdan Zaremba")
                }
            };

            context.Developers.AddRange(devs);
            context.Genres.AddRange(genres);
            context.Games.AddRange(games);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
