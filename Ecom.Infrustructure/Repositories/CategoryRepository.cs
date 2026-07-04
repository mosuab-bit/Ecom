using Ecom.core.Entities.Product;
using Ecom.core.Interfacies;
using Ecom.Infrustructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.Infrustructure.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context) { }
    }
}
