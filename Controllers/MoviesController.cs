using Microsoft.AspNetCore.Mvc;
using MFlixApi.Services;
using MFlixApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MFlixApi.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private readonly IMovieService movieService;

        public MoviesController(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        // GET: api/values
        [HttpGet]
        public ActionResult<List<Movie>> Get()
        {
            return movieService.Get();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Movie> Get(string id)
        {
            var movie = movieService.Get(id);
            if(movie == null)
            {
                return NotFound("Movie doesnt exist");
            }
            return movie;
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Movie> Post([FromBody] Movie movie)
        {
            movieService.Create(movie);
            return CreatedAtAction(nameof(Get), new { id = movie.id }, movie);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Movie movie)
        {
            var existingMovie = movieService.Get(id);
            if (existingMovie == null)
            {
                return NotFound("Movie doesnt exist");
            }
            movieService.Update(id, movie);

            return Ok("Movie updated");
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var existingMovie = movieService.Get(id);
            if (existingMovie == null)
            {
                return NotFound("Movie doesnt exist"); ;
            }
            movieService.Remove(id);

            return Ok("Movie deleted");
        }
    }
}

