using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class RolesController : Controller
    {
        string connectionString = @"server=(LocalDB)\MSSQLLocalDB;Initial Catalog=Db_Restaurant;Integrated Security=True";
        [HttpGet]
        public ActionResult Index()
        {
            DataTable dtblRole = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM [dbo].[Role]", sqlCon);
                sqlData.Fill(dtblRole);

            }
            return View(dtblRole);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View(new RolesModel());
        }

        [HttpPost]
        public ActionResult Create(RolesModel rolesModel)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "INSERT INTO [dbo].[Role] values (@role_name,@role_price)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@role_name", rolesModel.role_name);
                sqlCmd.Parameters.AddWithValue("@role_password", rolesModel.role_password);
                sqlCmd.ExecuteNonQuery();

            }
            return RedirectToAction("Index");
        }



        // POST: Roles/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "DELETE FROM [dbo].[Role] WHERE role_id = @roleId ";
                SqlCommand sqlcmd = new SqlCommand(query, sqlCon);
                sqlcmd.Parameters.AddWithValue("@roleId", id);
                sqlcmd.ExecuteNonQuery();
            }

            return RedirectToAction("Index");
        }
    }
    
}