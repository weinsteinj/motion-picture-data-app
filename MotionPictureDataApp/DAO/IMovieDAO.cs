using MotionPictureDataApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotionPictureDataApp.MovieDAO
{
    public interface IMovieDAO
    {
        Movie AddMovie(NewMovieDTO newMovieDTO);
        List<Movie> AllMovies();

        Movie GetMovieById(int movieId);

        Movie UpdateMovie(UpdateMovieDTO updateMovieDTO);

        void DeleteMovie(int Id);
    }

}
