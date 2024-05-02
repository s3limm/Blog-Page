using AutoMapper;
using Azure.Core;
using Blog_Page.Domain.Entities;
using Blog_Page.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting.Internal;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Blog_Page.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BlogController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public BlogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> List()
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "accesToken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var response = await client.GetAsync("http://localhost:5158/api/Blog/List");

                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<List<BlogListModel>>(jsonData, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });

                    return View(result);
                }
            }

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Insert()
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "accesToken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var response = await client.GetAsync($"http://localhost:5158/api/Category/list");

                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();

                    var categories = JsonSerializer.Deserialize<List<CategoryListModel>>(jsonData, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });

                    var model = new CreateBlogModel
                    {
                        Categories = categories.Select(c => new SelectListItem { Value = c.ID.ToString(), Text = c.CategoryName }).ToList()
                    };

                    TempData["Categories"] = JsonConvert.SerializeObject(categories);

                    return View(model);
                }
            }
            return RedirectToAction("List", "Blog", new { area = "Admin" });
        }



        [HttpPost]
        public async Task<IActionResult> Insert(CreateBlogModel model)
        {
            if (ModelState.IsValid)
            {
                var data = TempData["Categories"]?.ToString();
                if (data != null)
                {
                    var categories = JsonSerializer.Deserialize<List<SelectListItem>>(data);
                    model.Categories = categories.Select(item => new SelectListItem { Text = item.Text, Value = item.Value }).ToList();
                }

                // model.Categories null değilse, SelectList veya MultiSelectList oluşturun
                var multiSelectList = model.Categories != null
                    ? new MultiSelectList(model.Categories, "Value", "Text")
                    : new MultiSelectList(Enumerable.Empty<SelectListItem>(), "Value", "Text");

                var token = User.Claims.FirstOrDefault(x => x.Type == "accesToken")?.Value;
                if (token != null)
                {
                    var client = _httpClientFactory.CreateClient();
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                    var jsonData = JsonSerializer.Serialize(model);
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync($"http://localhost:5158/api/Blog/create", content);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("List", "Blog", new { area = "Admin" });
                    }
                    ModelState.AddModelError("", "Bir hata oluştu");
                }
            }

            return View(model);
        }




        [HttpGet]

        public async Task<IActionResult> Edit(int id)
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "accesToken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var responseProduct = await client.GetAsync($"http://localhost:5158/api/Blog/Get/{id}");

                if (responseProduct.IsSuccessStatusCode)
                {
                    var jsonData = await responseProduct.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<UpdateBlogModel>(jsonData, new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    });



                    var responseCategory = await client.GetAsync($"http://localhost:5158/api/Category/list");

                    if (responseCategory.IsSuccessStatusCode)
                    {
                        var jsonCategoryData = await responseCategory.Content.ReadAsStringAsync();

                        var data = JsonSerializer.Deserialize<List<CategoryListModel>>(jsonCategoryData, new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                        });

                       if (result != null)
                        {
                            var categoriesList = data.Select(item => new SelectListItem
                            {
                                Value = item.ID.ToString(),
                                Text = item.CategoryName,
                                Selected = item.ID == result.CategoryID
                            }).ToList();

                            result.Categories = categoriesList;
                        }

                    }
                    return View(result);
                }
            }
            return RedirectToAction("List", "Blog", new { area = "Admin" });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateBlogModel model)
        {
            var data = TempData["Categories"]?.ToString();
            if (data != null)
            {
                var categories = JsonSerializer.Deserialize<List<SelectListItem>>(data);
                model.Categories = categories;
            }


            if (ModelState.IsValid)
            {

                var token = User.Claims.FirstOrDefault(x => x.Type == "accesToken")?.Value;
                if (token != null)
                {
                    var client = _httpClientFactory.CreateClient();
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                    var jsonData = JsonSerializer.Serialize(model);
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    var response = await client.PutAsync($"http://localhost:5158/api/Blog/update", content);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("List", "Blog", new { area = "Admin" });
                    }
                    ModelState.AddModelError("", "Bir hata oluştu");
                }

            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "accesToken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                await client.DeleteAsync($"http://localhost:5158/api/Blog/delete/{id}");
            }
            return RedirectToAction("List", "Blog", new { area = "Admin" });
        }
    }
}
