using Microsoft.AspNetCore.Mvc;

namespace ToDo.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
            // return new EmptyResult();
        }
        [HttpGet("/Success")]
        public ActionResult Success()
        {
          return View();
        }
    }
}
