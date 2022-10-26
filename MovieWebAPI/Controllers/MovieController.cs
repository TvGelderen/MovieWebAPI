using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieWebAPI.Data;
using MovieWebAPI.Models;

namespace MovieWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public MovieController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Movie>>> Get()
        {
            return Ok(await _context.Movie_db.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> Get(int id)
        {
            var movie = await _context.Movie_db.FindAsync(id);

            return movie != null ? Ok(movie) : BadRequest("Movie not found.");
        }

        [HttpPost]
        public async Task<ActionResult<List<Movie>>> Post(Movie movie)
        {
            _context.Movie_db.Add(movie);
            await _context.SaveChangesAsync();

            return Ok(await _context.Movie_db.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult> Put(Movie movie)
        {
            _context.Movie_db.Update(movie);
            await _context.SaveChangesAsync();

            return Ok(movie);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Movie>>> Delete(int id)
        {
            var movie = _context.Movie_db.SingleOrDefault(x => x.Id == id);

            if (movie == null)
                return BadRequest("Movie not found.");

            _context.Movie_db.Remove(movie);
            await _context.SaveChangesAsync();

            return(await _context.Movie_db.ToListAsync());
        }
    }
}
