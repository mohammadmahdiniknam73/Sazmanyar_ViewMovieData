using Microsoft.EntityFrameworkCore;
using ViewMovieData.Model.Contracts;
using ViewMovieData.Model.Data;
using ViewMovieData.Model.Dtos.MovieDtos;
using ViewMovieData.Model.Models;

namespace ViewMovieData.ViewModel.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApllicationDbContext _context;

        public MovieRepository(ApllicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Movie>> GetAllAsync()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie?> GetByIdAsync(int id)
        {
            return await _context.Movies.FindAsync(id);
        }

        public async Task<Movie> CreateAsync(Movie movie)
        {
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task<Movie?> UpdateAsync(int id, UpdateMovieDto updateMovieDto)
        {
            var existingMovie = await _context.Movies.FirstOrDefaultAsync(x=>x.Id == id);
            if (existingMovie == null)
            {
                return null;
            }
            existingMovie.Name = updateMovieDto.Name;
            existingMovie.IsOutNow = updateMovieDto.IsOutNow;
            existingMovie.ProductionDate = updateMovieDto.ProductionDate;
            existingMovie.GenreId = updateMovieDto.GenreId;
            existingMovie.VideoTypeId = updateMovieDto.VideoTypeId;

            _context.Update(existingMovie);

            await _context.SaveChangesAsync();
            return existingMovie;
        }

        public async Task<Movie?> DeleteAsync(int id)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(x => x.Id == id);
            if (movie == null)
            {
                return null;
            }
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

    }
}
