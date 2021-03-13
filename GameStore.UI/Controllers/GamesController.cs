using AutoMapper;
using GameStore.BLL.Filters;
using GameStore.BLL.Interfaces;
using GameStore.DAL.Entities;
using GameStore.UI.Models;
using GameStore.UI.Utils.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GameStore.UI.Controllers
{
    public class GamesController : Controller
    {
        private readonly IGameService _gameService;
        private readonly IMapper _mapper;

        // 3 DI
        public GamesController(IGameService gameService, IMapper mapper)
        {
            _gameService = gameService;
            _mapper = mapper;
        }

        public ActionResult Index(string search)
        {
            ViewBag.Title = "GameStore";
            #region Manual mapping
            //var games = new List<GameViewModel>();
            //foreach (var item in _gameService.GetAllGames())
            //{
            //    games.Add(new GameViewModel
            //    {
            //        Id = item.Id,
            //        Name = item.Name,
            //        Description = item.Description,
            //        Price = item.Price,
            //        Year = item.Year//,
            //        //Developer = item.De
            //    });
            //} 
            #endregion

            ViewBag.Developers = _gameService.GetDevelopers();
            ViewBag.Genres = _gameService.GetGenres();
            Response.Cookies["id"].Value = Guid.NewGuid().ToString();

            var games = _mapper.Map<List<GameViewModel>>(_gameService.GetAllGames(null));
            if (String.IsNullOrEmpty(search))
            {
                return View(games);
            }

            return View(games.Where(x => x.Name.Contains(search)).ToList());

            // var developers = new[] { "Bethesda", "Rockstar", "Ubisoft" };
            // ViewBag.Developers = developers;

        }

        public ActionResult GetDevelopers()
        {
            return View();
        }

        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        private void SetViewBag()
        {
            ViewBag.Genres = _gameService.GetGenres();
            ViewBag.Developers = _gameService.GetDevelopers();
        }

        [HttpPost]
        public async Task<ActionResult> Create(GameViewModel model, HttpPostedFileBase image)
        {
            // 1) якщо картинка:
            //    2) зберегти картинку на сервер
            // 2.1) конвертувати картинку
            //    3) записати шлях в модель
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (image != null)
            {
                var fileName = Guid.NewGuid().ToString() + ".jpg";

                var bitmap = BitmapConvertor.Convert(image.InputStream, 200, 200);
                var serverPath = Server.MapPath($"~/Images/{fileName}");

                bitmap.Save(serverPath);
                model.Image = $"/Images/{fileName}";
            }

            await _gameService.AddGameAsync(_mapper.Map<Game>(model));

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var game = _gameService.GetGame(id);
            return View(_mapper.Map<GameViewModel>(game));
        }

        [HttpPost]
        public ActionResult Edit()
        {
            return View();
        }

        // type=Developer  // value=Bogdan
        public ActionResult Filter(string type, string value)
        {
            var filter = new GamesFilter()
            {
                Name = value,
                Type = type
            };

            // predicate: x => x.Developer == Bogdan
            // predicate: x => x.Genre == RPG

            if (type == "developer")
            {
                filter.Predicate = (x => x.Developer.Name == value);
            }
            else if (type == "genre")
            {
                filter.Predicate = (x => x.Genre.Name == value);
            }

            var filters = new List<GamesFilter>();
            if (Session["GamesFilter"] != null)
            {
                filters = Session["GamesFilter"] as List<GamesFilter>;
            }

            var found = filters.FirstOrDefault(f => f.Name == value && f.Type == type);
            if (found != null)
            {
                filters.Remove(found);
            }
            else
            {
                filters.Add(filter);
            }

            Session["GamesFilter"] = filters;

            var games = _gameService.GetAllGames(filters);
            SetViewBag();

            return PartialView("GamesPartial", _mapper.Map<List<GameViewModel>>(games));
        }
    }
}

// new Controller(new GameService(new EfRepository(new DbContext)))