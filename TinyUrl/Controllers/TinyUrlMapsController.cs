using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TinyUrl.Models;
using System.Text;

namespace TinyUrl.Controllers
{
 
    public class TinyUrlMapsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TinyUrlMaps
        public async Task<ActionResult> Index()
        {
            return View(await db.TinyUrlMaps.ToListAsync());
        }

        // GET: TinyUrlMaps/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TinyUrlMap tinyUrlMap = await db.TinyUrlMaps.FindAsync(id);
            if (tinyUrlMap == null)
            {
                return HttpNotFound();
            }
            return View(tinyUrlMap);
        }

        // GET: Link/{token}

        [Route("l/{token}")]
        public async Task<ActionResult> Lookup(string token)
        {
            if (token == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TinyUrlMap tinyUrlMap = await db.TinyUrlMaps.Where(m => m.UrlToken == token).FirstAsync();
            if (tinyUrlMap == null)
            {
                return HttpNotFound();
            }
            return View(tinyUrlMap);
        }

        // GET: TinyUrlMaps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TinyUrlMaps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,OriginalUrl")] TinyUrlMap tinyUrlMap)
        {
            if (ModelState.IsValid)
            {
                tinyUrlMap.UrlToken = RandomString(5);
                db.TinyUrlMaps.Add(tinyUrlMap);
                await db.SaveChangesAsync();
                return RedirectToAction("Details", new  { id = tinyUrlMap.Id });
            }

            return View(tinyUrlMap);
        }
        private string RandomString(int size)
        {
            Guid g = Guid.NewGuid();
            string gs = Convert.ToBase64String(g.ToByteArray());
            gs = gs.Replace("=", "");
            gs = gs.Replace("+", "");
            return gs.Substring(0, size);
        }
     

        // GET: TinyUrlMaps/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TinyUrlMap tinyUrlMap = await db.TinyUrlMaps.FindAsync(id);
            if (tinyUrlMap == null)
            {
                return HttpNotFound();
            }
            return View(tinyUrlMap);
        }

        // POST: TinyUrlMaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TinyUrlMap tinyUrlMap = await db.TinyUrlMaps.FindAsync(id);
            db.TinyUrlMaps.Remove(tinyUrlMap);
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
