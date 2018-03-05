using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System;

namespace HairSalon.Controllers
{
    public class SpecialtyController : Controller
    {


    //DELETS ONE SPECIALTY FROM STYLIST DETAILS PAGE
      [HttpGet("/specialty/{id}/stylist/{styId}/delete")]
      public ActionResult Delete(int id, int styId)
      {
        Stylist thisStylist = Stylist.Find(styId);
        thisStylist.RemoveSpecialty(id);
        return RedirectToAction("StylistDetails", "stylist", new {Id = styId});
      }

    }
  }
