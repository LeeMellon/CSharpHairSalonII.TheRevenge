using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System;

namespace HairSalon.Controllers
{
    public class StylistController : Controller
    {
      //MAIN INDEX PAGE
      [HttpGet("/stylist")]
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
        List<Client> stylistClients = Client.GetClientsByStylist(id);
        List<Specialty> stylistSpecialties = thisStylist.GetSpecialtiesByStylist();
        Dictionary<string, object> StylistClientDict = new Dictionary <string, object>();
        StylistClientDict.Add("stylist", thisStylist);
        StylistClientDict.Add("stylistClients", stylistClients);
        StylistClientDict.Add("specialty", stylistSpecialties);
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

      //STYLIST UPDATE FORM
      [HttpGet("/stylist/{id}/update")]
      public ActionResult UpdateForm(int id)
      {
        Stylist thisStylist = Stylist.Find(id);
        List<Specialty> allSpecialties = Specialty.GetAllSpecialties();
        Dictionary<string, object> stylistSpecialtyDict = new Dictionary<string, object>();
        stylistSpecialtyDict.Add("specialty", allSpecialties);
        stylistSpecialtyDict.Add("stylist", thisStylist);
        return View(stylistSpecialtyDict);
      }

      //SAVES STYLIST UPDATE INFO TO DB. REDIRECTS TO INDEX
      [HttpPost("/stylist/{id}/update")]
      public ActionResult Update(int id)
      {
        Stylist thisStylist = Stylist.Find(id);
        thisStylist.EditStylist(Request.Form["name"],
        Convert.ToInt32(Request.Form["chair"]));
        thisStylist.AddSpecialty(Convert.ToInt32(Request.Form["specialty_id"]));
        return RedirectToAction("index", "stylist");
      }

      [HttpGet("/stylist/{id}/specialty/{specId}/delete")]
      public ActionResult RemoveSpecialty(int id, int specId)
      {
        Stylist thisStylist = Stylist.Find(id);
        int thisId = thisStylist.GetId();
        thisStylist.RemoveSpecialty(specId);
        return RedirectToAction("StylistDetails", "stylist",  new { id = thisId});
      }



    }
}
