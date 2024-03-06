using Microsoft.AspNetCore.Mvc;
using _444.Data;
using _444.Models;
namespace _444.Controllers

{


    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public List<Product> GetClass()
        {
            var data = _db.Products.ToList();
            return  data;
        }
       
    }
}
