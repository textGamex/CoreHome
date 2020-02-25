﻿using System.ComponentModel.DataAnnotations;

namespace CoreHome.Admin.ViewModels
{
    public class ArticleViewModel
    {
        [Required]
        [Display(Name = "标题")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "类别")]
        public string CategoryName { get; set; }

        [Required]
        [Display(Name = "标签")]
        public string ArticleTags { get; set; }

        [Required]
        [Display(Name = "概述")]
        public string Overview { get; set; }

        [Display(Name = "封面")]
        public string CoverUrl { get; set; }

        [Required]
        [Display(Name = "内容")]
        public string Content { get; set; }

    }
}
