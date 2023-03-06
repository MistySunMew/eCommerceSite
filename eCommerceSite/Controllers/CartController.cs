using eCommerceSite.Data;
using eCommerceSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceSite.Controllers
{
    public class CartController : Controller
    {
        private readonly VideoGameContext _context;

        public CartController(VideoGameContext context)
        {
            _context = context;
        }

        public IActionResult Add(int id)
        {
            Game? game = _context.Games.Where(g => g.GameID == id).SingleOrDefault();

            if (game != null)
            {
                //Game with specified ID does not exist
                TempData["Message"] = $"Sorry that game no longer exists";
                return RedirectToAction("Index", "Games");
            }

            //TODO add game to cart
            TempData["Message"] = $"{game.Title} added to cart";
            return RedirectToAction("Index", "Games");
        }
    }
}
