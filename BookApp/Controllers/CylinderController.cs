using BookApp.Data;
using BookApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookApp.Controllers
{
    public class CylinderController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CylinderController(ApplicationDbContext db)
        {
            _db = db;
        }
    
        public IActionResult Index()
        {
            IEnumerable<Cylinder> objCylinderList = _db.CylinderInventory;
            return View(objCylinderList);
        }

        //Get
        public IActionResult Create()
        {
            
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cylinder obj)
        {
            if (ModelState.IsValid)
            {
                _db.CylinderInventory.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Cylinder added successfully";
                TempData["cylinder"] = obj.Id;
                return RedirectToAction("Index");
            }
            return View(obj);   
        }


        //Get
        public IActionResult Edit(int? id)
        {
            if(id==null || id==0)
            {
                return NotFound();
            }
            var cylinderFromDb = _db.CylinderInventory.Find(id);   
            if (cylinderFromDb==null)
            {
                return NotFound();
            }

            return View(cylinderFromDb);
        }
         
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Cylinder obj)
        {
            if (ModelState.IsValid)
            {
                _db.CylinderInventory.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Cylinder updated successfully";
                TempData["cylinder"] = obj.Id;
                return RedirectToAction("Index");
            }
            return View(obj);
        }



        //Get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var cylinderFromDb = _db.CylinderInventory.Find(id);
            if (cylinderFromDb == null)
            {
                return NotFound();
            }

            return View(cylinderFromDb);
        }

        //Post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.CylinderInventory.Find(id);
            if(obj == null)
            {
                       return NotFound();
            }

           
                _db.CylinderInventory.Remove(obj);
                _db.SaveChanges();
            TempData["error"] = "Cylinder deleted";
            return RedirectToAction("Index");
         
          
        }
    }
}
