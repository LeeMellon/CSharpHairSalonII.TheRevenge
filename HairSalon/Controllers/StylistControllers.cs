using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System;

namespace HairSalon.Controllers
{
    public class StylistController : Controller
    {
      //MAIN INDEX PAGE
      [HttpGet("/")]
      public ActionResult Index()
      {
        List<Stylist> allStylists = Stylist.GetAllStylists();
        return View(allStylists);
      }

      //OPENS STYLIST CREATOR PAGE
      [HttpGet("/stylist/new")]
      public ActionResult StylistCreator()
      {
        return View();
      }

      //SAVES CREATED STYLIST INFO TO DB. RETURNS TO INDEX
      [HttpPost("/stylist/create")]
      public ActionResult CreateStylist()
      {
        Stylist newStylist = new Stylist (Request.Form["new-stylist"], Convert.ToInt32(Request.Form["stylist-chair"]));
        newStylist.Save();
        List<Stylist> allStylist = Stylist.GetAllStylists();
        return RedirectToAction("Index", allStylist);
      }

      //SENDS TO CLIENT CREATOR FROM STYLIST DETAILS PAGE
      [HttpGet("/stylist/{id}/client/new")]
      public ActionResult StylistAddClient(int id)
      {
        Stylist thisStylist = Stylist.Find(id);
        return RedirectToAction("ClientCreator","client", thisStylist);
      }

      //STYLIST DETAILS PAGE
      [HttpGet("/stylist/{id}")]
      public ActionResult StylistDetails(int id)
      {
        Stylist thisStylist = Stylist.Find(id);
        List<Client> stylistClients = Client.GetClientsByStylistId(id);
        Dictionary<string, object> StylistClientDict = new Dictionary <string, object>();
        StylistClientDict.Add("stylistName", thisStylist);
        StylistClientDict.Add("stylistClients", stylistClients);
        return View(StylistClientDict);
      }

      //DELETES STYLIST
      [HttpGet("/stylist/{id}/delete_stylist")]
      public ActionResult StylistDelete(int id)
      {
        Client.DeleteAllClientsByStylist(id);
        Stylist.DeleteStylist(id);
        List<Stylist> allStylists = Stylist.GetAllStylists();
        return View ("Index", allStylists);
      }

    }
}
