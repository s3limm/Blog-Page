using AutoMapper;
using Azure.Core;
using Blog_Page.Domain.Entities;
using Blog_Page.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
        public readonly IWebHostEnvironment _webHostEnvironment;


        public BlogController(IHttpClientFactory httpClientFactory, IWebHostEnvironment webHostEnvironment)
        {
            _httpClientFactory = httpClientFactory;
            _webHostEnvironment = webHostEnvironment;
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

                var token = User.Claims.FirstOrDefault(x => x.Type == "accesToken")?.Value;
                if (token != null)
                {
                    var client = _httpClientFactory.CreateClient();
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                    var formData = new MultipartFormDataContent();
                    formData.Add(new StringContent(model.Title), "Title");
                    formData.Add(new StringContent(model.Description), "Description");
                    formData.Add(new StringContent(model.Content), "Content");
                    formData.Add(new StringContent(model.CategoryID.ToString()), "CategoryID");

                    foreach (var file in model.FileData)
                    {
                        formData.Add(new StreamContent(file.OpenReadStream()), "FileData", file.FileName);
                    }

                    var response = await client.PostAsync($"http://localhost:5158/api/Blog/create", formData);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("List", "Blog", new { area = "Admin" });
                    }
                    else
                    {
                        ModelState.AddModelError("", "API ile iletişim sırasında bir hata oluştu.");
                    }
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
                    var result = JsonSerializer.Deserialize<UpdateBlogPostModel>(jsonData, new JsonSerializerOptions
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
        public async Task<IActionResult> Edit(UpdateBlogPostModel model)
        {
            if (ModelState.IsValid)
            {
                var data = TempData["Categories"]?.ToString();
                if (data != null)
                {
                    var categories = JsonSerializer.Deserialize<List<SelectListItem>>(data);
                    model.Categories = categories.Select(item => new SelectListItem { Text = item.Text, Value = item.Value }).ToList();
                }

                var token = User.Claims.FirstOrDefault(x => x.Type == "accesToken")?.Value;
                if (token != null)
                {
                    var client = _httpClientFactory.CreateClient();
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                    var formData = new MultipartFormDataContent();
                    formData.Add(new StringContent(model.Title), "Title");
                    formData.Add(new StringContent(model.Description), "Description");
                    formData.Add(new StringContent(model.Content), "Content");
                    formData.Add(new StringContent(model.CategoryID.ToString()), "CategoryID");
                    formData.Add(new StringContent(model.ID.ToString()), "ID");
                   
                    //var property1Value = model.Property1;
                    //var property2Value = model.Property2;

                    foreach (var file in model.FileData)
                    {
                        formData.Add(new StreamContent(file.OpenReadStream()), "FileData", file.FileName);
                    }

                    var response = await client.PutAsync($"http://localhost:5158/api/Blog/update", formData);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("List", "Blog", new { area = "Admin" });
                    }
                    else
                    {
                        ModelState.AddModelError("", "API ile iletişim sırasında bir hata oluştu.");
                    }
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
