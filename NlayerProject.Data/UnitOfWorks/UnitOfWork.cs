using NlayerProject.Core.Repositories;
using NlayerProject.Core.UnitOfWorks;
using NlayerProject.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NlayerProject.Data.UnitOfWorks
{

    //Bu pattern'in özelligi: Coklu islem yapildiginda ve islem adimlarinin birinde hata oldugunda DB tarafindaki Rollback islemlerinin yapilmasina gerek duymamamizi
    //saglayan, yapilan degisiklikleri gecici hafizada tutan ve commit isleminden sonra hata olmazsa, verilen db ye kaydedilmesini saglar.

    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private ProductRepository _productRepository;
        private CategoryRepository _categoryRepository;

        public IProductRepository Products => _productRepository = _productRepository ?? new ProductRepository(_context);

        public ICategoryRepository categories => _categoryRepository = _categoryRepository ?? new CategoryRepository(_context);

        public UnitOfWork(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
