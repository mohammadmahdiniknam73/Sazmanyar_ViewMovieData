using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewMovieData.Model.Models
{
    public class Movie: Entity
    {
        public DateOnly ProductionDate { get; set; }
        public bool IsOutNow { get; set; }
        public int GenreId { get; set; }
        public int VideoTypeId { get; set; }
        public Genre Genre { get; set; }
        public VideoType VideoType { get; set; }

    }
}
