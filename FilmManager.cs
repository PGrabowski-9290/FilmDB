using FilmDB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmDB
{
    public class FilmManager
    {
        public FilmManager AddFilm(FilmModel filmModel)
        {
            using(FilmContext context = new FilmContext())
            {
                try
                {
                    context.Films.Add(filmModel);
                    context.SaveChanges();
                }
                catch (Exception)
                {
                    filmModel.ID = 0;
                    context.Films.Add(filmModel);
                    context.SaveChanges();
                }
            }
            return this;
        }

        public FilmManager RemoveFilm(int id)
        {
            using( FilmContext context = new FilmContext())
            {
                try
                {
                    var delFilm = context.Films.Where(f => f.ID == id).SingleOrDefault();
                    _ = context.Films.Remove(delFilm);
                    context.SaveChanges();
                }
                catch(Exception)//DbUpdateException
                {
                    //Error message TODO
                }
            }
            return this;
        }

        public FilmManager UpdateFilm(FilmModel filmModel)
        {
            using(FilmContext context = new FilmContext())
            {
                try
                {
                    context.Update(filmModel);
                    context.SaveChanges();
                }
                catch(Exception)
                {
                    //TODO
                }
            }
            return this;
        }

        public FilmManager ChangeTitle(int id, string newTitle)
        {
            using (FilmContext context = new FilmContext())
            {
                try
                {
                    var updatedFilmModel = context.Films.Where(f => f.ID == id).SingleOrDefault();
                    if (newTitle != null)
                    {
                        updatedFilmModel.Title = newTitle;
                    }
                    else
                    {
                        updatedFilmModel.Title = "Brak Tytułu";
                    }

                    context.Update(updatedFilmModel);
                    context.SaveChanges();
                }
                catch (Exception)
                {
                    //TODO
                }
            }
            return this;
        }

        public FilmModel GetFilm(int id)
        {
            using FilmContext context = new FilmContext();
            FilmModel film = context.Films.SingleOrDefault(f => f.ID == id);
            return film;
        }

        public List<FilmModel> GetFilms()
        {
            using FilmContext context = new FilmContext();
            return context.Films.ToList();
        }
    }

}
