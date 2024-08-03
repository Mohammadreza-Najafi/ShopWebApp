﻿using _0_Framwork.Application;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BlogManagement.Application.Contracts.ArticleCategory
{
    public class CreateArticleCategory
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get;  set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public IFormFile Picture { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Description { get;  set; }
        public int ShowOrder { get;  set; }
        public string Slug { get; set; }
        public string Keywords { get;  set; }
        public string MetaDescription { get;  set; }
        public string CanonicalAddress { get;  set; }

    }

}
