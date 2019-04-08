using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreMVCTipAndTricks.Controllers
{
    public class UploadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadFile(IFormFile myfile)
        {
            if (myfile != null)
            {
                //chỉ định đường dẫn sẽ lưu
                string fullPath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot", "MyFiles", myfile.FileName);

                //copy file vào thư mục chỉ định
                using (var file = new FileStream(fullPath, FileMode.Create))
                {
                    myfile.CopyTo(file);
                }
            }

            return View("Index");
        }

        [HttpPost]
        public IActionResult UploadFiles(List<IFormFile> myfile)
        {
            //duyệt từng file và lưu xuống thư mục chỉ định
            foreach(IFormFile f in myfile)
            {
                string fullPath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot", "MyFiles", f.FileName);

                using (var file = new FileStream(fullPath, FileMode.Create))
                {
                    f.CopyTo(file);
                }
            }


            return View("Index");
        }
    }
}