using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Tests
{

  [TestClass]
  public class StylistTests : IDisposable
  {
    public void Dispose()
    {
      Stylist.DeleteAllStylists();
    }

    public StylistTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=ian_goodrich_test;";
    }

    [TestMethod]
    public void GetsAndSets_AllGettersAndSetters_Values()
    {
      //arrange
      Stylist newStylist = new Stylist("Kimberly", 3, 1);
      //action
      string stylistName = newStylist.GetStylistName();
      int stylistChair = newStylist.GetStylistChair();
      int stylistId = newStylist.GetId();
      //assert
      Assert.AreEqual(stylistName, "Kimberly");
      Assert.AreEqual(stylistChair, 3);
      Assert.AreEqual(stylistId, 1);

    }
    [TestMethod]
    public void GetAllStylists_ReturnStylistList_List()
    {
      //arrange
      List<Stylist> stylistList = new List<Stylist>{};
      Stylist newStylist1 = new Stylist("Kimberly", 3);
      Stylist newStylist2 = new Stylist("Berly", 2);
      stylistList.Add(newStylist1);
      stylistList.Add(newStylist2);
      //action
      newStylist1.Save();
      newStylist2.Save();
      List<Stylist> testList = Stylist.GetAllStylists();
      System.Console.WriteLine(stylistList[1].GetId());
      System.Console.WriteLine(testList[1].GetId());

      //assert
      CollectionAssert.AreEqual(testList, stylistList);
  }

  [TestMethod]
  public void DeleteStylist_ReturnStylistListCount_Int()
  {
    //arrange
    Stylist newStylist1 = new Stylist("Kimberly", 3);
    Stylist newStylist2 = new Stylist("Berly", 2);
    newStylist1.Save();
    newStylist2.Save();
    List<Stylist> stylistList = Stylist.GetAllStylists();
    int stylistListCount = stylistList.Count;
    //action
    int deleteId = stylistList[1].GetId();
    Stylist.DeleteStylist(deleteId);
    List<Stylist> testList = Stylist.GetAllStylists();
    int testListCount = testList.Count;

    //assert
    Assert.AreEqual(testListCount, 1);
    Assert.AreEqual(stylistListCount, 2);
  }

  [TestMethod]
  public void EditStylist_ReturnNewStylistNameAndChair_Values()
  {
    //arrange
    Stylist newStylist1 = new Stylist("Kimberly", 3);
    Stylist newStylist2 = new Stylist("Berly", 2);
    newStylist1.Save();
    //action
    newStylist1.EditStylist("Kim", 1);
    string newName = newStylist1.GetStylistName();
    int newChair = newStylist1.GetStylistChair();

    //assert
    Assert.AreEqual(newName, "Kim");
    Assert.AreEqual(newChair, 1);
  }
  [TestMethod]
  public void FindStylist_ReturnStylistName_String()
  {
    //arrange
    Stylist newStylist1 = new Stylist("Kimberly", 3);
    Stylist newStylist2 = new Stylist("Berly", 2);
    Stylist newStylist3 = new Stylist("Joe", 1);
    newStylist1.Save();
    newStylist2.Save();
    newStylist3.Save();
    //action
    int stylistId = newStylist2.GetId();
    Stylist testStylist = Stylist.Find(stylistId);
    string testStylistName = testStylist.GetStylistName();

    //assert
    Assert.AreEqual("Berly", testStylistName);
  }

  [TestMethod]
  public void DeleteAllStylist_ReturnEmptyList_List()
  {
    //arrange
    Stylist newStylist1 = new Stylist("Kimberly", 3);
    Stylist newStylist2 = new Stylist("Berly", 2);
    Stylist newStylist3 = new Stylist("Joe", 1);
    newStylist1.Save();
    newStylist2.Save();
    newStylist3.Save();
    //action
    Stylist.DeleteAllStylists();
    List<Stylist> stylistList = Stylist.GetAllStylists();
    int stylistListCount = stylistList.Count;

    //assert
    Assert.AreEqual(stylistListCount, 0);
  }
  [TestMethod]
  public void GetClientsByStylistId_ReturnList_List()
  {
    //arrange
    Stylist newStylist2 = new Stylist("Berly", 2);
    newStylist2.Save();
    int stylistId = newStylist2.GetId();
    int otherId = stylistId + 1;
    Client newClient1 = new Client("Franz", "Franzia", 5031112222, "franz@franzia.org", stylistId);
    Client newClient2 = new Client("Hanz", "Hanzia", 5411112222, "franz@franzia.org", otherId);
    Client newClient3 = new Client("Branz", "Branzia", 5101112222, "franz@franzia.org", stylistId);
    newClient1.Save();
    newClient2.Save();
    newClient3.Save();
    //action
    List<Client> clientList = Client.GetClientsByStylistId(stylistId);
    int clientListCount = clientList.Count;

    //assert
    Assert.AreEqual(clientListCount, 2);
  }

 }
}
