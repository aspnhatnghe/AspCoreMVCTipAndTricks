using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspCoreMVCTipAndTricks.DataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreMVCTipAndTricks.Controllers
{
    public class ProductController : Controller
    {
        private readonly MyEStoreContext _context;
        public ProductController(MyEStoreContext db)
        {
            _context = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search(string term)
        {
            try
            {
                var names = _context.HangHoa.Where(p => p.TenHh.Contains(term)).Select(p => p.TenHh).ToList();

                return Json(names);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}