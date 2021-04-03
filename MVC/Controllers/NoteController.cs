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
    public class NoteController : Controller
    {
        private readonly ILogger<NoteController> _logger;
        private HttpClient client = new HttpClient();

        public NoteController(ILogger<NoteController> logger)
        {
            _logger = logger;
        }

        public IActionResult FromUser(int id)
        {
            var response = client.GetAsync($"http://localhost:5000/api/user/{id}/notes").Result;

            ViewData["AllNotes"] = response.Content.ReadAsAsync<List<NoteDTO>>().Result;
            ViewData["UserId"] = id;

            return View();
        }

        public IActionResult CreateFromUser(int id)
        {
            ViewData["UserId"] = id;

            return View();
        }

        [HttpPost]
        public IActionResult CreateAPI(int userId, string title, string content)
        {
            NoteDTO note = new NoteDTO{ Title=title, Content=content };
            var response = client.PostAsJsonAsync($"http://localhost:5000/api/user/{userId}/notes", note).Result;

            return Redirect($"/Note/FromUser/{userId}");
        }

        public IActionResult Update(int id)
        {
            var response = client.GetAsync($"http://localhost:5000/api/note/{id}").Result;

            ViewData["Note"] = response.Content.ReadAsAsync<NoteDTO>().Result;

            return View();
        }

        [HttpPost]
        public IActionResult UpdateAPI(int id, int userId, string title, string content)
        {
            Console.WriteLine(id);
            Console.WriteLine(userId);
            Console.WriteLine(title);
            Console.WriteLine(content);

            NoteDTO note = new NoteDTO{ Title=title, Content=content, UserId=userId };
            var response = client.PutAsJsonAsync($"http://localhost:5000/api/note/{id}", note).Result;

            NoteDTO updatedNote = response.Content.ReadAsAsync<NoteDTO>().Result;

            return Redirect($"/Note/FromUser/{updatedNote.UserId}");
        }

        public IActionResult Delete(int id)
        {
            var getResponse = client.GetAsync($"http://localhost:5000/api/note/{id}").Result;
            NoteDTO note = getResponse.Content.ReadAsAsync<NoteDTO>().Result;

            var response = client.DeleteAsync($"http://localhost:5000/api/note/{id}").Result;

            return Redirect($"/Note/FromUser/{note.UserId}");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
