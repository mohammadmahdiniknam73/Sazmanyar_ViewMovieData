using Microsoft.AspNetCore.Mvc;
using ViewMovieData.Model.Contracts;
using ViewMovieData.Model.Dtos.MovieDtos;
using ViewMovieData.Model.Mappers;
using ViewMovieData.Model.Models;

namespace ViewMovieData.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly IMovieRepository _movieRepository;

        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var movies = await _movieRepository.GetAllAsync();
            var moviesDto = movies.Select(s => s.ToMovieDto());
            return Ok(moviesDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie.ToMovieDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMovieDto createMovieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var movie = createMovieDto.ToMovieFromCreateMovieDto();
                await _movieRepository.CreateAsync(movie);
                return CreatedAtAction(nameof(GetById), new { id = movie.Id }, movie.ToMovieDto());
            }
            catch (Exception ex)
            {
                // Log the exception details
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdateMovieDto updateMovieDto)
        {
            var movie = await _movieRepository.UpdateAsync(id, updateMovieDto);
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie.ToMovieDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _movieRepository.DeleteAsync(id);
            return Ok(movie);
        }
    }
}
