using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MotionPictureDataApp.Models
{
    public class NewMovieDTO
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [Range(1800, 2300)]
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
