using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProjekat.Models.Data;
using WebProjekat.Models;

namespace WebProjekat.Controllers
{
    public class FitnesCentarController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detalji(string naziv)
        {
            FitnesCentar centar = (FitnesCentarData.GetAllFitnesCentri()).Find(x => x.Naziv == naziv);
            List<GrupniTrening> treninzi = GrupniTreningData.TreninziFitnesCentar(naziv);
            TempData["Grupe"] = treninzi;
                return View("Detalji",centar);
        }
    }
}