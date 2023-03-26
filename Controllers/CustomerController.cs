using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CutConnect_ASP.NET_CORE.Models;
using MySql.Data.MySqlClient;

namespace CutConnect_ASP.NET_CORE.Controllers;

public class CustomerController : Controller
{
    private readonly ILogger<CustomerController> _logger;

    public CustomerController(ILogger<CustomerController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        if(HttpContext.Session.GetString("role")==null){
            RedirectToAction("Login","Auth");
        }
        if(HttpContext.Session.GetString("role")=="b"){
            RedirectToAction("Index","Barber");
        }
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