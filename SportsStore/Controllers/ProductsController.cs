using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SportsStore.Controllers
{
    public class ProductsController : ApiController
    {
        public ProductsController()
        {
            Repository = new ProductRepository();
        }
        public IEnumerable<Product> GetProducts()
        {
            return Repository.Products;
        }
        public Product GetProduct(int id)
        {
            //return Repository.Products.Where(p => p.Id == id).FirstOrDefault();
            Product result = Repository.Products.Where(p => p.Id == id).FirstOrDefault();
            if (result == null)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else
            {
                return result;
            }
        }
        public async Task<IHttpActionResult> PostProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                await Repository.SaveProductAsync(product);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        public async Task DeleteProduct(int id)
        {
            await Repository.DeleteProductAsync(id);
        }
        private IRepository Repository { get; set; }

    }
}
