using eCommerceSite.Data;
using eCommerceSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceSite.Controllers
{
	public class MembersController : Controller
	{
		private readonly VideoGameContext _context;

		public MembersController(VideoGameContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel model)
		{
			if (ModelState.IsValid)
			{
				Member m = new() 
				{
					Email = model.Email,
					Password = model.Password
				};

				_context.Members.Add(m);
				await _context.SaveChangesAsync();

				return RedirectToAction("Index", "Home");
			}

			return View(model);
		}

		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			if (ModelState.IsValid)
			{
				Member? m = (from member in _context.Members
						   where member.Email == model.Email &&
						   member.Password == model.Password
						   select member).SingleOrDefault();

				if (m != null)
				{
					HttpContext.Session.SetString("Email", m.Email);
					return RedirectToAction("Index", "Home");
				}

				ModelState.AddModelError(string.Empty, "Account does not exist");
			}
			
			return View(model);
		}
	}
}
