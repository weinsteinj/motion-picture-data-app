using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MotionPictureDataApp.MovieDAO;
using System.Data.SqlClient;


namespace MotionPictureDataApp.DAO

{
    public class MovieSqlDAO : IMovieDAO
    {
        private readonly string connectionString;

        public MovieSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
            
            public List<Movie> AllMovies()
            {
            List<Movie> allMovies = new List<Movie> { };

            try
            {
                using (SqlConnection sqlConnect = new SqlConnection(connectionString))

                {
                    sqlConnect.Open();

                    SqlCommand query = new SqlCommand(
                        "SELECT * FROM movies;", sqlConnect);

                    SqlDataReader sqlReader = query.ExecuteReader();

                    while (sqlReader.Read())
                    {
                        Movie movieRecord = MapMovieFromReader(sqlReader);
                        allMovies.Add(movieRecord);
                    }

                }

            }
            catch (SqlException)
            {
                throw;
            }

            return allMovies;
            }

            public Movie AddMovie(string name, int releaseYear, string description)
            {
            Movie movie = new Movie(name, releaseYear, description);
            return movie;
            }

            public Movie UpdateMovie()
            {
            Movie updatedMovie = null;
            return updatedMovie;
            }

            public void DeleteMovie(int id)
            {
            //delete the movie at DB
            }

            private Movie MapMovieFromReader (SqlDataReader sqlReader)
        {
            Movie mappedMovie = new Movie();

            mappedMovie.Id = Convert.ToInt32(sqlReader["Id"]);
            mappedMovie.Name = Convert.ToString(sqlReader["Name"]);
            mappedMovie.Description = Convert.ToString(sqlReader["Description"]);
            mappedMovie.ReleaseYear = Convert.ToInt32(sqlReader["ReleaseYear"]);

            return mappedMovie;
        


        }






        }
}
