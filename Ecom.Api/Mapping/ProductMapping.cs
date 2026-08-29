using AutoMapper;
using Ecom.core.DTO;
using Ecom.core.Entities.Product;

namespace Ecom.Api.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Product,ProductDto>().ForMember(x=>x.CategoryName,op=>op.MapFrom(src=>src.Category.Name)).ReverseMap();
            CreateMap<Photo, PhotoDto>().ReverseMap();
            CreateMap<AddProductDto, Product>().ForMember(x => x.Photos, op => op.Ignore()).ReverseMap();
            CreateMap<UpdateProductDto, Product>().ForMember(x => x.Photos, op => op.Ignore()).ReverseMap();
        }
    }
}
