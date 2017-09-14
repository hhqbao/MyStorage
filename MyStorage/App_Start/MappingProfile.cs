using AutoMapper;
using MyStorage.Core.Dtos.Category;
using MyStorage.Core.Dtos.CategoryType;
using MyStorage.Core.Dtos.Product;
using MyStorage.Core.Dtos.Stock;
using MyStorage.Core.Dtos.Supplier;
using MyStorage.Core.Models;

namespace MyStorage
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Supplier, SupplierDto>();
            Mapper.CreateMap<SupplierDto, Supplier>();

            Mapper.CreateMap<CategoryType, CategoryTypeDto>();
            Mapper.CreateMap<CategoryTypeDto, CategoryType>();

            Mapper.CreateMap<Category, CategoryDto>();
            Mapper.CreateMap<CategoryDto, Category>();            

            Mapper.CreateMap<Product, ProductDto>();
            Mapper.CreateMap<ProductDto, Product>();

            Mapper.CreateMap<Stock, StockDto>();
            Mapper.CreateMap<StockDto, Stock>();
        }
    }    
}