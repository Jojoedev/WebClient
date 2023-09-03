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
    public class ItemController : Controller
    {
        
        HttpClient client;

        public ItemController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
        }
                
        public  IActionResult Index()
        {
            List<Item> domain = new List<Item>();
            
            var response = client.GetAsync(client.BaseAddress+"posts").Result;
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                domain = JsonConvert.DeserializeObject<List<Item>>(content);
            }
            else
            {
                return NotFound();
            }
           return View(domain);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult Details(int id)
        {
            Item item = new();
            var response = client.GetAsync(client.BaseAddress + "posts/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                item = JsonConvert.DeserializeObject<Item>(content);
            }
            return View(item);
        }

    }
}
