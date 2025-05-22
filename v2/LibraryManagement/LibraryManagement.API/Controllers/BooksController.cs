using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Controllers
{
    public class BooksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
