using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;

namespace CRUD_Operations.Controllers
{
    public class TestController : Controller
    {
        public IActionResult AddName()
        {
            int id = 3;
            string name = "Ali";
            Response.Cookies.Append("id" ,id.ToString());
            Response.Cookies.Append("fname", name);

            return View();
        }
        public IActionResult GetName() 
        {
            int id = int.Parse(Request.Cookies["id"]);
            string name = Request.Cookies["name"];
            return Content($"{id} : {name}");
        
        }
        public IActionResult AddId( ) 
        {
            int id = 3;
            string NAME = "Ahmed";
            HttpContext.Session.SetInt32("id", id);
            HttpContext.Session.SetString("name", NAME);
            return View();
        }
    }
}
