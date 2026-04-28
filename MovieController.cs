using Microsoft.AspNetCore.Mvc;
using modul9_103082400017;

namespace modul9_NIM.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MoviesController : ControllerBase
{
    private static readonly List<Movie> movies =
    [
        new Movie {
            Title = "The Shawshank Redemption",
            Director = "Frank Darabont",
            Stars = ["Tim Robbins", "Morgan Freeman"],
            Description = "Two imprisoned men bond over a number of years."
        },
        new Movie {
            Title = "The Godfather",
            Director = "Francis Ford Coppola",
            Stars = ["Marlon Brando", "Al Pacino"],
            Description = "The aging patriarch transfers control of his empire."
        },
        new Movie {
            Title = "The Dark Knight",
            Director = "Christopher Nolan",
            Stars = ["Christian Bale", "Heath Ledger"],
            Description = "Batman faces the Joker."
        }
    ];

    [HttpGet]
    public ActionResult<List<Movie>> GetMovies()
    {
        return movies;
    }

    [HttpGet("{id}")]
    public ActionResult<Movie> GetMovie(int id)
    {
        if (id < 0 || id >= movies.Count)
            return NotFound();

        return movies[id];
    }

    [HttpPost]
    public ActionResult AddMovie([FromBody] Movie movie)
    {
        movies.Add(movie);
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteMovie(int id)
    {
        if (id < 0 || id >= movies.Count)
            return NotFound();

        movies.RemoveAt(id);
        return Ok();
    }
}