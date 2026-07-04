using Ecom.core.Entities.Product;
using Ecom.core.Interfacies;
using Ecom.Infrustructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.Infrustructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>,IProductRepository
    {
        public ProductRepository(AppDbContext context): base(context)
        {

        }
    }
}
