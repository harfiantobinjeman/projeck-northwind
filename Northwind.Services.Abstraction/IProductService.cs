using Northwind.Contracts.Dto.Category;
using Northwind.Contracts.Dto.Product;
using Northwind.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Services.Abstraction
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProduct(bool trackChanges);

        Task<ProductDto> GetProductById(int productId, bool trackChanges);

        Task<IEnumerable<ProductDto>> GetProductOneSales(bool trackChanges);

        //tambahan
        Task<ProductPhotoGroupDto> GetProductPhotoGroupById(int productId, bool trackChange);

        Task<ProductPhotoDto> GetProductPhotoById(int productId, bool trackChange);
        //batas tambahan
        Task<ProductDto> GetProductSalesById(int productId, bool trackChanges);

        Task<IEnumerable<ProductDto>> GetProductPaged(int pageIndex, int pageSize, bool trackChanges);

        ProductDto CreateProductId(ProductForCreateDto productForCreateDto);

        void Insert(ProductForCreateDto productForCreateDto);

        void Edit(ProductDto productDto);

        void Remove(ProductDto productDto);

        void CreateProductManyPhoto(ProductForCreateDto productForCreateDto, 
            List<ProductPhotoCreateDto> 
            productPhotoCreateDtos);
    }
}
