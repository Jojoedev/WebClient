using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NPOI.SS.Formula.Functions;
using System.Collections.Generic;
using WebClient.Interface;
using WebClient.Models;
using WebClient.Service;
using static WebClient.Models.Domain;

namespace WebClient.Controllers
{
    public class EntryController : Controller
    {
        
        HttpClient client;

        public EntryController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://api.publicapis.org/");
        }
                
        public IActionResult Index()
        {
            List<T> domain = new List<T>();
            
            var response = client.GetAsync(client.BaseAddress+"entries").Result;
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                domain = JsonConvert.DeserializeObject<List<T>>(content);

            }
            return View(domain);
        }
    }
}
