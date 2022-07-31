using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotionPictureDataApp.MovieDAO
{
    public interface IMovieDAO
    {
        List<Movie> AllMovies();

        Movie AddMovie(string name, int releaseYear, string description);     
    
        Movie UpdateMovie();

        void DeleteMovie(int Id);
    
    
    
    
    }

}
