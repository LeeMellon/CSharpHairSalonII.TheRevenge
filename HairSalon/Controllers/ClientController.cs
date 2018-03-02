using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System;

namespace HairSalon.Controllers
{
    public class ClientController : Controller
    {
      //CLIENT CREATOR FORM
      [HttpGet("/client/{id}/new")]
      public ActionResult ClientCreator(int id)
      {
        Stylist thisStylist = Stylist.Find(id);
        return View(thisStylist);
      }

      //SAVES CLIENT TO DB REDIRECTS TO INDEX
      [HttpPost("/client/new")]
      public ActionResult Create()
      {
        int stylistId = Convert.ToInt32(Request.Form["stylist_id"]);
        string firstName = Request.Form["new-client-first"];
        string lastName = Request.Form["new-client-last"];
        long number = Convert.ToInt64(Request.Form["new-client-number"]);
        string email = Request.Form["new-client-email"];
        Client newClient = new Client (firstName, lastName, number, email, stylistId);
        newClient.Save();
        return RedirectToAction("Index","stylist");
      }

      //CLIENT UPDATE FORM
      [HttpGet("/client/{id}/update")]
      public ActionResult UpdateForm(int id)
      {
        Client thisClient = Client.Find(id);
        List<Stylist> allStylists = Stylist.GetAllStylists();
        Dictionary<string, object> clientStyistsDict = new Dictionary<string, object>();
        clientStyistsDict.Add("stylist", allStylists);
        clientStyistsDict.Add("client", thisClient);
        return View(clientStyistsDict);
      }

      //SAVES CLIENT UPDATE INFO TO DB. REDIRECTS TO INDEX
      [HttpPost("/client/{id}/update")]
      public ActionResult Update(int id)
      {
        Client thisClient = Client.Find(id);
        thisClient.EditClient(Request.Form["firstName"], Request.Form["lastName"], Convert.ToInt64(Request.Form["number"]), Request.Form["email"], Convert.ToInt32(Request.Form["stylist_id"]));
        return RedirectToAction("index", "stylist");
      }

      //DISPLAYS CLIENT DETAILS
      [HttpGet("/client/{id}/details")]
      public ActionResult Details(int id)
      {
        Client thisClient = Client.Find(id);
        int stylistId = thisClient.GetStylistId();
        Stylist thisStylist = Stylist.Find(stylistId);
        Dictionary<string, object> clientStyistsDict = new Dictionary<string, object>();
        clientStyistsDict.Add("stylist", thisStylist);
        clientStyistsDict.Add("client", thisClient);
        return View(clientStyistsDict);
      }

      //DELETES ALL CLIENTS OF A STYLIST
      [HttpPost("/client/{id}/delete_all")]
      public ActionResult DeleteAll(int id)
      {
        Client.DeleteAllClientsByStylist(id);
        return RedirectToAction("index", "stylist");
      }

      //DELETS ONE CLIENT FROM STYLIST DETAILS PAGE
      [HttpGet("/client/{id}/delete")]
      public ActionResult Delete(int id)
      {
        Client thisClient = Client.Find(id);
        int thisId = thisClient.GetStylistId();
        System.Console.WriteLine(thisId);
        thisClient.DeleteClient();
        return RedirectToAction("StylistDetails", "stylist", new {Id = thisId});
      }

    }
}
