namespace FootballManager.Controllers
{
    using BasicWebServer.Server.Attributes;
    using BasicWebServer.Server.Controllers;
    using BasicWebServer.Server.HTTP;
    using FootballManager.Data.Models;
    using FootballManager.Services;

    public class UsersController : Controller
    {
        private readonly IValidator validator;
        public UsersController(Request request, IValidator validator) 
            : base(request)
        {
            this.validator = validator;
        }

        public Response Login()
        {
            return View();
        }

        public Response Register()
        {
            return View();
        }

        [HttpPost]
        public Response Register(RegisterViewModel model)
        {
            if (!this.validator.ValidateUserRegistration(model))
            {
                return BadRequest();
            }
            return View();
        }
    }
}
