using NlayerProject.Core.Models;
using NlayerProject.Core.Repositories;
using NlayerProject.Core.Services;
using NlayerProject.Core.UnitOfWorks;
using System.Threading.Tasks;

namespace NlayerProject.Service.Serivces
{
    public class ProductService : Service<Product>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, IRepository<Product> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            return await _unitOfWork.Products.GetWithCategoryByIdAsync(productId);
        }
    }
}
