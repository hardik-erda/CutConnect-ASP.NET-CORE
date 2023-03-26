using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CutConnect_ASP.NET_CORE.Models;
using MySql.Data.MySqlClient;

namespace CutConnect_ASP.NET_CORE.Controllers;

public class BarberController : Controller
{
    private readonly ILogger<BarberController> _logger;

    public BarberController(ILogger<BarberController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        if(HttpContext.Session.GetString("role")==null){
            RedirectToAction("Login","Auth");
        }
        if(HttpContext.Session.GetString("role")=="c"){
            RedirectToAction("Index","Customer");
        }

        ShopModel shopsObj = new ShopModel();
        
        List<ShopModel> shops =  shopsObj.AllShops();

        return View(shops);
    }
    public IActionResult ShopDetails()
    {
        return View();
    }
    public IActionResult DeleteShop()
    {
        return View();
    }
    public IActionResult Cart()
    {
        return View();
    }
    public IActionResult MyBookings()
    {
        return View();
    }
}