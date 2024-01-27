using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewMovieData.Model.Models
{
    public class VideoType:Entity
    {
        public ICollection<Movie> Movies { get; set; }

    }
}
