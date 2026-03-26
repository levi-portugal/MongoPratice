using ExempleTestMongo.DTOs;
using ExempleTestMongo.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using ExempleTestMongo.Data.Repositories;

namespace ExempleTestMongo.Interfaces
{
    public interface IProductService
    {
        void Add(ProductRequestDto dto);
        List<ProductResponseDto> GetAll();
        ProductResponseDto GetById(string id);
        void Update(string id, ProductRequestDto dto);
        void Delete(string id);
    }
}
