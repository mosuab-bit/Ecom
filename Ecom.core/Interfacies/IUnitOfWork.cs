using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.core.Interfacies
{
    public interface IUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; }
        public IProductRepository ProductRepository { get; }
        public IPhotoRepository PhotoRepository { get; }  
    }
}
