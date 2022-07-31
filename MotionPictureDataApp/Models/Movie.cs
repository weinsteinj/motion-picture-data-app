using System;

namespace MotionPictureDataApp
{
    public class Movie
    {
       
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public int ReleaseYear { get; set; }


        public Movie(string name, int releaseYear, string description)
        {
            Name = name;
            ReleaseYear = releaseYear;
            Description = description;
        }

        public Movie()
        {
            
        }

    }


}

