using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using crm_perso.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Newtonsoft.Json;

namespace crm_perso.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly HttpClient _httpClient = new HttpClient();
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            string apiUrl = "http://localhost:8080/api/dashboards/"; // URL de ton API Spring Boot
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            var jsonString = await response.Content.ReadAsStringAsync();
            Console.WriteLine(jsonString);
            var dashboardData = JsonConvert.DeserializeObject<DashboardData>(jsonString);
            System.Console.WriteLine(dashboardData);
            return View(dashboardData);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur interne du serveur : {ex.Message}");
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult Rate()
    {
        return View();
    }
    
}
