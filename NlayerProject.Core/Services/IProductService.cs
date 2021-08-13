using NlayerProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NlayerProject.Core.Services
{
    public interface IProductService:IService<Product>
    {
        Task<Product> GetWithCategoryByIdAsync(int productId);
        //Veritabanıyla ilgili olmayan işlemlerde tanımlanabilir burda.
        // örn:  bool controlInnerBarcode(int id);
    }
}
