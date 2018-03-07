using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System;

namespace HairSalon.Controllers
{
    public class HomeController : Controller
    {


    //DISPLAYS ALL SPECIALTY
      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }


    }
  }
