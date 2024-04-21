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
        TempData["StatusMessage"] = "* Yes, I agree to the terms and privacy policy.";
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
                    TempData["StatusMessage"] = "Subscribed";
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    TempData["StatusMessage"] = "Already subscribed!";
                }
            }
            catch
            {
                ViewData["Status"] = "Error";
            }
        }
        else
        {
            TempData["StatusMessage"] = "Please inter a valid email address";
        }

        return RedirectToAction("Home", "Default", "subscribe");
    }



    //[HttpPost]
    //public async Task<IActionResult> Subscribe(SubscribeViewModel model)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
    //        var response = await _httpClient.PostAsync("https://localhost:7125/api/subscribe", content);

    //        if (response.IsSuccessStatusCode)
    //        {
    //            TempData["StatusMessage"] = "You are now subscribed";
    //        }
    //        else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
    //        {
    //            TempData["StatusMessage"] = "You are already subscribed";
    //        }
    //    }
    //    else
    //    {
    //        TempData["StatusMessage"] = "Invalid email address";
    //    }

    //    return RedirectToAction("Home", "Default", "subscribe");
    //}



}


//https://localhost:7287/api/Subscribe