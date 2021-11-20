using FilmDB.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmDB.Controllers
{
    public class FilmController : Controller
    {
        public IActionResult Index()
        {
            FilmManager filmManager = new FilmManager();
            List<FilmModel> films = filmManager.GetFilms();

            return View(films);
        }

        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Add(FilmModel film)
        {
            FilmManager filmManager = new FilmManager();
            filmManager.AddFilm(film);

            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            var manager = new FilmManager();
            var film = manager.GetFilm(id);
            return View(film);
        }

        public IActionResult RemoveConfirm(int id)
        {
            var manager = new FilmManager();
            try
            {
                manager.RemoveFilm(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var manager = new FilmManager();
            var film = manager.GetFilm(id);

            return View(film);
        }

        [HttpPost]
        public IActionResult Edit(FilmModel film)
        {
            var manager = new FilmManager();
            manager.UpdateFilm(film);

            return View(film);
        }
    }
}
