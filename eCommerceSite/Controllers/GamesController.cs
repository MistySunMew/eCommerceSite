using eCommerceSite.Data;
using eCommerceSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerceSite.Controllers
{
    public class GamesController : Controller
    {
        private readonly VideoGameContext _context;
        public GamesController(VideoGameContext context)
        {
            _context = context;
            
        }

		public async Task<IActionResult> Index(int? id)
		{
            const int NumGamesToDisplayPerPage = 3;
            const int PageOffset = 1;

            int currentPage = id ?? 1;

			List<Game> games = await _context.Games.Skip(NumGamesToDisplayPerPage * (currentPage - PageOffset)).Take(NumGamesToDisplayPerPage).ToListAsync();
			return View(games);
		}

		[HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Games.Add(game);
                await _context.SaveChangesAsync();

                ViewData["Message"] = $"{game.Title} added successfully!";

                return View();
            }

            return View(game);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Game? game = await _context.Games.FindAsync(id);

            if (game == null)
            {
                return NotFound();
            }
            
            return View(game);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Games.Update(game);
                await _context.SaveChangesAsync();

                TempData["Message"] = $"{game.Title} was updated successfully!";

                return RedirectToAction("Index");
            }

            return View(game);
        }

        [HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			Game? game = await _context.Games.FindAsync(id);

			if (game == null)
			{
				return NotFound();
			}

			return View(game);
		}

		[HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
		{
			Game? game = await _context.Games.FindAsync(id);
            if (game != null)
            {
                _context.Games.Remove(game);
                await _context.SaveChangesAsync();
                TempData["Message"] = $"{game.Title} was Deleted successfully!";
            }

            else 
            {
				TempData["Message"] = "Game not found!";
			}

			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Details(int id)
		{
			Game? game = await _context.Games.FindAsync(id);

			if (game == null)
			{
				return NotFound();
			}

			return View(game);
		}
	}
}
