using System;       
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace ProjectNhom12.Controllers
{
    public class FileUploadController : Controller
    {
        private readonly IFileProvider fileProvider;

        public FileUploadController(IFileProvider fileProvider) { this.fileProvider = fileProvider; }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0) return Content("file not selected");

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "HinhSV", file.FileName);

            using (var stream = new FileStream(path, FileMode.Create)) { await file.CopyToAsync(stream); }

           return RedirectToAction("ListFiles");
        }
        [HttpPost]
        public async Task<IActionResult> UploadFiles(List<IFormFile> files)
        {
            if (files == null || files.Count == 0) return Content("files not selected");

            foreach (var file in files)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "HinhSV", file.FileName);

                using (var stream = new FileStream(path, FileMode.Create)) { await file.CopyToAsync(stream); }
            }

            return RedirectToAction("ListFiles");
        }

    }
}