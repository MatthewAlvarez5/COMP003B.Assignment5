using COMP003B.Assignment5.Models;
using Microsoft.AspNetCore.Mvc;


namespace COMP003B.Assignment5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : Controller
    {
        private List<Game> _games = new List<Game>();
        public GamesController()
        {
            _games.Add(new Game { Id = 1, Title = "Example1", Genre = "RPG", Description = "Set within Microsoft Visual Studio, this game is made up.", ReleaseYear = 2023 });
            _games.Add(new Game { Id = 2, Title = "Example2", Genre = "First-Person Shooter", Description = "Set within Microsoft Visual Studio, this game is made up.", ReleaseYear = 2023 });
            _games.Add(new Game { Id = 3, Title = "Example3", Genre = "2D Side-Scroller", Description = "Set within Microsoft Visual Studio, this game is made up.", ReleaseYear = 2023 });
            _games.Add(new Game { Id = 4, Title = "Example4", Genre = "Simulation", Description = "Set within Microsoft Visual Studio, this game is made up.", ReleaseYear = 2023 });
            _games.Add(new Game { Id = 5, Title = "Example5", Genre = "Cooperative", Description = "Set within Microsoft Visual Studio, this game is made up.", ReleaseYear = 2023 });

        }
        [HttpGet]
        public ActionResult<IEnumerable<Game>> GetAllGames()
        {
            return _games;
        }

        [HttpGet("{id}")]
        public ActionResult<Game> GetGameById(int id)
        {
            var student = _games.Find(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return student;
        }

        // Create
        [HttpPost]
        public ActionResult<Game> CreateGame(Game game)
        {
            //overwrites game id by max +1
            game.Id = _games.Max(s => s.Id) + 1;
            _games.Add(game);

            return CreatedAtAction(nameof(GetGameById), new { id = game.Id }, game);
        }
        [HttpPut]
        public IActionResult UpdateGame(int id, Game updatedGame)
        {
            var game = _games.Find(s => s.Id == id);
            // Basically for loop searching for game if does, returns game
            if (game == null)
            {
                return BadRequest();
            }
            game.Title = updatedGame.Title;
            game.Genre = updatedGame.Genre;
            game.Description = updatedGame.Description;
            game.ReleaseYear = updatedGame.ReleaseYear;

            return NoContent();
        }

        //Delete
        [HttpDelete]
        public IActionResult DeleteGame(int id)
        {
            var game = _games.Find(s => s.Id == id);

            if (game == null)
            {
                return NotFound();
            }
            _games.Remove(game);

            return NoContent();
        }
    }
}
