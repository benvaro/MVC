using GameStore.DAL.Entities;
using System.Data.Entity;

namespace GameStore.DAL
{
    // Додати початкові дані Розробники: 8 штук, Жанри: 6; Ігри - 10
    public class GameInitializer : DropCreateDatabaseIfModelChanges<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            var dev1 = new Developer()
            {
                Name = "Bogdan Zaremba"
            };

            var genre1 = new Genre()
            {
                Name = "RPG"
            };

            var game1 = new Game()
            {
                Name = "Super Unity"
            };

            context.Developers.Add(dev1);
            context.Genres.Add(genre1);
            context.Games.Add(game1);




            context.SaveChanges();

            base.Seed(context);
        }
    }
}
