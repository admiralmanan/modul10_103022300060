using Microsoft.AspNetCore.Mvc;
using modul10_103022300060;

namespace modul10_103022300060.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private static List<Movie> listFilm = new List<Movie>
     {
            new Movie("The Shawshank Redemption", "Frank Darabont",  new List<string>{"Tim Robbins", "Morgan Freeman", "Bob Gunton"}, "A banker convicted of uxoricide forms a friendship over a quarter century with a hardened convict, while maintaining his innocence and trying to remain hopeful through simple compassion."),
            new Movie("The Godfather", "Francis Ford Coppola",  new List<string> { "Marlon Brando", "Al Pacino", "James Caan" }, "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son."),
            new Movie ("The Dark Knight", "Christoper Nolan",  new List<string> { "Christian Bale", " Christoper Nolan", "Aaron Eckhart" }, "When a menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman, James Gordon and Harvey Dent must work together to put an end to the madness.")
     };

        [HttpGet]
        public ActionResult<IEnumerable<Movie>> GetMovie()
        {
            return Ok(listFilm);
        }

        [HttpGet("{index}")]
        public ActionResult<Movie> GetMahasiswaByIndex(int index)
        {
            if (index < 0 || index >= listFilm.Count)
            {
                return NotFound("Film tidak ditemukan");
            }
            return Ok(listFilm[index]);
        }

        [HttpPost]
        public ActionResult<Movie> PostMahasiswa(Movie movie)
        {
            listFilm.Add(movie);
            return CreatedAtAction(nameof(GetMahasiswaByIndex), new { index = listFilm.Count - 1 }, movie);
        }

        [HttpDelete]
        public IActionResult DeleteMahasiswa(int index)
        {
            if (index < 0 || index >= listFilm.Count)
            {
                return NotFound("Mahasiswa tidak ditemukan untuk dihapus");
            }

            listFilm.RemoveAt(index);
            return NoContent();
        }
    }
};
