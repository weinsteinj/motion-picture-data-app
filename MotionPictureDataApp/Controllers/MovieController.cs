using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MotionPictureDataApp.DAO;
using MotionPictureDataApp.MovieDAO;

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


        //[HttpPost]
        //public 

        //{
        //}

        [HttpGet]
        public IList<Movie> AllMovies()
        {
            return movieDao.AllMovies();

        }


        //[HttpPut]
        //public 
        //{}

        //[HttpDelete]
        //public void 
        //{

        //}



    }
}
