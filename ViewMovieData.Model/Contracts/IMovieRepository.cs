using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewMovieData.Model.Dtos.MovieDtos;
using ViewMovieData.Model.Models;

namespace ViewMovieData.Model.Contracts
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAllAsync();
        Task<Movie?> GetByIdAsync(int id);
        Task<Movie> CreateAsync(Movie movie);
        Task<Movie?> UpdateAsync(int id, UpdateMovieDto updateMovieDto);
        Task<Movie?> DeleteAsync(int id);

    }
}
