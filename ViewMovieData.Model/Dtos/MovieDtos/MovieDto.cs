using Newtonsoft.Json;
using ViewMovieData.Model.Services.Serializers;

namespace ViewMovieData.Model.Dtos.MovieDtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly ProductionDate { get; set; }
        public bool IsOutNow { get; set; }
        public int GenreId { get; set; }
        public int VideoTypeId { get; set; }
    }
}
