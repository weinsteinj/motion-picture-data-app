using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MotionPictureDataApp.MovieDAO;
using System.Data.SqlClient;
using MotionPictureDataApp.Models;

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
                        "SELECT * FROM MotionPictures;", sqlConnect);
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

        public Movie GetMovieById(int id)
        {
            Movie movie = new Movie();

            try
            {
                using (SqlConnection sqlConnect = new SqlConnection(connectionString))

                {
                    sqlConnect.Open();
                    SqlCommand query = new SqlCommand(
                        "SELECT * FROM MotionPictures WHERE Id = @Id", sqlConnect);
                    query.Parameters.AddWithValue("@Id", id);
                    SqlDataReader sqlReader = query.ExecuteReader();

                    if (sqlReader.Read())
                    {
                        movie = MapMovieFromReader(sqlReader);

                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return movie;
        }

        public Movie AddMovie(NewMovieDTO newMovieDTO)
        {
            Movie movie = new Movie();
            movie.Name = newMovieDTO.Name;
            movie.Description = newMovieDTO.Description;
            movie.ReleaseYear = newMovieDTO.ReleaseYear;

            try
            {
                using (SqlConnection sqlConnect = new SqlConnection(connectionString))
                {
                    sqlConnect.Open();
                    SqlCommand command = new SqlCommand(
                        "INSERT INTO MotionPictures ( Name, Description, ReleaseYear) OUTPUT INSERTED.Id VALUES(@Name, @Description, @ReleaseYear);", sqlConnect);
                    command.Parameters.AddWithValue("@Name", movie.Name);
                    command.Parameters.AddWithValue("@Description", movie.Description);
                    command.Parameters.AddWithValue("@ReleaseYear", movie.ReleaseYear);
                    movie.Id = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            // capture POST new ID and add to rest of request to return the whole Object response body and return that instead (includes --orr JUST query for newly created id...

            catch (SqlException)
            {
                throw;
            }

            return movie;
        }

        public Movie UpdateMovie(UpdateMovieDTO updateMovieDTO)
        {
            Movie updatedMovie = new Movie();

            updatedMovie.Id = updateMovieDTO.Id;
            updatedMovie.Name = updateMovieDTO.Name;
            updatedMovie.Description = updateMovieDTO.Description;
            updatedMovie.ReleaseYear = updateMovieDTO.ReleaseYear;
            {
                try
                {
                    using (SqlConnection sqlConnect = new SqlConnection(connectionString))

                    {
                        sqlConnect.Open();
                        SqlCommand nonQuery = new SqlCommand(
                           "UPDATE MotionPictures SET Name = @Name, Description = @Description, ReleaseYear = @ReleaseYear WHERE Id = @Id", sqlConnect);
                        nonQuery.Parameters.AddWithValue("@Id", updatedMovie.Id);
                        nonQuery.Parameters.AddWithValue("@Name", updatedMovie.Name);
                        nonQuery.Parameters.AddWithValue("@Description", updatedMovie.Description);
                        nonQuery.Parameters.AddWithValue("@ReleaseYear", updatedMovie.ReleaseYear);
                        nonQuery.ExecuteNonQuery();
                    }

                }
                catch (SqlException)
                {
                    throw;
                }


            }


            return updatedMovie;
        }

        public void DeleteMovie(int id)
        {
            try
            {
                using (SqlConnection sqlConnect = new SqlConnection(connectionString))

                {
                    sqlConnect.Open();
                    SqlCommand nonQuery = new SqlCommand(
                       "DELETE FROM MotionPictures WHERE Id = @Id", sqlConnect);
                    nonQuery.Parameters.AddWithValue("@Id", id);
                    nonQuery.ExecuteNonQuery();
                }

            }
            catch (SqlException)
            {
                throw;
            }


        }

        private Movie MapMovieFromReader(SqlDataReader sqlReader)
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
