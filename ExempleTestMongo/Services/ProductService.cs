using ExempleTestMongo.Data;
using ExempleTestMongo.Data.Repositories;
using ExempleTestMongo.DTOs;
using ExempleTestMongo.Entities;
using ExempleTestMongo.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExempleTestMongo.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repository;

        public ProductService(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public void Add(ProductRequestDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                Stock = dto.Stock
            };
            _repository.Create(product);
        }

        public List<ProductResponseDto> GetAll()
        {
            var products = _repository.GetAll();

            return products.Select(p => new ProductResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Stock = p.Stock
            }).ToList();
        }

        public ProductResponseDto GetById(string id)
        {
            var p = _repository.GetById(id.ToString());
            if (p == null) return null;

            return new ProductResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Stock = p.Stock
            };
        }

        public void Update(string id, ProductRequestDto dto)
        {
            var product = new Product
            {
                Id = id,
                Name = dto.Name,
                Price = dto.Price,
                Stock = dto.Stock
            };
            _repository.Update(id.ToString(), product);
        }

        public void Delete(string id)
        {
            _repository.Delete(id.ToString());
        }
    }
}
