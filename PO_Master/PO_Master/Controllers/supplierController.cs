using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Linq;
using System.Text.Json;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace PO_Master.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class supplierController : Controller
    {
        [HttpPost]
        public IActionResult SaveDetails(SupplierModel sup)
        {
            string connstr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ABClimited;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                SqlCommand sqlcommand = new SqlCommand();
                sqlcommand.CommandType = CommandType.StoredProcedure;
                sqlcommand.Connection = connection;
                sqlcommand.CommandText = "PO_SPItemDetails";
                var jsonStr = JsonSerializer.Serialize(sup.ItemDetails);
                sqlcommand.Parameters.AddWithValue("@POID", sup.POID);

                if (sup.POID == 0)
                {
                    sqlcommand.Parameters.AddWithValue("@Date", sup.Date);
                    sqlcommand.Parameters.AddWithValue("@SupplierID", sup.SupplierID);

                }

                sqlcommand.Parameters.AddWithValue("@PO_ItemDetails", jsonStr);
                sqlcommand.Connection.Open();
                sqlcommand.ExecuteNonQuery();

            }

            return Ok();
        }
        private List<object> GetListbyDataTable(DataTable dT)

        {
            var result = (from row in dT.AsEnumerable()
                          select new SupplierDetails
                          {
                              SupplierID = Convert.ToInt32(row["SupplierID"]),
                              SupplierName = Convert.ToString(row["SupplierName"]),
                              PhoneNumber = Convert.ToString(row["PhoneNumber"]),
                              Address = Convert.ToString(row["Address"])
                          }).ToList();
            return result.ConvertAll<object>(obj => (object)obj);
        }

        [HttpGet]
        [Route("GetPO_SPSupplier")]
        public IActionResult GetPO_SPSupplier()
        {

            string connStr = @"Data source=(localdb)\MSSQLLocalDB;Initial catalog=ABClimited;Integrated security=True";
            DataTable dT = new DataTable();
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                SqlCommand SqlCommand = new SqlCommand();
                SqlCommand.CommandType = CommandType.StoredProcedure;
                SqlCommand.Connection = connection;
                SqlCommand.CommandText = "GetSupplierDetails";
                SqlCommand.Connection.Open();
                SqlCommand.ExecuteNonQuery();
                SqlDataAdapter sda = new SqlDataAdapter(SqlCommand);

                sda.Fill(dT);
                var supplier = GetListbyDataTable(dT);

                return Ok(supplier);


            }
        }
        [HttpPost]
        [Route("[controller]")]

        public IActionResult SaveSupplier(SupplierDetails SD)
        {
            string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ABClimited;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                SqlCommand SqlCommand = new SqlCommand();
                SqlCommand.CommandType = CommandType.StoredProcedure;
                SqlCommand.Connection = connection;
                SqlCommand.CommandText = "PO_SPSupplier";
                SqlCommand.Parameters.AddWithValue("@SupplierID", SD.SupplierID);
                SqlCommand.Parameters.AddWithValue("@SupplierName", SD.SupplierName);
                SqlCommand.Parameters.AddWithValue("@PhoneNumber", SD.PhoneNumber);
                SqlCommand.Parameters.AddWithValue("@Address", SD.Address);
                SqlCommand.Connection.Open();
                SqlCommand.ExecuteNonQuery();
            }
            return Ok();

        }


        [HttpPost]
        [Route("SaveUserDetails")]
        public IActionResult saveOperation1(LoginPage LP)
        {

            string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ABClimited;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                SqlCommand SqlCommand = new SqlCommand();
                SqlCommand.CommandType = CommandType.StoredProcedure;
                SqlCommand.Connection = connection;
                SqlCommand.CommandText = "PO_Login";
                SqlCommand.Parameters.AddWithValue("@UserName", LP.UserName);
                SqlCommand.Parameters.AddWithValue("@Email", LP.Email);
                SqlCommand.Parameters.AddWithValue("@Password", LP.Password);
                SqlCommand.Connection.Open();
                SqlCommand.ExecuteNonQuery();
            }
            return Ok();
        }


        private List<object> GetListByData(DataTable dt)
        {

            var reult = (from rw in dt.AsEnumerable()
                         select new
                         {

                             UserName = Convert.ToString(rw["UserName"]),
                             Email = Convert.ToString(rw["Email"]),
                             Password = Convert.ToString(rw["Password"])
                         }).ToList();

            return reult.ConvertAll<object>(o => (object)o);
        }

        [HttpGet]
        [Route("GetLoginDetails")]
        public IActionResult GetLoginDetails()
        {

            string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ABClimited;Integrated Security=True;";
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                SqlCommand SqlCommand = new SqlCommand();
                SqlCommand.CommandType = CommandType.StoredProcedure;
                SqlCommand.Connection = connection;
                SqlCommand.CommandText = "GetLoginDetails";
                SqlCommand.Connection.Open();
                SqlCommand.ExecuteNonQuery();
                SqlDataAdapter sqa = new SqlDataAdapter(SqlCommand);

                sqa.Fill(dt);
                var supplier = GetListByData(dt); // Get the data from db  
                return Ok(supplier);

            }
        }

        [HttpGet]
        [Route("GetCustomerDetails")]
        public IActionResult GetCustomerDetails()
        {

            string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ABClimited;Integrated Security=True;";
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                SqlCommand SqlCommand = new SqlCommand();
                SqlCommand.CommandType = CommandType.StoredProcedure;
                SqlCommand.Connection = connection;
                SqlCommand.CommandText = "GetDetailstable";
                SqlCommand.Connection.Open();
                SqlCommand.ExecuteNonQuery();
                SqlDataAdapter sqa = new SqlDataAdapter(SqlCommand);
                sqa.Fill(dt);
                string jsonstring = JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented);
                return Ok(jsonstring);

                
                
            }
        }
        [HttpDelete]
        [Route("api/DeleteSubCategory")]
        public IActionResult DeleteSubCategory(SupplierModel SM)
        {
            string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ABClimited;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.CommandText = "PO_SPItemDetails";
                cmd.Connection.Open();
                cmd.Parameters.AddWithValue("@POID", SM.POID);
                cmd.ExecuteNonQuery();
            }
            return Ok();
        }
    }
}


