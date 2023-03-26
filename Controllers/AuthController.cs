using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CutConnect_ASP.NET_CORE.Models;
using MySql.Data.MySqlClient;

namespace CutConnect_ASP.NET_CORE.Controllers;

public class AuthController : Controller
{
    private readonly ILogger<AuthController> _logger;

    public AuthController(ILogger<AuthController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet,HttpPost]
    public IActionResult Login(UserModel obj)
    {
        if(Request.Method == "POST"){
            List<UserModel> is_authenticated;
            UserModel userobj = new UserModel();
            is_authenticated = userobj.Login(obj);
            if(is_authenticated[0].Unauthenticated ){
                TempData["errormsg"] = "Username or password is incorrect";
                RedirectToAction("Login","Auth");
            }
            else{
                if(is_authenticated[0].Role == "c"){
                    HttpContext.Session.SetString("role","c");
                    RedirectToAction("Index","Customer");
                }
                else{
                    HttpContext.Session.SetString("role","b");
                    RedirectToAction("Index","Barber");
                }
            }
        }
        return View();
    }
    [HttpGet,HttpPost]
    public IActionResult Register(UserModel obj)
    {
        if(Request.Method == "POST"){
            bool res;
            UserModel userobj = new UserModel();
            res = userobj.Register(obj);

            if(res){
                return RedirectToAction("Login","Auth");
            }
        }
        return View();
    }
    public IActionResult Logout()
    {
        return View();
    }
}