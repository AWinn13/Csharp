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
        // List<Product> AllProducts = _context.Products.ToList();
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
        Product? OneProduct = _context.Products.Include(a => a.Associations).ThenInclude(a => a.Category).FirstOrDefault(p => p.ProductId == ProductId);
        List<Category> AllCategories = _context.Categories.ToList();
        List<Association> ProdCat = _context.Associations.Include(a => a.Category).Where(a => a.ProductId ==ProductId).ToList();

        ViewBag.PC = ProdCat;
        ViewBag.OP = OneProduct;
        ViewBag.EC = AllCategories;
        // MyViewModel WhatModel = new MyViewModel() 
        // {
        //     Association = new Association(),

        //     AllAssociations  = _context.Associations.Where(a => a.ProductId == ProductId).Include(a => a.Category).ToList(),
        //     AllCategories = _context.Categories.ToList(),
        //     Product =  _context.Products.Include(a => a.Associations).ThenInclude(a => a.Category).FirstOrDefault(p => p.ProductId == ProductId)

        // };
        return View("Products");
    }


    // ----------------------ADD CATEGORY TO PRODUCT--------------------------
    [HttpPost("products/{ProductId}/addcategory")]
    public IActionResult AddCategory(int ProductId, Association newAssociation)
    {
        // newAssociation.ProductId = ProductId;
        if(ModelState.IsValid)
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

        Category? OneCategory = _context.Categories.Include(a => a.Associations).ThenInclude(a => a.Product).FirstOrDefault(p => p.CategoryId == CategoryId);
        List<Product> AllProducts = _context.Products.ToList();
        List<Association> CatProd = _context.Associations.Include(a => a.Product).Where(a => a.CategoryId ==CategoryId).ToList();

        ViewBag.CP = CatProd;
        ViewBag.OC = OneCategory;
        ViewBag.AP = AllProducts;

        // MyViewModel Mooodel = new MyViewModel()
        // {
        //     Association = new Association(),
        //     AllAssociations = _context.Associations.Include(p => p.Category).ToList(),
        //     AllProducts = _context.Products.ToList(),
        //     Category = _context.Categories.SingleOrDefault(p => p.CategoryId == CategoryId)

        // };
        return View("Categories");
    }

    // ----------------------ADD PRODUCT TO CATEGORY --------------------------
    [HttpPost("products/{CategoryId}/addproduct")]
    public IActionResult AddProduct(int CategoryId, Association newAssociation)
    {
        newAssociation.CategoryId = CategoryId;
        if(ModelState.IsValid)
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
