﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Encodings.Web;

namespace DESKfurniture.Controllers
{
    public class DeskCompany : Controller
    {
        // 
        // GET: /DeskCompany/
        public IActionResult Index()
        {
            return View();
        }

        // GET: /DeskCompany/Welcome/ 
        // Requires using System.Text.Encodings.Web;
        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }
    }
}
