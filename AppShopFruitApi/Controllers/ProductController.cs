
using AppShopFruitApi.Data;
using AppShopFruitApi.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppShopFruitApi.Controllers
{
    public class ProductController : Controller
    {
        private readonly DataContext _context;

        public ProductController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("/Products")]
        public IEnumerable<Product> GetListProduct()
        {
            return _context.Products;
        }

        [HttpGet("/Products/{id:int}")]
        public IActionResult GetProductId(int id)
        {
            var products = _context.Products.Where(x => x.Id == id);
            if(products == null) return NotFound();
            return Ok(products);
        }
    }
}
