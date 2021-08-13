using NlayerProject.Core.Models;
using NlayerProject.Core.Repositories;
using NlayerProject.Core.Services;
using NlayerProject.Core.UnitOfWorks;
using System;
using System.Threading.Tasks;

namespace NlayerProject.Service.Serivces
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IRepository<Category> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Category> GetWithProductsByIdAsync(int categoryId)
        {
           return await  _unitOfWork.categories.GetWithProductsByIdAsync(categoryId);
        }
    }
}
