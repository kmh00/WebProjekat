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

        public ActionResult Ucestvuj(string trening)
        {
            Korisnik korisnik = (Korisnik)Session["Korisnik"];
            GrupniTrening grupniTrening = (GrupniTreningData.GetAllGT()).Find(x => x.Naziv == trening);
            List<GrupniTrening> list = new List<GrupniTrening>();
            if (grupniTrening.MaxPosjetilaca == grupniTrening.Posjetioci.Count())
            {
                ViewBag.Message = "Sva mjesta su popunjena";
                return RedirectToAction("Index", "Home");
            }
            else if(grupniTrening.Posjetioci.Contains(korisnik))
                {
                ViewBag.Message = "Vec ste prijavljeni na trenin";
                return RedirectToAction("Index", "Home");
            }
            grupniTrening.Posjetioci.Add(korisnik);
            korisnik.GrupniTren1.Add(grupniTrening);
            KorisnikData.Uredikorisnika(korisnik);
            GrupniTreningData.UrediGT(grupniTrening);
            return RedirectToAction("Index", "Home");
        }
    }
}
