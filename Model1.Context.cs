﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SimpleWebSite.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DbProductEntities : DbContext
    {
        public DbProductEntities()
            : base("name=DbProductEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Product> Products { get; set; }
    
        public virtual ObjectResult<ProductCurd_Result> ProductCurd(Nullable<int> id, string name, string hSNNumber, string brandName, string uOM, string weight, Nullable<decimal> cGST, Nullable<decimal> sGST, Nullable<decimal> iGST, Nullable<decimal> mRP, Nullable<decimal> buyingPrice, Nullable<decimal> sellingPrice, Nullable<int> quantity, string image, string actionType)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var hSNNumberParameter = hSNNumber != null ?
                new ObjectParameter("HSNNumber", hSNNumber) :
                new ObjectParameter("HSNNumber", typeof(string));
    
            var brandNameParameter = brandName != null ?
                new ObjectParameter("BrandName", brandName) :
                new ObjectParameter("BrandName", typeof(string));
    
            var uOMParameter = uOM != null ?
                new ObjectParameter("UOM", uOM) :
                new ObjectParameter("UOM", typeof(string));
    
            var weightParameter = weight != null ?
                new ObjectParameter("Weight", weight) :
                new ObjectParameter("Weight", typeof(string));
    
            var cGSTParameter = cGST.HasValue ?
                new ObjectParameter("CGST", cGST) :
                new ObjectParameter("CGST", typeof(decimal));
    
            var sGSTParameter = sGST.HasValue ?
                new ObjectParameter("SGST", sGST) :
                new ObjectParameter("SGST", typeof(decimal));
    
            var iGSTParameter = iGST.HasValue ?
                new ObjectParameter("IGST", iGST) :
                new ObjectParameter("IGST", typeof(decimal));
    
            var mRPParameter = mRP.HasValue ?
                new ObjectParameter("MRP", mRP) :
                new ObjectParameter("MRP", typeof(decimal));
    
            var buyingPriceParameter = buyingPrice.HasValue ?
                new ObjectParameter("BuyingPrice", buyingPrice) :
                new ObjectParameter("BuyingPrice", typeof(decimal));
    
            var sellingPriceParameter = sellingPrice.HasValue ?
                new ObjectParameter("SellingPrice", sellingPrice) :
                new ObjectParameter("SellingPrice", typeof(decimal));
    
            var quantityParameter = quantity.HasValue ?
                new ObjectParameter("Quantity", quantity) :
                new ObjectParameter("Quantity", typeof(int));
    
            var imageParameter = image != null ?
                new ObjectParameter("Image", image) :
                new ObjectParameter("Image", typeof(string));
    
            var actionTypeParameter = actionType != null ?
                new ObjectParameter("ActionType", actionType) :
                new ObjectParameter("ActionType", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ProductCurd_Result>("ProductCurd", idParameter, nameParameter, hSNNumberParameter, brandNameParameter, uOMParameter, weightParameter, cGSTParameter, sGSTParameter, iGSTParameter, mRPParameter, buyingPriceParameter, sellingPriceParameter, quantityParameter, imageParameter, actionTypeParameter);
        }
    }
}
