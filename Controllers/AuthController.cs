using crm_perso.Extensions;
using crm_perso.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Threading.Tasks;

namespace crm_perso.Controllers
{
    public class AuthController : Controller
    {
        private readonly HttpClient _httpClient;

        public AuthController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> CheckEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                ModelState.AddModelError("email", "Email required");
                return View("Index");
            }

            try
            {
                var content = new StringContent(
                    email, 
                    Encoding.UTF8,
                    "text/plain"
                );
                Console.WriteLine($"Email envoyé : {email}");

                var response = await _httpClient.PostAsync("http://localhost:8080/api/login/", content);
                Console.WriteLine($"Statut reçu : {response.StatusCode}");

                if (response.IsSuccessStatusCode)
                {
                    var userData = await response.Content.ReadFromJsonAsync<UserWRole>();
                    
                    HttpContext.Session.SetObject("CurrentUser", userData);
                    HttpContext.Session.SetString("UserEmail", email);
                    Console.WriteLine(HttpContext.Session.GetObject<UserWRole>("CurrentUser").role);
                    
                    return RedirectToAction("Index", "Home");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    ModelState.AddModelError("email", "Utilisateur non trouvé");
                    return View("Index");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    TempData["AttemptedEmail"] = email;
                    return View("~/Views/Shared/AccessDenied.cshtml");
                }

                ModelState.AddModelError(string.Empty, $"Erreur du serveur : {response.StatusCode}");
                return View("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur : {ex.Message}");
                ModelState.AddModelError(string.Empty, "Erreur lors de la communication avec le serveur");
                return View("Index");
            }
        }
    }
}