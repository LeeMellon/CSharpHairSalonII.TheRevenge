using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System;

namespace HairSalon.Controllers
{
    public class SpecialtyController : Controller
    {


    //DISPLAYS ALL SPECIALTY
      [HttpGet("/specialty")]
      public ActionResult Index()
      {
        List<Specialty> allSpecialties = Specialty.GetAllSpecialties();
        return View(allSpecialties);
      }

    //DELETS ONE SPECIALTY FROM STYLIST DETAILS PAGE
      [HttpGet("/specialty/{id}/stylist/{styId}/delete")]
      public ActionResult Delete(int id, int styId)
      {
        Stylist thisStylist = Stylist.Find(styId);
        thisStylist.RemoveSpecialty(id);
        return RedirectToAction("StylistDetails", "stylist", new {Id = styId});
      }


    //CREATES SPECIALTY
      [HttpGet("/specialty/new")]
      public ActionResult SpecialtyCreator()
      {
        return View();
      }

    //SAVES CREATED SPECIALTY
      [HttpPost("/specialty/create")]
      public ActionResult Create()
      {
        Specialty newSpecialty = new Specialty (Request.Form["new-specialty"]);
        newSpecialty.Save();
        List<Specialty> allSpecialties = Specialty.GetAllSpecialties();
        return RedirectToAction("Index", allSpecialties);
      }

    }
  }
