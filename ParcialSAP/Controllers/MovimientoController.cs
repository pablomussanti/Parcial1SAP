using ParcialSAP.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParcialSAP.Controllers
{
    public class MovimientoController : Controller
    {
        // GET: Movimiento
        public ActionResult Index()
        {
            MovimientoBLL MovimientoBLL = new MovimientoBLL();
            return View(MovimientoBLL.ListarMovimientos());
        }


    }
}
