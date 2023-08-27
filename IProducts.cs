using SimpleWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebSite.Repository
{
    public interface IProducts
    {
        List<Product> GetProducts();

        void InsertProduct(AddProductViewModel model);

        Product GetProductFromId(int Id);

        void UpdateProduct(AddProductViewModel model);

        void DeleteProduct(int Id);
    }
}
