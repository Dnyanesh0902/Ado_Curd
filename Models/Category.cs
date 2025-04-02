using MachineTest.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MachineTest.Models
{
	public class Category
	{
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public List<Category> GetCategories()
        {
            DBHelper db = new DBHelper();
            var CategoryList = new List<Category>();
            SqlCommand cmd = new SqlCommand("GetCategory", db.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                CategoryList.Add(
                    new Category
                    {
                        CategoryId = Convert.ToInt32(dr["CategoryId"]),
                        CategoryName = Convert.ToString(dr["CategoryName"]),
                    });
            }
            return CategoryList;
        }

        public void AddCategory( Category obj)
        {
            DBHelper db = new DBHelper();
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AddCategory", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("CategoryName", obj.CategoryName);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void EditCategory(Category obj )
        {
            DBHelper db = new DBHelper();
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UpdateCategory", conn);
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("CategoryId", obj.CategoryId);
                cmd.Parameters.AddWithValue("CategoryName", obj.CategoryName);
                cmd.ExecuteNonQuery();
                conn.Close();
            }

        }
        public void DeleteCategory(int id)
        {
            DBHelper db = new DBHelper();
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DeleteCategory", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("CategoryId", id);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}