using System;
using System.ComponentModel.DataAnnotations;

namespace MotionPictureDataApp
{
    public class Movie
    {
       
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [Range(1800,2300)]
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

