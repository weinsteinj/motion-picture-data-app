﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MotionPictureDataApp.DAO;
using MotionPictureDataApp.MovieDAO;
using MotionPictureDataApp.Models;

namespace MotionPictureDataApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieDAO movieDao;


        public MovieController(IMovieDAO movieDAO)
        {
            this.movieDao = movieDAO;
        }


        [HttpPost]
        public Movie PostNewMovie(NewMovieDTO newMovieDTO) 
        {

            return movieDao.AddMovie(newMovieDTO);
        }

        [HttpGet]
        public IList<Movie> AllMovies()
        {
            return movieDao.AllMovies();

        }


        [HttpGet("{id}")]
        public Movie GetMovieById(int id)
        {
            return movieDao.GetMovieById(id);

        }


        //[HttpPut]
        //public 
        //{}

        [HttpDelete("/{id}")]
        public void DeleteMovieById (int id)
        {
            movieDao.DeleteMovie(id);
        }



    }
}
