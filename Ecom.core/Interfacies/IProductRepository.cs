using Ecom.core.DTO;
using Ecom.core.Entities.Product;
using Ecom.core.Sharing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.core.Interfacies
{
    public interface IProductRepository: IGenericRepository<Product>
    {
        Task<bool> AddAsync(AddProductDto productDto);
        Task<bool> UpdateAsync(UpdateProductDto updateProductDto);
        Task<IEnumerable<ProductDto>> GetAllAsync(ProductParams productParams);
    }
}
