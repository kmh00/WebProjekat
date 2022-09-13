using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProjekat.Models;
using WebProjekat.Models.Data;

namespace WebProjekat.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(FitnesCentarData.GetAllFitnesCentri());

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Sortiranje(string Sortiraj)
        {
            List<FitnesCentar> centri = FitnesCentarData.GetAllFitnesCentri();
            List<FitnesCentar> sortirano = new List<FitnesCentar>();
            
            if (Sortiraj == "nazivOp")
            {
               sortirano =  centri.OrderBy(x => x.Naziv).Reverse().ToList();
            }
            else if (Sortiraj == "nazivRA")
            {
                sortirano = centri.OrderBy(x => x.Naziv).ToList();
            }
            else if (Sortiraj == "godOP")
            {
                sortirano = centri.OrderBy(x => x.Godina).Reverse().ToList();
            }
            else if (Sortiraj == "godRA")
            {
                sortirano = centri.OrderBy(x => x.Godina).ToList(); ;
            }
            else if (Sortiraj == "adresaOP")
            {
                sortirano = centri.OrderBy(x => x.Adresa).Reverse().ToList();
            }
            else if (Sortiraj == "adresaRA")
            {
                sortirano = centri.OrderBy(x => x.Adresa).ToList();
            }
            return View("Index", sortirano);
        }

        public ActionResult Pretrazi(string naziv="", int godina1=1970, int godina2=2030, string adresa="")
        {
            List<FitnesCentar> centri = FitnesCentarData.GetAllFitnesCentri();
            List<FitnesCentar> pretrazeno = new List<FitnesCentar>();
            foreach (FitnesCentar a in centri)
            {
                if (!a.Naziv.ToLower().Contains(naziv.ToLower()) || godina1 >= a.Godina || godina2<= a.Godina || !a.Adresa.ToLower().Contains(adresa.ToLower()))
                    continue;
                pretrazeno.Add(a);
            }

            
            return View("Index", pretrazeno);
        }
    }
}