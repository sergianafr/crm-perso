using Newtonsoft.Json;
using crm_perso.Extensions;
using Microsoft.AspNetCore.Mvc;
using crm_perso.export;
using System.Text;

namespace crm_perso.Controllers;

public class ExportController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    public ExportController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public IActionResult Index(){
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> UploadJson(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Aucun fichier sélectionné.");
            }

            try
            {
                using (var streamReader = new StreamReader(file.OpenReadStream()))
                {
                    var jsonContent = await streamReader.ReadToEndAsync();

                    var client = _httpClientFactory.CreateClient();
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    var springApiUrl = "http://localhost:8080/api/import/";

                    var response = await client.PostAsync(springApiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        return Ok("Fichier envoyé avec succès.");
                    }
                    else
                    {
                        return StatusCode((int)response.StatusCode, "Erreur lors de l'envoi au serveur Spring.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return StatusCode(500, $"Erreur serveur : {ex.Message}");
            }
        }

    // public async Task<IActionResult> UploadJson(IFormFile file)
    // {
    //     if (file == null || file.Length == 0)
    //     {
    //         return BadRequest("Aucun fichier fourni");
    //     }

    //     try
    //     {
    //         // 1. Lire et désérialiser le fichier JSON
    //         using var stream = file.OpenReadStream();
    //         using var reader = new StreamReader(stream);
    //         var jsonContent = await reader.ReadToEndAsync();
    //         var customerExport = JsonConvert.DeserializeObject<CustomerExport>(jsonContent);
            
    //         Console.WriteLine("Objet désérialisé:");
    //         Console.WriteLine(jsonContent);

    //         // 2. Envoyer l'objet à l'API Java
    //         using var httpClient = new HttpClient();
    //         var javaApiUrl = "http://localhost:8080/api/import/"; // Adaptez l'URL
            
    //         // Convertir l'objet en JSON
    //         var jsonPayload = JsonConvert.SerializeObject(customerExport);
    //         var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json"); // Utilisez jsonPayload ici

    //         // Envoyer la requête POST
    //         var response = await httpClient.PostAsync(javaApiUrl, content);

    //         // 3. Traiter la réponse
    //         if (response.IsSuccessStatusCode)
    //         {
    //             var responseBody = await response.Content.ReadAsStringAsync();
    //             return Ok(new { 
    //                 Message = "Objet envoyé avec succès à l'API Java",
    //                 JavaResponse = responseBody,
    //                 StatusCode = response.StatusCode
    //             });
    //         }
    //         else
    //         {
    //             var errorResponse = await response.Content.ReadAsStringAsync();
    //             return StatusCode((int)response.StatusCode, new {
    //                 Message = "Erreur lors de l'envoi à l'API Java",
    //                 JavaError = errorResponse,
    //                 StatusCode = response.StatusCode
    //             });
    //         }
    //     }
    //     catch (JsonException ex)
    //     {
    //         return BadRequest($"Erreur de désérialisation JSON: {ex.Message}");
    //     }
    //     catch (HttpRequestException ex)
    //     {
    //         return StatusCode(500, $"Erreur HTTP vers l'API Java: {ex.Message}");
    //     }
    //     catch (Exception ex)
    //     {
    //         return StatusCode(500, $"Erreur inattendue: {ex.Message}");
    //     }
    // }
}