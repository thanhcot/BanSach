﻿using Doan1.Ulitities;
using Microsoft.AspNetCore.Mvc;

namespace Doan1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/Admin/file-manager")]
    public class FileManagerController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }
    }
}
