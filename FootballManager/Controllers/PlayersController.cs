namespace FootballManager.Controllers
{
    using BasicWebServer.Server.Attributes;
    using BasicWebServer.Server.Controllers;
    using BasicWebServer.Server.HTTP;
    using FootballManager.Data.Models;

    public class PlayersController : Controller
    {
        public PlayersController(Request request) 
            : base(request)
        {
        }
        public Response Add()
        {
            return View();
        }
        public Response All()
        {
            return View();
        }
        public Response Collection()
        {
            return View();
        }

        [HttpPost]
        public Response Add(AddViewModel model)
        {
            return View();
        }
    }
}
