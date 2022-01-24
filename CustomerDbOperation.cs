
using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System.Data;
using DataAccessLayer;

namespace DataAccessLayer
{
   public class CustomerDbOperation
    {
        public DbConnect dbConnect;

        public CustomerDbOperation()
        {
            dbConnect = new DbConnect();
        }

        public List<Customer> GetCustomers()
        {
            SqlCommand command = new SqlCommand("Sp_Customer", dbConnect.connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@action", "SELECT");
            if (dbConnect.connection.State == ConnectionState.Closed)
                dbConnect.connection.Open();
            SqlDataReader dr = command.ExecuteReader();
            List<Customer> customers
                = new List<Customer>();
            while (dr.Read())
            {
                Customer obj = new Customer();
                obj.Id = (int)dr["id"];
                obj.FirstName = dr["firstname"].ToString();
                obj.LastName = dr["lastname"].ToString();
                obj.Email = dr["email"].ToString();
                obj.Mobile = dr["mobile"].ToString();
                obj.Address = dr["address"].ToString();
                customers.Add(obj);





            }
            dbConnect.connection.Close();

        }
    }
}

