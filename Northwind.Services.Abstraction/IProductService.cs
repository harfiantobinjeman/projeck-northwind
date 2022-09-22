﻿using Northwind.Contracts.Dto.Category;
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

        void Insert(ProductForCreateDto productForCreateDto);

        void Edit(ProductDto productDto);

        void Remove(ProductDto productDto);
    }
}