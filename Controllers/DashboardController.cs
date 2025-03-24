using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;
using crm_perso.Models;

namespace crm_perso.Controllers;
public class DashboardController : Controller
{
    private readonly HttpClient _httpClient;

    public DashboardController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // [HttpGet]
    // public async Task<IActionResult> Index()
    // {
    //     try
    //     {
    //         string apiUrl = "http://localhost:8080/api/dashboards/"; // Remplace par l'URL de ton API Java
    //         HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

    //         if (response.IsSuccessStatusCode)
    //         {
    //             string jsonResponse = await response.Content.ReadAsStringAsync();
    //             var dashboardData = JsonConvert.DeserializeObject<DashboardData>(jsonResponse);
    //             return View(dashboardData);
    //         }
    //         else
    //         {
    //             Console.WriteLine($"Erreur lors de la récupération des données : {response.StatusCode}");
    //             return StatusCode((int)response.StatusCode, "Erreur lors de la récupération des données.");
    //         }
    //     }
    //     catch (Exception ex)
    //     {
    //         return StatusCode(500, $"Erreur interne du serveur : {ex.Message}");
    //     }
    // }
    public async Task<IActionResult> Index()
    {
        try
        {
            string apiUrl = "http://localhost:8080/api/dashboards/o"; 
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                // var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString);
                Console.WriteLine(jsonString);
                // Passer les valeurs à la vue
                return View();
            }
            else
            {
                return StatusCode((int)response.StatusCode, "Erreur lors de la récupération des données.");
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur interne du serveur : {ex.Message}");
        }
    }
    public async Task<IActionResult> Tickets()
    {
        try
        {
            string apiUrl = "http://localhost:8080/api/dashboards/tickets"; // URL de ton API Spring Boot
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            var jsonString = await response.Content.ReadAsStringAsync();
            Console.WriteLine(jsonString);
            var tickets = JsonConvert.DeserializeObject<List<TicketDto>>(jsonString);
            Console.WriteLine(tickets);
            return View(tickets);
            //     else
            //     {
            //         return StatusCode((int)response.StatusCode, "Erreur lors de la récupération des données.");
            //     }
            // }
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur interne du serveur : {ex.Message}");
        }
    }
    public async Task<IActionResult> Leads()
    {
        try
        {
            string apiUrl = "http://localhost:8080/api/dashboards/leads"; 
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            var jsonString = await response.Content.ReadAsStringAsync();
            Console.WriteLine(jsonString);
            var leads = JsonConvert.DeserializeObject<List<LeadDto>>(jsonString);
            Console.WriteLine(leads);
            return View(leads);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur interne du serveur : {ex.Message}");
        }
    }
    public async Task<IActionResult> Customers()
    {
        try
        {
            string apiUrl = "http://localhost:8080/api/dashboards/customers"; 
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);
            var jsonString = await response.Content.ReadAsStringAsync();
            Console.WriteLine(jsonString);
            var customers = JsonConvert.DeserializeObject<List<CustomerDto>>(jsonString);
            Console.WriteLine(customers);
            return View(customers);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur interne du serveur : {ex.Message}");
        }
    }
}