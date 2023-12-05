using AutoMapper;
using Azure.Core;
using Blog_Page.Dto;
using Blog_Page.Models;
using Blog_Page.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;

namespace Blog_Page.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BlogController : Controller
    {


        public IActionResult List()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(BlogDto blog, IFormFile file)
        {
            return RedirectToAction("List", "Blog", new { area = "Admin" });
        }

        public async Task<List<Image>> UploadImage(IFormFile file)
        {
            return RedirectToAction("List", "Blog", new { area = "Admin" });
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(BlogDto blogDto)
        {
         
            return RedirectToAction("List", "Blog", new { area = "Admin" });
        }

        public IActionResult Delete(int id)
        {
            return RedirectToAction("List", "Blog", new { area = "Admin" });
        }
    }
}
