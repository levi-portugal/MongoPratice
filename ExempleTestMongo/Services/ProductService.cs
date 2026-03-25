using ExempleTestMongo.Entities;
using ExempleTestMongo.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExempleTestMongo.Services
{
    internal class ProductService : IProductService
    {
        public readonly List<Product> _products = new();

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public Product GetById(Guid id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public void Update(Product product)
        {
            var existing = _products.FirstOrDefault(p => p.Id == product.Id);

            if (existing == null)
                throw new Exception("Produto não encontrado");

            existing.Name = product.Name;
            existing.Price = product.Price;
            existing.Stock = product.Stock;
        }

        public void Delete(Guid id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                throw new Exception("Produto não encontrado");

            _products.Remove(product);
        }
    }
}
