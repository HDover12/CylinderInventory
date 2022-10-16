using Microsoft.AspNetCore.Mvc;

namespace CylinderInventory.Controllers
{
    public class About : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
