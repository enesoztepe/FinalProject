using Business.Concrete;
using DataAccess.Concrete.EntitiyFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal(), new CategoryManager(new EfCategoryDal()));
            ProductListTest(productManager);

        }

        private static void ProductListTest(ProductManager productManager)
        {
            var result = productManager.GetAll();
            if (result.Success)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.Name);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
