using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication8.Controllers
{
    public class Cutomer_InfoController : Controller
    {
        string connectionString = @"server=(LocalDB)\MSSQLLocalDB;Initial Catalog=Db_Restaurant;Integrated Security=True";
        [HttpGet]
        public ActionResult Index()
        {
            DataTable dtblCustomer = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM [dbo].[Customer_info]", sqlCon);
                sqlData.Fill(dtblCustomer);

            }
            return View(dtblCustomer);
        }

        // GET: Cutomer_Info/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cutomer_Info/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cutomer_Info/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Cutomer_Info/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cutomer_Info/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Cutomer_Info/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cutomer_Info/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}