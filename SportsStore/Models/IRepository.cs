using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    interface IRepository
    {
        IEnumerable<Product> Products { get; }
        Task<int> SaveProductAsync(Product product);
        Task<Product> DeleteProductAsync(int productID);
        IEnumerable<Order> Orders { get; }
        Task<int> SaveOrderAsync(Order order);
        Task<Order> DeleteOrderAsync(int orderID);
    }
}
