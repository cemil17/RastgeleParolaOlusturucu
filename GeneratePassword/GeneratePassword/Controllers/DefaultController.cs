using GeneratePassword.DataAccessLayer.Concrete;
using GeneratePassword.EntityLayer.Concrete;
using GeneratePassword.Messages;
using GeneratePassword.Models.CipherModel;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using X.PagedList;

namespace GeneratePassword.Controllers
{
	public class DefaultController : Controller
	{
		private readonly Context _context;
		private readonly IToastNotification _toast;

		NtoastnotifyMessage ntoastnotifyMessage = new NtoastnotifyMessage();
		Random random = new Random();

		public DefaultController(Context context, IToastNotification toast)
		{
			_context = context;
			_toast = toast;
		}


		[HttpGet]
		public IActionResult Index()
		{
			//int length = 5;
			//string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789#$%^&!@-*()_+";

			//string password = new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());

			//ViewBag.Random = password;

			var code = random.Next(100000, 1000000);
			ViewBag.Code = "Kydb_V@ri" + code + "!" + DateTime.Now.Year;
			return View();
		}
		[HttpPost]
		public IActionResult Index(CipherViewModel model)
		{
			var code = random.Next(100000, 1000000);
			ViewBag.Code = "Kydb_V@ri" + code + "!" + DateTime.Now.Year;

			if (ModelState.IsValid)
			{
				if (ViewBag.Code != model.Password)
				{
					var values = new Cipher();
					values.GuidID = new Guid();
					values.Password = model.Password;
					values.Description = model.Description;

					_context.Ciphers.Add(values);
					_context.SaveChanges();

					_toast.AddSuccessToastMessage(ntoastnotifyMessage.descriptionSuccess,
						new ToastrOptions { Title = ntoastnotifyMessage.descriptionSuccessTitle });

					return RedirectToAction("CipherList");
				}
				else
				{
					_toast.AddErrorToastMessage(ntoastnotifyMessage.descriptionError,
						new ToastrOptions { Title = ntoastnotifyMessage.descriptionErrorTitle });

					return View("Index");
				}

			}

			return View();
		}
		public IActionResult CipherList(string p, int page = 1)
		{
			var values = from x in _context.Ciphers select x;

			if (!string.IsNullOrEmpty(p))
			{
				values = values.Where(c => c.Description.Contains(p));
			}

			return View(values.OrderByDescending(i => i.GuidID).ToPagedList(page, 5));
		}

	}
}
