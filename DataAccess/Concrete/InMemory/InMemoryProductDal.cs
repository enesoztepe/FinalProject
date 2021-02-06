using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product>
            {
                new Product{ Id = 1 , CategoryId = 1 , Name = "Klavye" , UnitPrice = 100 , UnitsInStock = 0 },
                new Product{ Id = 2 , CategoryId = 1 , Name = "Mouse" , UnitPrice = 75 , UnitsInStock = 7},
                new Product{ Id = 3 , CategoryId = 2 , Name = "Mouse Pad" , UnitPrice = 80 , UnitsInStock = 9},
                new Product{ Id = 4 , CategoryId = 2 , Name = "Mikrofon" , UnitPrice = 150 , UnitsInStock = 6},
                new Product{ Id = 5 , CategoryId = 3 , Name = "Monütör" , UnitPrice = 500 , UnitsInStock = 5}
            }; 
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = _products.SingleOrDefault(p => p.Id == product.Id);
            _products.Remove(productToDelete);
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.Id == product.Id);
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.Name = product.Name;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            return _products;
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
