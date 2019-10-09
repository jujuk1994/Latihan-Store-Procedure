using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using LatihanStoreProc.Models;

namespace LatihanStoreProc.Database_Access_Layer
{
    public class Database
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString); 

        public void AddRecord(Employee employee)
        {
            SqlCommand com = new SqlCommand("Sp_Add_Employee", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Name", employee.Name);
            com.Parameters.AddWithValue("@Adrress", employee.Address);
            com.Parameters.AddWithValue("@City", employee.City);
            com.Parameters.AddWithValue("@Pin_Code", employee.Pin_Code);
            com.Parameters.AddWithValue("@Designation", employee.Designation);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        public void Update(Employee employee)
        {
            SqlCommand com = new SqlCommand("Sp_Update_Employee", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", employee.Id);
            com.Parameters.AddWithValue("@Name", employee.Name);
            com.Parameters.AddWithValue("@Adrress", employee.Address);
            com.Parameters.AddWithValue("@City", employee.City);
            com.Parameters.AddWithValue("@Pin_Code", employee.Pin_Code);
            com.Parameters.AddWithValue("@Designation", employee.Designation);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        public DataSet ShowData(int id)
        {
            SqlCommand com = new SqlCommand("Sp_Select_Employee", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id",id);
            SqlDataAdapter data = new SqlDataAdapter(com);
            DataSet dataSet = new DataSet();
            data.Fill(dataSet);
            return dataSet;
        }

         public DataSet ShowAllData()
        {
            SqlCommand com = new SqlCommand("Sp_SelectAll_Employee", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter data = new SqlDataAdapter(com);
            DataSet dataSet = new DataSet();
            data.Fill(dataSet);
            return dataSet;
        }
      

        public void delete(int id)
        {
            SqlCommand com = new SqlCommand("Sp_Delete_Employee", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", id);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
    }
}