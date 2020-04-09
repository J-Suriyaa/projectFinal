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
    public class Food_ItemController : Controller
    {
        string connectionString = @"server=(LocalDB)\MSSQLLocalDB;Initial Catalog=Db_Restaurant;Integrated Security=True";
        [HttpGet]
        public ActionResult Index()
        {
            DataTable dtblFood = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("SELECT * FROM [dbo].[dbo.Food_item]", sqlCon);
                sqlData.Fill(dtblFood);

            }
            return View(dtblFood);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View(new Food_ItemModel());
        }

        [HttpPost]
        public ActionResult Create(Food_ItemModel fooditemModel)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "INSERT INTO [dbo].[dbo.Food_item] values (@Item_name,@Item_price)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@Item_name", fooditemModel.item_name);
                sqlCmd.Parameters.AddWithValue("@Item_price", fooditemModel.item_price);
                sqlCmd.ExecuteNonQuery();

            }
            return RedirectToAction("Index");
        }

        // GET: Food_Item/Edit/5
        public ActionResult Edit(int id)
        {
            Food_ItemModel fooditemModel = new Food_ItemModel();
            DataTable dtblFood = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "SELECT * FROM [dbo].[dbo.Food_item] WHERE item_id = @ItemId";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query,sqlCon);
                sqlDa.SelectCommand.Parameters.AddWithValue("@ItemId",id);
                sqlDa.Fill(dtblFood);
            }
            if (dtblFood.Rows.Count == 1)
            {
                fooditemModel.item_id = Convert.ToInt32(dtblFood.Rows[0][0].ToString());
                fooditemModel.item_name = dtblFood.Rows[0][1].ToString();
                fooditemModel.item_price = Convert.ToDecimal(dtblFood.Rows[0][2].ToString());
                return View(fooditemModel);
            }
            else 
                return RedirectToAction("Index");
        }

        // POST: Food_Item/Edit/5
        [HttpPost]
        public ActionResult Edit(Food_ItemModel food_ItemModel)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "UPDATE [dbo].[dbo.Food_item] SET item_name = @ItemName, item_price = @ItemPrice WHERE item_id = @ItemId";
                SqlCommand sqlcmd = new SqlCommand(query, sqlCon);
                sqlcmd.Parameters.AddWithValue("@ItemId", food_ItemModel.item_id);
                sqlcmd.Parameters.AddWithValue("@ItemName", food_ItemModel.item_name);
                sqlcmd.Parameters.AddWithValue("@ItemPrice", food_ItemModel.item_price);
                sqlcmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        // GET: Food_Item/Delete/5
        public ActionResult Delete(int id)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "DELETE FROM [dbo].[dbo.Food_item] WHERE item_id = @ItemId ";
                SqlCommand sqlcmd = new SqlCommand(query, sqlCon);
                sqlcmd.Parameters.AddWithValue("@ItemId",id);
                sqlcmd.ExecuteNonQuery();
            }

            return RedirectToAction("Index");
        }

    }
}