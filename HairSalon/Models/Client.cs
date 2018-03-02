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
      private int _stylistId;

      public Client (string firstName, string lastName, long number, string email, int stylistId, int id = 0)
      {
        _id = id;
        _nameFirst = firstName;
        _nameLast = lastName;
        _number = number;
        _email = email;
        _stylistId = stylistId;
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
          bool stylistIdEquality = (this.GetStylistId() == newClient.GetStylistId());
          return (idEquality && firstNameEquality && lastNameEquality && numberEquality && emailEquality && stylistIdEquality);
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

      public void SetStylistId(int stylistId)
      {
        _stylistId = stylistId;
      }

      public int GetStylistId()
      {
        return _stylistId;
      }

      public void SetId(int id)
      {
        _id = id;
      }

      public int GetId()
      {
        return _id;
      }


      public static void DeleteAllClients()
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"DELETE FROM clients;";
        cmd.ExecuteNonQuery();
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
      }

      //DELETE ALL CLIENTS BY STYLIST ID
      public static void DeleteAllClientsByStylist(int id)
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"DELETE FROM clients WHERE stylist_id = @searchId;";

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
          int clientStylistId = rdr.GetInt32(5);
          Client newClient = new Client(clientFirstName, clientLastName, clientNumber, clientEmail, clientStylistId, clientId);
          allClients.Add(newClient);
        }
        conn.Close();
        if (conn != null)
        {
          conn.Dispose();
        }
        return allClients;
      }

      //SAVE CLIENT
      public void Save()
        {
          MySqlConnection conn = DB.Connection();
          conn.Open();

          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"INSERT INTO clients (first_name, last_name, number, email, stylist_id) VALUES (@firstName, @lastName, @number, @email, @stylistId);";

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

          MySqlParameter stylistId = new MySqlParameter();
          stylistId.ParameterName = "@stylistId";
          stylistId.Value = this._stylistId;
          cmd.Parameters.Add(stylistId);

           cmd.ExecuteNonQuery();

           _id = (int) cmd.LastInsertedId;
           System.Console.WriteLine("Here" + _id);
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
         cmd.CommandText = @"DELETE FROM clients WHERE id = @id;";

         MySqlParameter thisId = new MySqlParameter();
         thisId.ParameterName = "@id";
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
          int clientStylistId = 0;

          while(rdr.Read())
          {
            clientId = rdr.GetInt32(0);
            clientFirstName = rdr.GetString(1);
            clientLastName = rdr.GetString(2);
            clientNumber = rdr.GetInt64(3);
            clientEmail = rdr.GetString(4);
            clientStylistId = rdr.GetInt32(5);
          }
          Client newClient = new Client(clientFirstName, clientLastName, clientNumber, clientEmail, clientStylistId, clientId);
          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }
          return newClient;
        }

        //EDITS CLIENT DETAILS
        public void EditClient(string newFirstName, string newLastName, long newNumber, string newEmail, int newStylistId)
        {
         MySqlConnection conn = DB.Connection();
         conn.Open();
         var cmd = conn.CreateCommand() as MySqlCommand;
         cmd.CommandText = @"UPDATE clients SET first_name = @firstname, last_name = @lastname, number = @number, email = @email, stylist_id = @stylistId  WHERE id = @searchId;";

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
         stylistId.Value = newStylistId;
         cmd.Parameters.Add(stylistId);


         cmd.ExecuteNonQuery();
         _nameFirst = newFirstName;
         _nameLast = newLastName;
         _number = newNumber;
         _email = newEmail;
         _stylistId = newStylistId;

         conn.Close();
         if (conn != null)
         {
             conn.Dispose();
         }
       }

       //RETURNS LIST OF CLIENTS BY STYLIST ID
       public static List<Client> GetClientsByStylistId(int id)
       {
         List<Client> clientsByStylist = new List<Client>{};
         MySqlConnection conn = DB.Connection();
         conn.Open();
         var cmd = conn.CreateCommand() as MySqlCommand;
         cmd.CommandText = @"SELECT * FROM clients WHERE stylist_id = @searchId;";

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
           int clientStylistId = rdr.GetInt32(5);
           Client newClient = new Client(clientFirstName, clientLastName, clientNumber, clientEmail, clientStylistId, clientId);
           clientsByStylist.Add(newClient);
         }
         conn.Close();
         if (conn != null)
         {
             conn.Dispose();
         }
         return clientsByStylist;
         }

    }

}
