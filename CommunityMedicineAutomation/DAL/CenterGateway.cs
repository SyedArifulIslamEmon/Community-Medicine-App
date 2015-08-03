﻿using CommunityMedicineAutomation.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;



namespace CommunityMedicineAutomation.DAL
{
    public class CenterGateway
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["connectionDB"].ConnectionString;

        public List<Center> GetAllDistrict()
        {
            List<Center> districtList=new List<Center>();

             string query = "SELECT * FROM DistrictTBL";
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Center center=new Center();
                center.Id=int.Parse(reader["Id"].ToString());
                center.DistrictName = reader["DistrictName"].ToString();

                districtList.Add(center);

            }
            reader.Close();
            connection.Close();
            return districtList;


        }

        public List<Center> GetAllThana(int id)
        {
            List<Center> thanaList = new List<Center>();

            string query = "SELECT * FROM ThanaTBL WHERE DistrictId='"+id+"'";
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Center center = new Center();
                center.Id = int.Parse(reader["Id"].ToString());
                center.ThanaName = reader["ThanaName"].ToString();

                thanaList.Add(center);

            }
            reader.Close();
            connection.Close();
            return thanaList;


        }

      
        public List<Center> CenterCountInThana(int id) {
            int count = 0;
            List<Center> centerList=new List<Center>();
            string query = "SELECT * FROM CenterTBL WHERE ThanaId='" + id + "'";
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Center aCenter=new Center();
                aCenter.Id =int.Parse( reader["Id"].ToString());
                aCenter.CenterName = reader["CenterName"].ToString();
                count++;
                aCenter.Count = count;
                centerList.Add(aCenter);

            }
            reader.Close();
            connection.Close();
            return centerList;
        }
        public int SaveCenter(Center aCenter, int thanaId, string centerCode, string password) {


            string query = "INSERT INTO CenterTBL VALUES('" + aCenter.CenterName + "','" + thanaId + "','" + centerCode + "','" + password + "')";
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
        public int centerId;
        public bool IsCenterCodeAndPasswordExists(string centerCode, string password)
        {
            centerId = 0;
            bool test = false;
            string query = "SELECT * FROM CenterTBL WHERE CenterCode='" + centerCode + "' AND Password='"+password+"'";
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                centerId=int.Parse(reader["Id"].ToString());
                test = true;
              
            }
            reader.Close();
            connection.Close();
            return test;
        }

        public bool IsCenterNameExists(Center aCenter) {
            bool exists = false;
            string query = "SELECT * FROM CenterTBL WHERE CenterName='" + aCenter.CenterName + "'";
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
               
                exists = true;

            }
            reader.Close();
            connection.Close();
            return exists;
        }
        public string GetCenterName(int centerId) {
            string centerName = "";
            string query = "SELECT * FROM CenterTBL WHERE Id='" + centerId + "'";
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                centerName = reader["CenterName"].ToString();

            }
            reader.Close();
            connection.Close();
            return centerName;
        }
    }
}