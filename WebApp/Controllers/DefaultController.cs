using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebApp.ViewModels;
using static System.Net.WebRequestMethods;

namespace WepApp.Controllers;

public class DefaultController(HttpClient httpClient) : Controller
{
    private readonly HttpClient _httpClient = httpClient;



    public IActionResult Home()
    {
       
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Subscribe(SubscribeViewModel model)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("https://localhost:7125/api/Subscribe", content);

                if (response.IsSuccessStatusCode)
                {
                    TempData["StatusMessage"] = "You are now subscribed";
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    TempData["StatusMessage"] = "You are already subscribed";
                }
            }
            catch
            {
                TempData["StatusMessage"] = "ConnectionFailed";
            }
        }
        else
        {
            TempData["StatusMessage"] = "Invalid email address";
        }

        return RedirectToAction("Home", "Default", "subscribe");
    }




}


