using Blog_Page.Models;
using Blog_Page.Services.Interfaces;


namespace Blog_Page.AppServices.Services
{
    public class ImageService : IImageService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        
        public ImageService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<string> UploadFileAsync(IFormFile file)
        {
            
            var filePath= Path.Combine(_webHostEnvironment.ContentRootPath, "images", file.FileName);
            using var fileStream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fileStream);
            return filePath;
        }
    }
}
