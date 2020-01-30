using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ElephantCarpaccio.Models;
using ElephantCarpaccio.Service;

namespace ElephantCarpaccio.Controllers
{
    public class CarpaccioController : Controller
    {
        private ICarpaccioService carpaccioSvc;

        public CarpaccioController(ICarpaccioService carpaccioSvc)
        {
            this.carpaccioSvc = carpaccioSvc;
        }

        [HttpPost]
        public IActionResult ElephantCarpaccio(CarpaccioModel model)
        {
            try
            {
                var output = carpaccioSvc.PriceCalculator(model);

                return View("~/Views/Home/CarpaccioResult.cshtml", output);
            }
            catch (Exception e)

            {
                return View("~/Views/Home/Error.cshtml", 
                    new ErrorViewModel() { ErrorMessage = e.Message });
            }
        }
    }
}