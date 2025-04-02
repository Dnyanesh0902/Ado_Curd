using MachineTest.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MachineTest.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public List<Product> GetProducts(int pageNumber, int pageSize)
        {
            DBHelper db = new DBHelper();
            var ProductList = new List<Product>();
            SqlCommand cmd = new SqlCommand("GetProductWithPagination", db.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PageNumber", pageNumber);
            cmd.Parameters.AddWithValue("@PageSize", pageSize);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                ProductList.Add(new Product
                {
                    ProductId = Convert.ToInt32(dr["ProductId"]),
                    ProductName = Convert.ToString(dr["ProductName"]),
                    CategoryId = Convert.ToInt32(dr["CategoryId"]),
                    CategoryName = Convert.ToString(dr["CategoryName"]),
                });
            }
            return ProductList;
        }

        public void AddProduct(Product obj)
        {
            DBHelper db = new DBHelper();
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("AddProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ProductName", obj.ProductName);
                cmd.Parameters.AddWithValue("CategoryId", obj.CategoryId);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        public void UpdateProduct(Product obj)
        {
            DBHelper db = new DBHelper();
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UpdateProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ProductId", obj.ProductId);
                cmd.Parameters.AddWithValue("ProductName", obj.ProductName);
                cmd.Parameters.AddWithValue("CategoryId", obj.CategoryId);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
        public void DeleteProduct(int id)
        {
            DBHelper db = new DBHelper();
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DeleteProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ProductId", id);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}