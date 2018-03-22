using Pogodynka.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Pogodynka.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private Models.BazaPogodyEntities2 db = new Models.BazaPogodyEntities2();        

        public ActionResult Index()
        {
            return View(db.Pogodas.ToList());
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Admin()
        {            
            string apiUri = Url.HttpRouteUrl("DefaultApi", new { controller = "admin", });
            ViewBag.ApiUrl = new Uri(Request.Url, apiUri).AbsoluteUri.ToString();

            return View(db.Pogodas.ToList());
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult Admin(string City, string test)
        {
            return null;
        }

        // GET: Pogodas/Details/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pogoda pogoda = db.Pogodas.Find(id);
            if (pogoda == null)
            {
                return HttpNotFound();
            }
            return View(pogoda);
        }

        // GET: Pogodas/Create
        [Authorize(Roles = "Administrator")]
        public async System.Threading.Tasks.Task<ActionResult> Create()
        {            
            await ConsumeExternalWebAPI();            
            return View();
        }

        // POST: Pogodas/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,City,Country,Temperature,Icon,CityId")] Pogoda pogoda)
        {
            if (ModelState.IsValid)
            {                
                db.Pogodas.Add(pogoda);
                db.SaveChanges();
                return RedirectToAction("Admin");
            }

            return View(pogoda);
        }

        // GET: Pogodas/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pogoda pogoda = db.Pogodas.Find(id);
            if (pogoda == null)
            {
                return HttpNotFound();
            }
            return View(pogoda);
        }

        // POST: Pogodas/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,City,Country,Temperature,Icon,CityId")] Pogoda pogoda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pogoda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Admin");
            }
            return View(pogoda);
        }

        // GET: Pogodas/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pogoda pogoda = db.Pogodas.Find(id);
            if (pogoda == null)
            {
                return HttpNotFound();
            }
            return View(pogoda);
        }

        // POST: Pogodas/Delete/5
        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pogoda pogoda = db.Pogodas.Find(id);
            db.Pogodas.Remove(pogoda);
            db.SaveChanges();
            return RedirectToAction("Admin");
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [Authorize(Roles = "Administrator")]
        protected async System.Threading.Tasks.Task<ActionResult> ConsumeExternalWebAPI()
        {            

            string url = "http://api.openweathermap.org/data/2.5/weather?q=Warszawa,pl&lang=pl&units=metric&cnt=1&APPID=c06d79f0976673886c40cdef7a210035";

            using (System.Net.Http.HttpClient client = new System.Net.Http.HttpClient())
            {
                WeatherInfo WeatherInfo = new WeatherInfo();
                Temperature Temperature = new Temperature();
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new
System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                System.Net.Http.HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    string str = data;                    

                    //Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);

                    //var table = Newtonsoft.Json.JsonConvert.DeserializeAnonymousType(data, new { Makes = default(System.Data.DataTable) }).Makes;
                    //var table = Newtonsoft.Json.JsonConvert.DeserializeAnonymousType(data, new System.Data.DataTable());
                    //var table = JsonConvert.DeserializeAnonymousType(data, new { Makes = default(DataTable) }).Makes;

                    //var table = await System.Threading.Tasks.Task.Factory.StartNew(()=> Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data));

                    String[] strArray = str.Split(',');

                    foreach (string s in strArray)
                    {
                        if (s.Contains("name"))
                        {

                            ViewBag.Miasto = this.RemoveSpecialChars(s).Replace("name", string.Empty);                            
                            break;
                        }
                    }
                    foreach (string s in strArray)
                    {

                        if (s.Contains("country"))
                        {
                            string kraj = CheckCountry(RemoveSpecialChars(s).Replace("country", string.Empty));
                             ViewBag.Kraj = kraj;
                            break;
                        }

                    }
                    foreach (string s in strArray)
                    {
                        if (s.Contains("temp"))
                        {
                            string testStr = this.RemoveSpecialChars(s).Replace("maintemp", string.Empty);

                            if (Double.TryParse(testStr, out double testDbl))
                            {
                                ViewBag.Temperatura = testStr;
                                break;
                            }
                        }
                    }
                    foreach (string s in strArray)
                    {
                        if (s.Contains("id") && s.Length > 3)
                        {
                            string testStr = this.RemoveSpecialChars(s).Replace("id", string.Empty);

                            if (int.TryParse(testStr, out int test))
                            {
                                ViewBag.MiastoId = testStr;
                                break;
                            }
                        }

                    }
                }
            }
            return RedirectToAction("Create");
        }

        private string RemoveSpecialChars(string input)
        {
            return System.Text.RegularExpressions.Regex.Replace(input, @"[^0-9a-zA-Z\._]", string.Empty);
        }

        private string CheckCountry(string s)
        {
            string preResult = string.Empty;

            if (s.Equals("PL"))
            {
                preResult = "Polska";               
            }

            return preResult;
        }
    }
}
