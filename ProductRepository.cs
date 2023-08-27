using SimpleWebSite.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SimpleWebSite.Repository
{
    public class ProductRepository : IProducts
    {
        private static readonly string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DbProductEntities"].ConnectionString;
        protected SqlConnection con = new SqlConnection(ConnectionString);

        public void DeleteProduct(int Id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("ProductCurd", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@ActionType", "Delete");
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public Product GetProductFromId(int Id)
        {
            DataSet ds = null;
            Product cobj = null;
            try
            {
                SqlCommand cmd = new SqlCommand("ProductCurd", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@ActionType", "SelectById");
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    cobj = new Product();
                    cobj.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"].ToString());
                    cobj.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                    cobj.SKU = ds.Tables[0].Rows[i]["SKU"].ToString();
                    cobj.HSNNumber = ds.Tables[0].Rows[i]["HSNNumber"].ToString();
                    cobj.BrandName = ds.Tables[0].Rows[i]["BrandName"].ToString();
                    cobj.UOM = ds.Tables[0].Rows[i]["UOM"].ToString();
                    cobj.Weight = ds.Tables[0].Rows[i]["Weight"].ToString();
                    cobj.CGST = Convert.ToDecimal(ds.Tables[0].Rows[i]["CGST"].ToString());
                    cobj.SGST = Convert.ToDecimal(ds.Tables[0].Rows[i]["SGST"].ToString());
                    cobj.IGST = Convert.ToDecimal(ds.Tables[0].Rows[i]["IGST"].ToString());
                    cobj.MRP = Convert.ToDecimal(ds.Tables[0].Rows[i]["MRP"].ToString());
                    cobj.BuyingPrice = Convert.ToDecimal(ds.Tables[0].Rows[i]["BuyingPrice"].ToString());
                    cobj.SellingPrice = Convert.ToDecimal(ds.Tables[0].Rows[i]["SellingPrice"].ToString());
                    cobj.Quantity = Convert.ToInt32(ds.Tables[0].Rows[i]["Quantity"].ToString());
                    cobj.Image = ds.Tables[0].Rows[i]["Image"].ToString();
                    cobj.DateAdded = Convert.ToDateTime(ds.Tables[0].Rows[i]["DateAdded"].ToString());
                }
                return cobj;
            }
            catch
            {
                return cobj;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Product> GetProducts()
        {
            DataSet ds = null;
            List<Product> custlist = null;
            try
            {
                SqlCommand cmd = new SqlCommand("ProductCurd", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionType", "Select");
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                ds = new DataSet();
                da.Fill(ds);
                custlist = new List<Product>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Product cobj = new Product();
                    cobj.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["Id"].ToString());
                    cobj.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                    cobj.SKU = ds.Tables[0].Rows[i]["SKU"].ToString();
                    cobj.HSNNumber = ds.Tables[0].Rows[i]["HSNNumber"].ToString();
                    cobj.BrandName = ds.Tables[0].Rows[i]["BrandName"].ToString();
                    cobj.UOM = ds.Tables[0].Rows[i]["UOM"].ToString();
                    cobj.Weight = ds.Tables[0].Rows[i]["Weight"].ToString();
                    cobj.CGST = Convert.ToDecimal(ds.Tables[0].Rows[i]["CGST"].ToString());
                    cobj.SGST = Convert.ToDecimal(ds.Tables[0].Rows[i]["SGST"].ToString());
                    cobj.IGST = Convert.ToDecimal(ds.Tables[0].Rows[i]["IGST"].ToString());
                    cobj.MRP = Convert.ToDecimal(ds.Tables[0].Rows[i]["MRP"].ToString());
                    cobj.BuyingPrice = Convert.ToDecimal(ds.Tables[0].Rows[i]["BuyingPrice"].ToString());
                    cobj.SellingPrice = Convert.ToDecimal(ds.Tables[0].Rows[i]["SellingPrice"].ToString());
                    cobj.Quantity = Convert.ToInt32(ds.Tables[0].Rows[i]["Quantity"].ToString());
                    cobj.Image = ds.Tables[0].Rows[i]["Image"].ToString();
                    cobj.DateAdded = Convert.ToDateTime(ds.Tables[0].Rows[i]["DateAdded"].ToString());

                    custlist.Add(cobj);
                }
                return custlist;
            }
            catch
            {
                return custlist;
            }
            finally
            {
                con.Close();
            }
        }

        public void InsertProduct(AddProductViewModel model)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("ProductCurd", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@HSNNumber", model.HSNNumber);
                cmd.Parameters.AddWithValue("@BrandName", model.BrandName);
                cmd.Parameters.AddWithValue("@UOM", model.UOM);
                cmd.Parameters.AddWithValue("@Weight", model.Weight);
                cmd.Parameters.AddWithValue("@CGST", model.CGST);
                cmd.Parameters.AddWithValue("@SGST", model.SGST);
                cmd.Parameters.AddWithValue("@IGST", model.IGST);
                cmd.Parameters.AddWithValue("@MRP", model.MRP);
                cmd.Parameters.AddWithValue("@BuyingPrice", model.BuyingPrice);
                cmd.Parameters.AddWithValue("@SellingPrice", model.SellingPrice);
                cmd.Parameters.AddWithValue("@Quantity", model.Quantity);
                cmd.Parameters.AddWithValue("@Image", model.Image);
                cmd.Parameters.AddWithValue("@ActionType", "Insert");
                con.Open();
                cmd.ExecuteScalar();
            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public void UpdateProduct(AddProductViewModel model)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("ProductCurd", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", model.Id);
                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@HSNNumber", model.HSNNumber);
                cmd.Parameters.AddWithValue("@BrandName", model.BrandName);
                cmd.Parameters.AddWithValue("@UOM", model.UOM);
                cmd.Parameters.AddWithValue("@Weight", model.Weight);
                cmd.Parameters.AddWithValue("@CGST", model.CGST);
                cmd.Parameters.AddWithValue("@SGST", model.SGST);
                cmd.Parameters.AddWithValue("@IGST", model.IGST);
                cmd.Parameters.AddWithValue("@MRP", model.MRP);
                cmd.Parameters.AddWithValue("@BuyingPrice", model.BuyingPrice);
                cmd.Parameters.AddWithValue("@SellingPrice", model.SellingPrice);
                cmd.Parameters.AddWithValue("@Quantity", model.Quantity);
                cmd.Parameters.AddWithValue("@Image", model.Image);
                cmd.Parameters.AddWithValue("@ActionType", "Update");
                con.Open();
                cmd.ExecuteScalar();
            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }

        }
    }
}