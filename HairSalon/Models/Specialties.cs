using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using HairSalon;


namespace HairSalon.Models
{
    public class Specialty
    {
      private int _id;
      private string _name;

      public Specialty (string name, int id = 0)
      {
        _id = id;
        _name = name;

      }

      public override bool Equals(System.Object otherSpecialty)
      {
        if (!(otherSpecialty is Specialty))
        {
          return false;
        }
        else
        {
          Specialty newSpecialty = (Specialty) otherSpecialty;
          bool idEquality = (this.GetId() == newSpecialty.GetId());
          bool nameEquality = (this.GetName() == newSpecialty.GetName());
          return (idEquality && nameEquality);
        }
      }

      public override int GetHashCode()
      {
        return this.GetId().GetHashCode();
      }

      public void SetName(string name)
      {
        _name = name;
      }

      public string GetName()
      {
        return _name;
      }

      public void SetId(int id)
      {
        _id = id;
      }

      public int GetId()
      {
        return _id;
      }

      //DELETS ALL SPECIALTIES
      public static void DeleteAllSpecialties()
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"DELETE FROM specialties; DELETE FROM specialties_stylists;";
        cmd.ExecuteNonQuery();
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
      }

      //DELETE ALL SPECIALTIES BY STYLIST
      public static void DeleteAllSpecialtiesByStylist(int id)
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"DELETE FROM specialties_stylists WHERE stylist_id = @searchId;
        DELETE specialties.* FROM specialties_stylists JOIN stylists ON (specialties_stylists.stylist_id = stylists.id) JOIN specialties ON (specialties.id = specialties_stylists.specialty_id) WHERE stylists.id = @searchId;";

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

      //GETS ALL SPECIALTIES
      public static List<Specialty> GetAllSpecialties()
      {
        List<Specialty> allSpecialties = new List<Specialty>{};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        var cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM specialties;";
        var rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          int specialtyId = rdr.GetInt32(0);
          string specialtyName = rdr.GetString(1);

          Specialty newSpecialty = new Specialty(specialtyName, specialtyId);
          allSpecialties.Add(newSpecialty);
        }
        conn.Close();
        if (conn != null)
        {
          conn.Dispose();
        }
        return allSpecialties;
      }

      //SAVE SPECIALTY
      public void Save()
        {
          MySqlConnection conn = DB.Connection();
          conn.Open();

          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"INSERT INTO specialties (name) VALUES (@name);";

          MySqlParameter name = new MySqlParameter();
          name.ParameterName = "@name";
          name.Value = this._name;
          cmd.Parameters.Add(name);

          cmd.ExecuteNonQuery();

           _id = (int) cmd.LastInsertedId;
          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }

        }

        //DELETE SPECIALTY
        public void DeleteSpecialty()
        {
         MySqlConnection conn = DB.Connection();
         conn.Open();

         var cmd = conn.CreateCommand() as MySqlCommand;
         cmd.CommandText = @"DELETE FROM specialties WHERE id = @searchId;
         DELETE FROM specialties_stylists WHERE specialty_id = @searchId;";

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

        //FIND SPECIALTY BY ID
        public static Specialty Find(int id)
        {
          MySqlConnection conn = DB.Connection();
          conn.Open();
          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"SELECT * FROM specialties WHERE id = @searchId;";

          MySqlParameter searchId = new MySqlParameter();
          searchId.ParameterName = "@searchId";
          searchId.Value = id;
          cmd.Parameters.Add(searchId);

          var rdr = cmd.ExecuteReader() as MySqlDataReader;

          int specialtyId = 0;
          string specialtyName = "";

          while(rdr.Read())
          {
            specialtyId = rdr.GetInt32(0);
            specialtyName = rdr.GetString(1);

          }
          Specialty newSpecialty = new Specialty(specialtyName, specialtyId);
          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }
          return newSpecialty;
        }

        //EDITS SPECIALTY DETAILS
        public void EditSpeciality(string newName)
        {
         MySqlConnection conn = DB.Connection();
         conn.Open();
         var cmd = conn.CreateCommand() as MySqlCommand;
         cmd.CommandText = @"UPDATE specialties SET name = @name WHERE id = @searchId;";

         MySqlParameter searchId = new MySqlParameter();
         searchId.ParameterName = "@searchId";
         searchId.Value = this._id;
         cmd.Parameters.Add(searchId);

         MySqlParameter name = new MySqlParameter();
         name.ParameterName = "@ame";
         name.Value = newName;
         cmd.Parameters.Add(name);

         cmd.ExecuteNonQuery();
         _name = newName;

         conn.Close();
         if (conn != null)
         {
             conn.Dispose();
         }
       }


       public void AddStylist(int styId)
       {
         MySqlConnection conn = DB.Connection();
         conn.Open();

         var cmd = conn.CreateCommand() as MySqlCommand;
         cmd.CommandText = @"INSERT INTO specialties_stylists (specialty_id, stylist_id) VALUES (@specialty, @stylistId);";

         MySqlParameter specialtyId = new MySqlParameter();
         specialtyId.ParameterName = "@specialtyId";
         specialtyId.Value = this._id;
         cmd.Parameters.Add(specialtyId);

         MySqlParameter stylistId = new MySqlParameter();
         stylistId.ParameterName = "@stylistId";
         stylistId.Value = styId;
         cmd.Parameters.Add(stylistId);

         cmd.ExecuteNonQuery();

        _id = (int) cmd.LastInsertedId;

         conn.Close();
         if (conn != null)
         {
             conn.Dispose();
         }

       }

    }

}
