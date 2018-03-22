using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pogodynka.Models;

namespace Pogodynka.Content
{
    public class PogodasController : Controller
    {
        private BazaPogodyEntities2 db = new BazaPogodyEntities2();

        public ActionResult Index()
        {
            return View(db.Pogodas.ToList());
        }

        //[Authorize(Roles = "Administrator")]
        //public ActionResult Admin()
        //{
        //    string apiUri = Url.HttpRouteUrl("DefaultApi", new { controller = "admin", });
        //    ViewBag.ApiUrl = new Uri(Request.Url, apiUri).AbsoluteUri.ToString();

        //    return View(db.Pogodas.ToList());
        //}
        
        //// GET: Pogodas/Details/5
        //[Authorize(Roles = "Administrator")]
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Pogoda pogoda = db.Pogodas.Find(id);
        //    if (pogoda == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(pogoda);
        //}

        //// GET: Pogodas/Create
        //[Authorize(Roles = "Administrator")]
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // //POST: Pogodas/Create
        // //Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // //Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        //[Authorize(Roles = "Administrator")]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ID,City,Country,Temperature,Icon,CityId")] Pogoda pogoda)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Pogodas.Add(pogoda);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(pogoda);
        //}

        //// GET: Pogodas/Edit/5
        //[Authorize(Roles = "Administrator")]
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Pogoda pogoda = db.Pogodas.Find(id);
        //    if (pogoda == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(pogoda);
        //}

        //// POST: Pogodas/Edit/5
        //// Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        //// Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        //[Authorize(Roles = "Administrator")]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ID,City,Country,Temperature,Icon,CityId")] Pogoda pogoda)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(pogoda).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(pogoda);
        //}

        ////GET: Pogodas/Delete/5
        //[Authorize(Roles = "Administrator")]
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Pogoda pogoda = db.Pogodas.Find(id);
        //    if (pogoda == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(pogoda);
        //}

        ////POST: Pogodas/Delete/5
        //[Authorize(Roles = "Administrator")]
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Pogoda pogoda = db.Pogodas.Find(id);
        //    db.Pogodas.Remove(pogoda);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        
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
