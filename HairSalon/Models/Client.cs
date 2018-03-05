using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using HairSalon;


namespace HairSalon.Models
{
    public class Client
    {
      private int _id;
      private string _nameFirst;
      private string _nameLast;
      private long _number;
      private string _email;

      public Client (string firstName, string lastName, long number, string email, int id = 0)
      {
        _id = id;
        _nameFirst = firstName;
        _nameLast = lastName;
        _number = number;
        _email = email;
      }

      public override bool Equals(System.Object otherClient)
      {
        if (!(otherClient is Client))
        {
          return false;
        }
        else
        {
          Client newClient = (Client) otherClient;
          bool idEquality = (this.GetId() == newClient.GetId());
          bool firstNameEquality = (this.GetFirstName() == newClient.GetFirstName());
          bool lastNameEquality = (this.GetLastName() == newClient.GetLastName());
          bool numberEquality = (this.GetNumber() == newClient.GetNumber());
          bool emailEquality = (this.GetEmail() == newClient.GetEmail());
          return (idEquality && firstNameEquality && lastNameEquality && numberEquality && emailEquality);
        }
      }

      public override int GetHashCode()
      {
        return this.GetId().GetHashCode();
      }

      public void SetFirstName(string firstName)
      {
        _nameFirst = firstName;
      }

      public string GetFirstName()
      {
        return _nameFirst;
      }

      public void SetLastName(string lastName)
      {
        _nameLast = lastName;
      }

      public string GetLastName()
      {
        return _nameLast;
      }

      public void SetNumber(long number)
      {
        _number = number;
      }

      public long GetNumber()
      {
        return _number;
      }

      public void SetEmail(string email)
      {
        _email = email;
      }

      public string GetEmail()
      {
        return _email;
      }

      public void SetId(int id)
      {
        _id = id;
      }

      public int GetId()
      {
        return _id;
      }

      //DELETS ALL CLIENTS
      public static void DeleteAllClients()
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"DELETE FROM clients; DELETE FROM clients_stylists;";
        cmd.ExecuteNonQuery();
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
      }

      //DELETE ALL CLIENTS BY STYLIST
      public static void DeleteAllClientsByStylist(int id)
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"DELETE FROM clients_stylists WHERE stylist_id = @searchId;
        DELETE clients.* FROM clients_stylists JOIN stylists ON (clients_stylists.stylist_id = stylists.id) JOIN clients ON (clients.id = clients_stylists.client_id) WHERE stylists.id = @searchId;";

        MySqlParameter thisId = new MySqlParameter();
        thisId.ParameterName = "@searchId";
        thisId.Value = id;
        cmd.Parameters.Add(thisId);

        cmd.ExecuteNonQuery();
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
      }

      //GETS ALL CLIENTS
      public static List<Client> GetAllClients()
      {
        List<Client> allClients = new List<Client>{};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM clients;";
        var rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          int clientId = rdr.GetInt32(0);
          string clientFirstName = rdr.GetString(1);
          string clientLastName = rdr.GetString(2);
          long clientNumber = rdr.GetInt64(3);
          string clientEmail = rdr.GetString(4);
          Client newClient = new Client(clientFirstName, clientLastName, clientNumber, clientEmail, clientId);
          allClients.Add(newClient);
        }
        conn.Close();
        if (conn != null)
        {
          conn.Dispose();
        }
        return allClients;
      }

      //RETURNS STYLIST ID FROM JOIN TABLE
      public int GetStylistId()
      {
        Console.WriteLine("GetStylistId Client Id " + this._id);
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT stylist_id FROM clients_stylists WHERE clients_stylists.client_id = @searchId;";

        MySqlParameter thisId = new MySqlParameter();
        thisId.ParameterName = "@searchId";
        thisId.Value =this._id;
        cmd.Parameters.Add(thisId);

        var rdr = cmd.ExecuteReader() as MySqlDataReader;

        int stylistId = 0;

        while(rdr.Read())
        {
         stylistId = rdr.GetInt32(0);
        }

        int theId = stylistId;
        conn.Close();
        if (conn != null)
        {
          conn.Dispose();
        }
        return theId;
      }


      //SAVE CLIENT
      public void Save()
        {
          MySqlConnection conn = DB.Connection();
          conn.Open();

          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"INSERT INTO clients (first_name, last_name, number, email) VALUES (@firstName, @lastName, @number, @email);";

          MySqlParameter firstName = new MySqlParameter();
          firstName.ParameterName = "@firstName";
          firstName.Value = this._nameFirst;
          cmd.Parameters.Add(firstName);

          MySqlParameter lastName = new MySqlParameter();
          lastName.ParameterName = "@lastName";
          lastName.Value = this._nameLast;
          cmd.Parameters.Add(lastName);

          MySqlParameter number = new MySqlParameter();
          number.ParameterName = "@number";
          number.Value = this._number;
          cmd.Parameters.Add(number);

          MySqlParameter email = new MySqlParameter();
          email.ParameterName = "@email";
          email.Value = this._email;
          cmd.Parameters.Add(email);

           cmd.ExecuteNonQuery();

           _id = (int) cmd.LastInsertedId;
          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }

        }

        //DELETE CLIENT
        public void DeleteClient()
        {
         MySqlConnection conn = DB.Connection();
         conn.Open();

         var cmd = conn.CreateCommand() as MySqlCommand;
         cmd.CommandText = @"DELETE FROM clients WHERE id = @searchId;
         DELETE FROM clients_stylists WHERE client_id = @searchId;";

         MySqlParameter thisId = new MySqlParameter();
         thisId.ParameterName = "@searchId";
         thisId.Value = this._id;
         cmd.Parameters.Add(thisId);
         var rdr = cmd.ExecuteReader() as MySqlDataReader;


         conn.Close();
         if (conn != null)
         {
           conn.Dispose();
         }
        }

        //FIND CLIENT BY ID
        public static Client Find(int id)
        {
          MySqlConnection conn = DB.Connection();
          conn.Open();
          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"SELECT * FROM clients WHERE id = @searchId;";

          MySqlParameter searchId = new MySqlParameter();
          searchId.ParameterName = "@searchId";
          searchId.Value = id;
          cmd.Parameters.Add(searchId);

          var rdr = cmd.ExecuteReader() as MySqlDataReader;

          int clientId = 0;
          string clientFirstName = "";
          string clientLastName = "";
          long clientNumber = 0;
          string clientEmail = "";

          while(rdr.Read())
          {
            clientId = rdr.GetInt32(0);
            clientFirstName = rdr.GetString(1);
            clientLastName = rdr.GetString(2);
            clientNumber = rdr.GetInt64(3);
            clientEmail = rdr.GetString(4);
          }
          Client newClient = new Client(clientFirstName, clientLastName, clientNumber, clientEmail, clientId);
          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }
          return newClient;
        }

        //EDITS CLIENT DETAILS
        public void EditClient(string newFirstName, string newLastName, long newNumber, string newEmail, int styId)
        {
         MySqlConnection conn = DB.Connection();
         conn.Open();
         var cmd = conn.CreateCommand() as MySqlCommand;
         cmd.CommandText = @"UPDATE clients SET first_name = @firstname, last_name = @lastname, number = @number, email = @email WHERE id = @searchId;
         UPDATE clients_stylists SET stylist_id = @stylistId";

         MySqlParameter searchId = new MySqlParameter();
         searchId.ParameterName = "@searchId";
         searchId.Value = _id;
         cmd.Parameters.Add(searchId);

         MySqlParameter firstName = new MySqlParameter();
         firstName.ParameterName = "@firstName";
         firstName.Value = newFirstName;
         cmd.Parameters.Add(firstName);

         MySqlParameter lastName = new MySqlParameter();
         lastName.ParameterName = "@lastName";
         lastName.Value = newLastName;
         cmd.Parameters.Add(lastName);

         MySqlParameter number = new MySqlParameter();
         number.ParameterName = "@number";
         number.Value = newNumber;
         cmd.Parameters.Add(number);

         MySqlParameter email = new MySqlParameter();
         email.ParameterName = "@email";
         email.Value = newEmail;
         cmd.Parameters.Add(email);

         MySqlParameter stylistId = new MySqlParameter();
         stylistId.ParameterName = "@stylistId";
         stylistId.Value = styId;
         cmd.Parameters.Add(stylistId);

         cmd.ExecuteNonQuery();
         _nameFirst = newFirstName;
         _nameLast = newLastName;
         _number = newNumber;
         _email = newEmail;

         conn.Close();
         if (conn != null)
         {
             conn.Dispose();
         }
       }

       //RETURNS LIST OF CLIENTS BY STYLIST ID
       public static List<Client> GetClientsByStylist(int id)
       {
         List<Client> clientsByStylist = new List<Client>{};
         MySqlConnection conn = DB.Connection();
         conn.Open();
         var cmd = conn.CreateCommand() as MySqlCommand;
         cmd.CommandText = @"SELECT clients.* FROM clients_stylists JOIN stylists ON (clients_stylists.stylist_id = stylists.id) JOIN clients ON (clients.id = clients_stylists.client_id) WHERE stylists.id = @searchId;";

         MySqlParameter searchId = new MySqlParameter();
         searchId.ParameterName = "@searchId";
         searchId.Value = id;
         cmd.Parameters.Add(searchId);
         var rdr = cmd.ExecuteReader() as MySqlDataReader;

         while(rdr.Read())
         {
           int clientId = rdr.GetInt32(0);
           string clientFirstName = rdr.GetString(1);
           string clientLastName = rdr.GetString(2);
           long clientNumber = rdr.GetInt64(3);
           string clientEmail = rdr.GetString(4);
           Client newClient = new Client(clientFirstName, clientLastName, clientNumber, clientEmail, clientId);
           clientsByStylist.Add(newClient);
         }
         conn.Close();
         if (conn != null)
         {
             conn.Dispose();
         }
         return clientsByStylist;
         }

       public void AddStylist(int styId)
       {
         MySqlConnection conn = DB.Connection();
         conn.Open();

         var cmd = conn.CreateCommand() as MySqlCommand;
         cmd.CommandText = @"INSERT INTO clients_stylists (client_id, stylist_id) VALUES (@clientId, @stylistId);";

         MySqlParameter clientId = new MySqlParameter();
         clientId.ParameterName = "@clientId";
         clientId.Value = this._id;
         cmd.Parameters.Add(clientId);


         MySqlParameter stylistId = new MySqlParameter();
         stylistId.ParameterName = "@stylistId";
         stylistId.Value = styId;
         cmd.Parameters.Add(stylistId);

         cmd.ExecuteNonQuery();

        // _id = (int) cmd.LastInsertedId;

         conn.Close();
         if (conn != null)
         {
             conn.Dispose();
         }

       }

    }

}
