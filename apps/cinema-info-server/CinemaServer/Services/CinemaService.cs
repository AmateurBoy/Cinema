﻿using CinemaServer.Data;
using CinemaServer.Data.Interface;
using CinemaServer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CinemaServer.Services
{
    
    public class CinemaService:ICinemaService
    {
        private readonly AppDbContext Context;
        public CinemaService (AppDbContext appDb)
        {
            Context = appDb;
        }

        public List<IMovieDTO> MainCinema()
        {                
            List<IMovieDTO> listI = new List<IMovieDTO>(Context.Movies.Include(x => x.Tags).ToList());            
            return listI;
        }
        public void AddMovie(Movie Movie)
        {
            Movie.DateCreate = DateTime.Now;
            Context.Movies.Add(Movie);
            Context.SaveChanges();            
        }
        public void AddRandomMovie()
        {
            string nameimg = "NameImg";
            Random random = new Random();
            Movie movie = new Movie();
            movie.Name = random.Next(0, 10000).ToString();
            movie.Description = random.Next(0, 1000).ToString();
            movie.DateCreate = DateTime.Now;
            movie.NameImg = nameimg + random.Next(0, 9999999) + ".png";
            AddMovie(movie);
        }
    }
}