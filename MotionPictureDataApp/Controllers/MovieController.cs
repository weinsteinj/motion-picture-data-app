using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MotionPictureDataApp.DAO;
using MotionPictureDataApp.MovieDAO;
using MotionPictureDataApp.Models;
using Microsoft.AspNetCore.Cors;

namespace MotionPictureDataApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("MyPolicy")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieDAO movieDao;
        public MovieController(IMovieDAO movieDAO)
        {
            this.movieDao = movieDAO;
        }

        [EnableCors("MyPolicy")]
        [HttpPost]
        public Movie PostNewMovie(NewMovieDTO newMovieDTO) 
        {
            return movieDao.AddMovie(newMovieDTO);
        }

        [EnableCors("MyPolicy")]
        [HttpGet]
        public IList<Movie> AllMovies()
        {
            return movieDao.AllMovies();
        }

        [EnableCors("MyPolicy")]
        [HttpGet("{id}")]
        public Movie GetMovieById(int id)
        {
            return movieDao.GetMovieById(id);
        }

        [EnableCors("MyPolicy")]
        [HttpPut("{id}")]
        public Movie UpdateMovie(UpdateMovieDTO updateMovieDTO) 
        {
            return movieDao.UpdateMovie(updateMovieDTO);
        }

        [EnableCors("MyPolicy")]
        [HttpDelete("{id}")]
        public void DeleteMovieById (int id)
        {
            movieDao.DeleteMovie(id);
        }
    }
}
