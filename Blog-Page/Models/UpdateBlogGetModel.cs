﻿using Blog_Page.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Blog_Page.Models
{
    public class UpdateBlogGetModel:BaseModel
    {
        public int? ID { get; set; }

        [Required(ErrorMessage = "Blog adı boş geçilemez")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Blog açıklaması boş geçilemez")]
        public string Description { get; set; }

        [Required(ErrorMessage = "İçerik boş geçilemez")]
        public string Content { get; set; }
        public string FileNames { get; set; }

        //Relational Properties

        [Required(ErrorMessage = "Kategori boş geçilemez")]

        public int CategoryID { get; set; }

        //Relational Properties
        public Category? Category { get; set; }
        public List<SelectListItem>? Categories { get; set; }
    }
}
