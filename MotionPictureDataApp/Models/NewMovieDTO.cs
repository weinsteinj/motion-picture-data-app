using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotionPictureDataApp.Models
{
    public class NewMovieDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int ReleaseYear { get; set; }

        public NewMovieDTO(string name, string description, int releaseYear) 
        {
            Name = name;
            Description = description;
            ReleaseYear = releaseYear;
       
        }
        public NewMovieDTO()
        {
   
        }
    }
}
