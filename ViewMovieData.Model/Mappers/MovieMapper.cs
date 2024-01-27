using ViewMovieData.Model.Dtos.MovieDtos;
using ViewMovieData.Model.Models;

namespace ViewMovieData.Model.Mappers
{
    public static class MovieMapper
    {
        public static MovieDto ToMovieDto(this Movie movie)
        {
            return new MovieDto
            {
                Id = movie.Id,
                Name = movie.Name,
                IsOutNow = movie.IsOutNow,
                ProductionDate = movie.ProductionDate,
                GenreId = movie.GenreId,
                VideoTypeId = movie.VideoTypeId
            };
        }

        public static Movie ToMovieFromCreateMovieDto(this CreateMovieDto createMovieDto)
        {
            return new Movie
            {
                Name = createMovieDto.Name,
                IsOutNow = createMovieDto.IsOutNow,
                ProductionDate = createMovieDto.ProductionDate,
                GenreId = createMovieDto.GenreId,
                VideoTypeId = createMovieDto.VideoTypeId
            };
        }

       
    }
}
