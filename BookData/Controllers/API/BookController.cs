using Microsoft.AspNetCore.Mvc;

namespace BookData.Controllers.API
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
