using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

public class ProductController : Controller
{
    private readonly ApplicationDbContext _db;
    public ProductController(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> Index()
    {
        HttpClient sad = new HttpClient();
   
        var response = await sad.GetAsync("http://localhost:5045/Product");
       
        
            var jsonString = await response.Content.ReadAsStringAsync();
            var ProductsList = JsonConvert.DeserializeObject<List<Product>>(jsonString);
            return View(ProductsList);
        
       
    }


    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]

    public IActionResult Add(Product product)
    {
        if (ModelState.IsValid)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(product);
    }

    [HttpPost]
    public IActionResult Clear()
    {
        
        _db.Products.ExecuteDelete();

        return RedirectToAction("Index");
    }
}