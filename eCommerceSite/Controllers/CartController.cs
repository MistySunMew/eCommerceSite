using eCommerceSite.Data;
using eCommerceSite.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol;

namespace eCommerceSite.Controllers
{
    public class CartController : Controller
    {
        private readonly VideoGameContext _context;
        private const string CartCookieName = "Cart";

        public CartController(VideoGameContext context)
        {
            _context = context;
        }

        public IActionResult Add(int id)
        {
            Game? game = _context.Games.Where(g => g.GameID == id).SingleOrDefault();

            if (game == null)
            {
                //Game with specified ID does not exist
                TempData["Message"] = $"Sorry that game no longer exists";
                return RedirectToAction("Index", "Games");
            }

            CartGameViewModel cartGame = new() { GameID = game.GameID, Title = game.Title, Price = game.Price };

            List<CartGameViewModel> cartGames = GetExistingCartData();
            cartGames.Add(cartGame);
            WriteShoppingCartCookie(cartGames);

            TempData["Message"] = $"{game.Title} added to cart";
            return RedirectToAction("Index", "Games");
        }

        private void WriteShoppingCartCookie(List<CartGameViewModel> cartGames)
        {
            HttpContext.Response.Cookies.Append(CartCookieName, JsonConvert.SerializeObject(cartGames), new CookieOptions() { Expires = DateTime.Now.AddYears(1) });
        }

        /// <summary>
        /// Return the current list of video games in the users shopping cart.
        /// If there is no cookie, an empty list will be returned
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private List<CartGameViewModel> GetExistingCartData()
        {
            string? cookie = HttpContext.Request.Cookies[CartCookieName];
            if (string.IsNullOrWhiteSpace(cookie))
            {
                return new List<CartGameViewModel>();
            }
            return JsonConvert.DeserializeObject<List<CartGameViewModel>>(cookie);
        }

        public IActionResult Summary()
        {
            List<CartGameViewModel> cartGames = GetExistingCartData();
            return View(cartGames);
        }

        public IActionResult Remove(int id)
        {
            List<CartGameViewModel> cartGames = GetExistingCartData();
            
            CartGameViewModel? targetGame = cartGames.FirstOrDefault(g => g.GameID == id);

            if (targetGame != null)
            {
                cartGames.Remove(targetGame);
            }

            WriteShoppingCartCookie(cartGames);

            return RedirectToAction(nameof(Summary));
        }
    }
}
