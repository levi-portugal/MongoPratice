using ExempleTestMongo.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExempleTestMongo.Interfaces
{
    public interface IProductService
    {     
            void Add(Product product);

            List<Product> GetAll();

            Product GetById(Guid id);

            void Update(Product product);

            void Delete(Guid id);  
    }
}
