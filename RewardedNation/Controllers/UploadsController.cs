using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RewardedNation.Controllers
{
    public class UploadsController : Controller
    {
        // GET: Uploads
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase zip)
        {
            var uploads = Server.MapPath("~/uploadedFiles");
            using(ZipArchive archive = new ZipArchive(zip.InputStream, ZipArchiveMode.Read))
            {
                foreach(ZipArchiveEntry entry in archive.Entries)
                {
                    var ext = Path.GetExtension(entry.FullName);
                    if (!string.IsNullOrEmpty(ext))
                        entry.ExtractToFile(Path.Combine(uploads, entry.FullName));
                    else
                        Directory.CreateDirectory(Path.Combine(uploads, entry.FullName));
                }
            }
            ViewBag.FileNames = Directory.GetFiles(uploads, "*.*", SearchOption.AllDirectories).Select(Path.GetFileName).ToArray();
            return View();
        }
    }
}