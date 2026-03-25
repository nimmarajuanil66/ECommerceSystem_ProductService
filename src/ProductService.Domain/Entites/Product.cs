using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Domain.Entites
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        //public int stcok { get; private set; }

        private Product() { }

        public Product(string name, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required");

            if (price <= 0)
                throw new ArgumentException("Price must be greater than zero");

            Id = Guid.NewGuid();
            Name = name;
            Price = price;
        }
        public void Update(string name, decimal price)
        {
            // Business rules can go here
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Name cannot be empty");

            if (price <= 0)
                throw new Exception("Price must be greater than zero");

            Name = name;
            Price = price;
        }
    }
}
