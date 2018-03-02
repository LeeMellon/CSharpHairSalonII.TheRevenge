using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
// using System.Linq;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientTest : IDisposable
  {
    public ClientTest()
    {

      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=ian_goodrich_test;";
    }

    public void Dispose()
    {
      Client.DeleteAllClients();
      Stylist.DeleteAllStylists();
    }


    [TestMethod]
    public void GetsAndSets_AllGettersAndSetters_Values()
    {
      //arrange
      Client newClient = new Client("Franz", "Franzia", 5031112222, "franz@franzia.org",1);
      //action
      string clientFirstName = newClient.GetFirstName();
      string clientLastName = newClient.GetLastName();
      long clientNumber = newClient.GetNumber();
      string clientEmail = newClient.GetEmail();
      int clientId = newClient.GetId();
      //assert
      Assert.AreEqual(clientFirstName, "Franz");
      Assert.AreEqual(clientLastName, "Franzia");
      Assert.AreEqual(clientNumber, 5031112222);
      Assert.AreEqual(clientEmail, "franz@franzia.org");
      Assert.AreEqual(clientId, 1);
    }

    [TestMethod]
    public void GetAllClients_ReturnClientList_List()
    {
      //arrange
      List<Client> clientList = new List<Client>{};
      Client newClient1 = new Client("Franz", "Franzia", 5031112222, "franz@franzia.org");
      Client newClient2 = new Client("Hanz", "Hanzia", 5032223333, "hanz@hanzia.org");
      clientList.Add(newClient1);
      clientList.Add(newClient2);
      //action
      newClient1.Save();
      newClient2.Save();
      List<Client> testList = Client.GetAllClients();
      //assert
      CollectionAssert.AreEqual(testList, clientList);
    }

    [TestMethod]
    public void DeleteClient_ReturnClientListCount_Int()
    {
      //arrange
      Client newClient1 = new Client("Franz", "Franzia", 5031112222, "franz@franzia.org");
      Client newClient2 = new Client("Hanz", "Hanzia", 5032223333, "hanz@hanzia.org");
      newClient1.Save();
      newClient2.Save();
      List<Client> clientList = Client.GetAllClients();
      int clientListCount = clientList.Count;
      //action
      int deleteId = clientList[1].GetId();
      Client thisClient = Client.Find(deleteId);
      thisClient.DeleteClient();
      List<Client> testList = Client.GetAllClients();
      int testListCount = testList.Count;

      //assert
      Assert.AreEqual(testListCount, 1);
      Assert.AreEqual(clientListCount, 2);
    }

    [TestMethod]
    public void EditClients_ReturnNewClientNameAndNumber_Values()
    {
      //arrange
      Client newClient1 = new Client("Franz", "Franzia", 5031112222, "franz@franzia.org");
      newClient1.Save();
      //action
      newClient1.EditClient("Hanz", "Franzia", 5034445555, "franz@franzia.org");
      List<Client> clientsList = Client.GetAllClients();
      string newName = clientsList[0].GetFirstName();
      long newNumber = clientsList[0].GetNumber();

      //assert
      Assert.AreEqual(newName, "Hanz");
      Assert.AreEqual(newNumber, 5034445555);
    }

    [TestMethod]
    public void FindClients_ReturnClientName_String()
    {
      //arrange
      Client newClient1 = new Client("Franz", "Franzia", 5031112222, "franz@franzia.org");
      Client newClient2 = new Client("Hanz", "Hanzia", 5411112222, "franz@franzia.org");
      Client newClient3 = new Client("Branz", "Branzia", 5101112222, "franz@franzia.org");
      newClient1.Save();
      newClient2.Save();
      newClient3.Save();
      List<Client> clientsList = Client.GetAllClients();

      //action
      int clientId = clientsList[1].GetId();
      Client testClient = Client.Find(clientId);
      string testClientName = testClient.GetFirstName();

      //assert
      Assert.AreEqual("Hanz", testClientName);
    }

    [TestMethod]
    public void DeleteAllClients_ReturnEmptyList_List()
    {
      //arrange
      Client newClient1 = new Client("Franz", "Franzia", 5031112222, "franz@franzia.org");
      Client newClient2 = new Client("Hanz", "Hanzia", 5411112222, "franz@franzia.org");
      Client newClient3 = new Client("Branz", "Branzia", 5101112222, "franz@franzia.org");
      newClient1.Save();
      newClient2.Save();
      newClient3.Save();
      //action
      Client.DeleteAllClients();
      List<Client> clientList = Client.GetAllClients();
      int clientListCount = clientList.Count;

      //assert
      Assert.AreEqual(clientListCount, 0);
    }
  }
}
