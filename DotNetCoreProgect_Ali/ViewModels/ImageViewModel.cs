﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreProgect_Ali.ViewModels
{
    public class ImageViewModel
    {
        [Required]
        [Display(Name = "Image")]
        public IFormFile Image { get; set; }
    }
}
