using Blog_Page.Dto;

namespace Blog_Page.ViewModel
{
    public class BlogWithImageViewModel
    {
        public BlogDto Blog { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
