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

		public async Task<IActionResult> Index()
		{
			List<Game> games = await _context.Games.ToListAsync();
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
            Game game = await _context.Games.FindAsync(id);

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

                ViewData["Message"] = $"{game.Title} updated successfully!";

                return RedirectToAction("Index");
            }

            return View(game);
        }
    }
}
