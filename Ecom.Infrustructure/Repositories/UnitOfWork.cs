using Ecom.core.Interfacies;
using Ecom.Infrustructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.Infrustructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public ICategoryRepository CategoryRepository { get; }

        public IProductRepository ProductRepository {get;}

        public IPhotoRepository PhotoRepository {get;}

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            CategoryRepository = new CategoryRepository(_context);
            ProductRepository = new ProductRepository(_context);
            PhotoRepository = new PhotoRepository(_context);
        }

    }
}
