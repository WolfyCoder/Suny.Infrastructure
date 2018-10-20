using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using WebCore.Test.Models;

namespace WebCore.Test.Controllers
{
    public class HomeController : Controller
    {
        private readonly TestContext testContext;

        public HomeController(TestContext testContext)
        {
            this.testContext = testContext;
        }

        public async Task<string> Index()
        {
            var result = await testContext.Blogs.FindAsync<BsonDocument>(Builders<BsonDocument>.Filter.Empty);
            return result?.FirstOrDefault().ToJson();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
    }
}
