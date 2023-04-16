#pragma warning disable CS8618
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProductsAndCategories.Models;
using Microsoft.EntityFrameworkCore;


namespace ProductsAndCategories.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;
    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        MyViewModel MyModel = new MyViewModel()
        {
            AllProducts = _context.Products.ToList(),
            Product = new Product()

        };
        return View(MyModel);
    }
    // ----------------CREATE PRODUCT-------------------------------
    [HttpPost("product/create")]
    public IActionResult CreateProduct(Product newProduct)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newProduct);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View("Index");
    }

    // -------------------VIEW CATEGORIES-----------------------
    [HttpGet("categories")]
    public IActionResult ViewCategories()
    {
        MyViewModel AnotherModel = new MyViewModel()
        {
            AllCategories = _context.Categories.ToList(),
            Category = new Category()

        };
        return View("AddCategory", AnotherModel);
    }

    // --------------CREATE CATEGORY------------------------------
    [HttpPost("category/create")]
    public IActionResult CreateCategory(Category newCategory)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newCategory);
            _context.SaveChanges();
            return ViewCategories();
        }
        return ViewCategories();
    }

    // -----------------------VIEW PRODUCT---------------------------------
    [HttpGet("products/{ProductId}")]
    public IActionResult ViewProduct(int ProductId)
    {


        Product product = _context.Products.FirstOrDefault(p => p.ProductId == ProductId);


        var productCategories = _context.Associations
            .Include(a => a.Category)
            .Where(a => a.ProductId == product.ProductId)
            .Select(a => a.Category);

        List<Category> allCategories = _context.Categories.ToList();


        MyViewModel viewModel = new MyViewModel
        {
            Product = _context.Products.FirstOrDefault(p => p.ProductId == ProductId),
            AllProducts = _context.Products.ToList(),
            Category = null,
            AllCategories = allCategories.Except(productCategories).ToList(),
            Association = null,
            AllAssociations = _context.Associations
                .Include(a => a.Product)
                .Include(a => a.Category)
                .Where(a => a.ProductId == product.ProductId)
                .ToList()
        };

        return View("Products", viewModel);

    }


    // ----------------------ADD CATEGORY TO PRODUCT--------------------------
    [HttpPost("products/{ProductId}/addcategory")]
    public IActionResult AddCategory(int ProductId, Association newAssociation)
    {
        // newAssociation.ProductId = ProductId;
        if (ModelState.IsValid)
        {
            _context.Add(newAssociation);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View("Products");
    }


    // -----------------------VIEW CATEGORY---------------------------------
    [HttpGet("categories/{CategoryId}")]
    public IActionResult ViewCategory(int CategoryId)
    {

        Category category = _context.Categories.FirstOrDefault(p => p.CategoryId == CategoryId);


        var categoryProduct = _context.Associations
            .Include(a => a.Product)
            .Where(a => a.CategoryId == category.CategoryId)
            .Select(a => a.Product);

        List<Product> allProducts = _context.Products.ToList();


        MyViewModel viewModel = new MyViewModel
        {
            Product = null,
            AllProducts = allProducts.Except(categoryProduct).ToList(),
            Category = _context.Categories.FirstOrDefault(p => p.CategoryId == CategoryId),
            AllCategories = _context.Categories.ToList(),
            Association = null,
            AllAssociations = _context.Associations
                .Include(a => a.Product)
                .Include(a => a.Category)
                .Where(a => a.CategoryId == category.CategoryId)
                .ToList()
        };

        return View("Categories", viewModel);
    }

    // ----------------------ADD PRODUCT TO CATEGORY --------------------------
    [HttpPost("products/{CategoryId}/addproduct")]
    public IActionResult AddProduct(int CategoryId, Association newAssociation)
    {
        newAssociation.CategoryId = CategoryId;
        if (ModelState.IsValid)
        {
            _context.Add(newAssociation);
            _context.SaveChanges();
            return ViewCategory(CategoryId);
        }
        return View("Categories");
    }



    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
