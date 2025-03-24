using Microsoft.AspNetCore.Mvc;

namespace crm_perso.Controllers
{
    public class LoginController : Controller{
        private readonly HttpClient _httpClient;
        public LoginController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public IActionResult Index()
        {
            return View();
        }


    }
}