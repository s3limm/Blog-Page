using AutoMapper;
using Blog_Page.Domain.Entities;
using Blog_Page.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text.Json;


namespace Blog_Page.Controllers
{
    public class BlogDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {

            var client = _httpClientFactory.CreateClient();

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
                            Selected = item.ID == result.CategoryID,
                        }).ToList();

                        for (int i = 0; i < categoriesList.Count; i++)
                        {
                            if (result.CategoryID.ToString() == categoriesList[i].Value)
                            {
                                result.Category = new Category
                                {
                                    ID = Convert.ToInt32(categoriesList[i].Value),
                                    CategoryName = categoriesList[i].Text
                                };
                            }
                        }

                    }

                    var files = new List<IFormFile>();

                    foreach (var fileName in result.FileNames.Split(','))
                    {
                        var filePath = Path.Combine("C:\\Users\\YAVUZ\\Desktop\\GitHub\\Blog-Page\\Blog-Page\\wwwroot\\Uploads\\" + fileName.Trim());

                        using (var fileStream = new FileStream(filePath, FileMode.Open))
                        {
                            var memoryStream = new MemoryStream();
                            fileStream.CopyTo(memoryStream);
                            memoryStream.Position = 0;

                            var formFile = new FormFile(memoryStream, 0, memoryStream.Length, null, Path.GetFileName(filePath));
                            files.Add(formFile);
                        }
                    }

                    // Modeli güncelle
                    result.FileData = files;

                }
                return View(result);
            }
            return View();
        }
    }
}

