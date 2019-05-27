using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Models;

namespace OnlineShop.Controllers
{
    public class AdminController : Controller
    {
        private OnlineShopContext db = new OnlineShopContext();

        // GET: Admin
        public async Task<ActionResult> Index()
        {
            return View(await db.CarModels.ToListAsync());
        }

        // GET: Admin/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarModel carModel = await db.CarModels.FindAsync(id);
            if (carModel == null)
            {
                return HttpNotFound();
            }
            return View(carModel);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CarModelId,NameModel,NameManufacturer,NameCategory,Description,Price")] CarModel carModel)
        {
            if (ModelState.IsValid)
            {
                db.CarModels.Add(carModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(carModel);
        }

   
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarModel carModel = await db.CarModels.FindAsync(id);
            if (carModel == null)
            {
                return HttpNotFound();
            }
            return View(carModel);
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CarModelId,NameModel,NameManufacturer,NameCategory,Description,Price")] CarModel carModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carModel).State = EntityState.Modified;

                await db.SaveChangesAsync();
                TempData["message"] = string.Format("Изменения  \"{0}\" были сохранены", carModel.CarModelId);
                return RedirectToAction("Index");
            }
            else
            {
                return View(carModel);
            }
     
        }

        // GET: Admin/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarModel carModel = await db.CarModels.FindAsync(id);
            if (carModel == null)
            {
                return HttpNotFound();
            }
            return View(carModel);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CarModel carModel = await db.CarModels.FindAsync(id);
            db.CarModels.Remove(carModel);
            TempData["message"] = string.Format("Модель  \"{0}\" была удалена", carModel.CarModelId);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
