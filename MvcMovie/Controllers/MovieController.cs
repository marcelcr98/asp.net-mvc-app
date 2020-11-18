﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            List<Movie> movies = new List<Movie>();
            if (Session["Movies"] == null)
            {

                movies.Add(new Movie { ID = 1, Title = "Joker", Price = 70, Genre = "Suspense", ReleaseDate = DateTime.Now });
                movies.Add(new Movie { ID = 2, Title = "Spiderman: The Movie", Price = 50, Genre = "Superhero", ReleaseDate = DateTime.Now });
                movies.Add(new Movie { ID = 3, Title = "The Lion King", Price = 80, Genre = "Animation", ReleaseDate = DateTime.Now });
                movies.Add(new Movie { ID = 4, Title = "Friday the 13th", Price = 20, Genre = "Horror", ReleaseDate = DateTime.Now });
                movies.Add(new Movie { ID = 5, Title = "The Social Network", Price = 30, Genre = "Bio", ReleaseDate = DateTime.Now });
                Session["Movies"] = movies;
            }
            else
            {
                movies = ((List<Movie>)Session["Movies"]);
            }

            return View(movies);
        }

        // GET: Movie/Details/5
        public ActionResult Details(int id)
        {
            Movie movies = ((List<Movie>)Session["Movies"]).
                Where(x => x.ID == id).
                FirstOrDefault();

            return View(movies);

        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            try
            {
                // TODO: Add insert logic here
                ((List<Movie>)Session["Movies"]).Add(movie);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int id)
        {
            Movie movies = ((List<Movie>)Session["Movies"]).
                Where(x => x.ID == id).
                FirstOrDefault();

            return View(movies);
        }

        // POST: Movie/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Movie movie)
        {
            try
            {
                // TODO: Add update logic here
                Movie movieFind = ((List<Movie>)Session["Movies"]).Where(x => x.ID == id).FirstOrDefault();
                movieFind = movie;
                movieFind.Title = movie.Title;
                movieFind.Price = movie.Price;
                movieFind.ReleaseDate = movie.ReleaseDate;
                movieFind.Genre = movie.Genre;
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int id)
        {
            Movie movies = ((List<Movie>)Session["Movies"]).
                Where(x => x.ID == id).
                FirstOrDefault();

            return View(movies);
        }

        // POST: Movie/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, List<Movie> movies)
        {
            try
            {
                // TODO: Add delete logic here
                List<Movie> movie = ((List<Movie>)Session["Movies"]);
                for (int i = 0; i < movie.Count; i++)
                    if (movie[i].ID == id)
                        movie.RemoveAt(i);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(movies);
            }
        }
    }
}