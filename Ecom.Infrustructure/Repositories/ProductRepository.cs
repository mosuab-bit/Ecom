using AutoMapper;
using Ecom.core.DTO;
using Ecom.core.Entities.Product;
using Ecom.core.Interfacies;
using Ecom.core.Services;
using Ecom.Infrustructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.Infrustructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>,IProductRepository
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        private readonly IImageManagementService imageManagementService;
        public ProductRepository(AppDbContext context, IMapper mapper, IImageManagementService imageManagementService) : base(context)
        {
            this.context = context;
            this.mapper = mapper;
            this.imageManagementService = imageManagementService;
        }

        public async Task<bool> AddAsync(AddProductDto productDto)
        {
            if (productDto == null) return false;
            var product = mapper.Map<Product>(productDto);
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            var  ImagePath = await imageManagementService.AddImageAsync(productDto.Photo, productDto.Name);
            var photo = ImagePath.Select(m=>new Photo
            {
                ImageName = m,
                ProductId = product.Id
            }).ToList();
            await context.Photos.AddRangeAsync(photo);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(UpdateProductDto updateProductDto)
        {
           if(updateProductDto is null)
                return false;
           var FindProduct = await context.Products.Include(m => m.Category)
                .Include(m => m.Photos)
                .FirstOrDefaultAsync(m => m.Id == updateProductDto.Id);
            if(FindProduct is null)
                return false;
            mapper.Map(updateProductDto, FindProduct);

            if (updateProductDto.Photo is not null && updateProductDto.Photo.Count > 0)
            {
                var FindPhoto = await context.Photos.Where(m => m.ProductId == updateProductDto.Id).ToListAsync();
                foreach (var item in FindPhoto)
                {
                   imageManagementService.DeleteImageAsync(item.ImageName);
                }

                context.Photos.RemoveRange(FindPhoto);
                var ImagePath = await imageManagementService.AddImageAsync(updateProductDto.Photo, updateProductDto.Name);
                var photo = ImagePath.Select(m => new Photo
                {
                    ImageName = m,
                    ProductId = updateProductDto.Id
                }).ToList();

                await context.Photos.AddRangeAsync(photo);
            }

            await context.SaveChangesAsync();
            return true;
        }
    }
}
