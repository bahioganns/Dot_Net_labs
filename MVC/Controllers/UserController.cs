using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC.Models;
using System.Net.Http;

using DTO;

namespace MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private HttpClient client = new HttpClient();

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAPI(string email, string description)
        {
            UserDTO user = new UserDTO{ Email=email, Description=description };
            var response = client.PostAsJsonAsync($"http://localhost:5000/api/user", user).Result;

            return Redirect("/Home/Index");
        }

        public IActionResult Update(int id)
        {
            var response = client.GetAsync($"http://localhost:5000/api/user/{id}").Result;

            ViewData["User"] = response.Content.ReadAsAsync<UserDTO>().Result;

            return View();
        }

        [HttpPost]
        public IActionResult UpdateAPI(int id, string email, string description)
        {
            UserDTO user = new UserDTO{ Email=email, Description=description };
            var response = client.PutAsJsonAsync($"http://localhost:5000/api/user/{id}", user).Result;

            return Redirect("/Home/Index");
        }

        public IActionResult Delete(int id)
        {
            var response = client.DeleteAsync($"http://localhost:5000/api/user/{id}").Result;

            return Redirect("/Home/Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
