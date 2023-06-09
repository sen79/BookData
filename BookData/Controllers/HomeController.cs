﻿using BookData.Models;
using BookData.Services.Interface;
using BookData.Services.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace BookData.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBook repBook;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IBook _repBook)
        {
            repBook = _repBook;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                //TotalPrice totalPrice = repBook.GetTotalPriceAsync().Result;
                //List<Book> book = await repBook.GetBookByPagewiseListAsync(2,3);

                List<Book> list = new List<Book>();
                string apiUrl = clsCommon.APIURL + string.Format("api/BookAPI/getbooklist");

                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.GetAsync(apiUrl).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    if (result != null)
                    {
                        list = JsonConvert.DeserializeObject<List<Book>>(result);
                    }
                }

                ViewBag.List = list;
                ViewData["Title"] = "Book List";
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error" + ex.Message.ToString(), new { RequestId = 404 });
            }
        }


        [HttpGet]
        public async Task<IActionResult> AddEdit(int? id)
        {
            try
            {
                Book model = new Book();
                if (id.HasValue && id != 0)
                {
                    string apiUrl = clsCommon.APIURL + string.Format("api/BookAPI/getbookbyid?Id={0}", id.Value);

                    HttpClient client = new HttpClient();
                    HttpResponseMessage response = client.GetAsync(apiUrl).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        model = JsonConvert.DeserializeObject<Book>(await response.Content.ReadAsStringAsync());
                    }


                    ViewData["Title"] = "Book - Edit Record";
                    ViewData["SaveStatus"] = "Update";
                }
                else
                {
                    ViewData["Title"] = "Book - New Record";
                    ViewData["SaveStatus"] = "Save";
                }
                

                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error" + ex.Message.ToString(), new { RequestId = 404 });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddEdit(Book model)
        {
            try
            {
                Book list = new Book();
                if (model.BookId == 0)
                {
                    string apiUrl = clsCommon.APIURL + string.Format("api/BookAPI/");

                    using (var httpClient = new HttpClient())
                    {
                        StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                        using (var response = await httpClient.PostAsync(apiUrl, content))
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                        }
                    }
                }
                else
                {
                    string apiUrl = clsCommon.APIURL + string.Format("api/BookAPI");
                    using (var httpClient = new HttpClient())
                    {
                        var request = new HttpRequestMessage
                        {
                            RequestUri = new Uri(apiUrl),
                            Method = new HttpMethod("Patch"),
                            Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json")
                        };

                        var response = await httpClient.SendAsync(request);
                        using var stream = response.Content.ReadAsStreamAsync().Result;
                    }

                }

                if (list != null)
                    return RedirectToAction("Index");
                else
                    return RedirectToAction("Error", new { RequestId = 404 });

            }
            catch (Exception ex)
            {
                return RedirectToAction("Error" + ex.Message.ToString(), new { RequestId = 404 });
            }

        }
        public IActionResult Cancel(int? id)
        {
            return RedirectToAction("Index");
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