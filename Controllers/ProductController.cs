using System.Diagnostics;
using CodePink.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;


public class ProductController : Controller
{
    private MyContext db;
    // Here we can "inject" our context service into the constructor 
    public ProductController(MyContext context)
    {
        // When our UserController is instantiated, it will fill in db with context
        // Remember that when context is initialized, it brings in everything we need from DbContext
        // which comes from Entity Framework Core
        db = context;
    }

    private int? uid
    {
        get
        {
            return HttpContext.Session.GetInt32("uid");
        }
    }



    [HttpGet("")]
    public IActionResult CodePink()
    {
        return Redirect("/codepink/laelynn");
    }

    [HttpGet("/codepink/courses")]
    public IActionResult Courses()
    {
        return View("CourseDashboard");
    }


    [HttpGet("/codepink/reviews")]
    public IActionResult Reviews()
    {
        return View("Reviews");
    }

    // [HttpGet("/codepink/shop")]
    // public IActionResult AllProducts()
    // {
    //     List<Product> addedProducts = db.Products
    //     .OrderBy(p => p.Category).ToList();

    //     return View("Shop", addedProducts);
    // }

    [HttpGet("/codepink/shop/laptops")]
    public IActionResult Laptops()
    {
        List<Product> Laptop = db.Products.Where(p => p.Category == "Laptops").ToList();
        return View("Laptops", Laptop);
    }

    [HttpGet("/codepink/shop/monitorsanddesktops")]
    public IActionResult Monitors()
    {
        List<Product> Monitor = db.Products.Where(p => p.Category == "MonitorsAndDesktops").ToList();
        return View("Monitors", Monitor);
    }

    [HttpGet("/codepink/shop/tablets")]
    public IActionResult Tablets()
    {
        List<Product> Tablet = db.Products.Where(p => p.Category == "Tablets").ToList();
        return View("IPads", Tablet);
    }

    [HttpGet("/codepink/shop/furniture")]
    public IActionResult Furniture()
    {
        List<Product> Furniture = db.Products.Where(p => p.Category == "Furniture").ToList();
        return View("Furniture", Furniture);
    }

    [HttpGet("/codepink/shop/accessories")]
    public IActionResult Accessories()
    {
        List<Product> Accessories = db.Products.Where(p => p.Category == "Accessories").ToList();
        return View("Accessories", Accessories);
    }

    [HttpGet("/codepink/shop/earphones")]
    public IActionResult Earphones()
    {
        List<Product> Earphones = db.Products.Where(p => p.Category == "Earphones").ToList();
        return View("Earphones", Earphones);
    }




    [HttpGet("/codepink/{productId}")]
    public IActionResult ViewOne(int productId)
    {
        Product? product = db.Products.FirstOrDefault(product => product.ProductId == productId);
        if (product == null)
        {
            Console.WriteLine("I am here1");
            Console.WriteLine(productId);
            return RedirectToAction("CodePink");
        }
        else
        {
            Console.WriteLine("I am here2");
            return View("ViewOne", product);
        }
    }


    [SessionCheck]
    [HttpGet("/codepink/addProduct")]
    public IActionResult AddOne()
    {
        return View("AddOne");
    }


    [SessionCheck]
    [HttpPost("/codepink/createProduct")]
    public IActionResult CreateProduct(Product p)
    {
        p.UserId = 1;
        if (ModelState.IsValid)
        {
            db.Products.Add(p);
            db.SaveChanges();
            return RedirectToAction("CodePink");
        }
        return View("AddOne");
    }

    [SessionCheck]
    [HttpGet("/codepink/edit/{productId}")]
    public IActionResult EditProduct(int productId)
    {
        Product? item = db.Products
        .Include(item => item.Admin)
        .FirstOrDefault(p => p.ProductId == productId);
        if (uid != 1)
        {
            return RedirectToAction("CodePink");
        }
        else
        {
            return View("Edit", item);
        }
    }


    [SessionCheck]
    [HttpPost("/codepink/updateProduct/{productId}")]
    public IActionResult UpdateProduct(Product p, int productId)
    {
        if (!ModelState.IsValid)
        {
            return EditProduct(productId);
        }
        Product? item = db.Products.FirstOrDefault(item => item.ProductId == productId);
        if (item == null || item.UserId != HttpContext.Session.GetInt32("uid"))
        {
            return RedirectToAction("CodePink");
        }
        else
        {
            item.Name = p.Name;
            item.Category = p.Category;
            item.Price = p.Price;
            item.Img1 = p.Img1;
            item.Img2 = p.Img2;
            item.Img3 = p.Img3;
            item.Img4 = p.Img4;
            // item.Img5 = p.Img5;
            item.Description = p.Description;
            item.UpdatedAt = DateTime.Now;

            db.Products.Update(item);
            db.SaveChanges();

            return RedirectToAction("ViewOne", new { productId = productId });
        }
    }

    [SessionCheck]
    [HttpGet("/codepink/delete/{productId}")]
    public IActionResult DeleteProduct(int productId)
    {
        Product? item = db.Products.FirstOrDefault(item => item.ProductId == productId);
        if (item != null)
        {
            db.Products.Remove(item);
            db.SaveChanges();
        }
        return RedirectToAction("CodePink");
    }



    [HttpPost("/codepink/{id}/cart/add")]
    public IActionResult AddToCart(int id, Product addedProduct)
    {

        Product? dbProduct = db.Products.FirstOrDefault(t => t.ProductId == id);
        if (dbProduct == null)
        {
            Console.WriteLine("Not added to cart");
            return RedirectToAction("CodePink");
        }

        dbProduct.AddToCart = true;

        db.Products.Update(dbProduct);
        db.SaveChanges();

        Console.WriteLine("Added to cart");
        return RedirectToAction("ViewCart");
    }


    [HttpPost("/codepink/{id}/cart/delete")]
    public IActionResult RemoveFromCart(int id, Product removedProduct)
    {

        Product? dbProduct = db.Products.FirstOrDefault(t => t.ProductId == id);
        if (dbProduct == null)
        {
            return RedirectToAction("CodePink");
        }

        dbProduct.AddToCart = false;

        db.Products.Update(dbProduct);
        db.SaveChanges();

        return RedirectToAction("ViewCart");
    }


    [HttpGet("/codepink/cart")]
    public IActionResult ViewCart()
    {
        List<Product> ProductsInCart = db.Products.Where(t => t.AddToCart == true).ToList();
        return View("Cart", ProductsInCart);
    }



    [HttpGet("/codepink/checkout")]
    public IActionResult Checkout()
    {
        return View("Checkout");
    }
}


public class SessionCheckAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        // Find the session, but remember it may be null so we need int?
        int? uid = context.HttpContext.Session.GetInt32("uid");
        // Check to see if we got back null
        if (uid == null)
        {
            // Redirect to the Index page if there was nothing in session
            // "Home" here is referring to "HomeController", you can use any controller that is appropriate here
            context.Result = new RedirectToActionResult("CodePink", "Product", null);
        }
    }
}