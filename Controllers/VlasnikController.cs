using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProjekat.Models;
using WebProjekat.Models.Data;

namespace WebProjekat.Controllers
{
    public class VlasnikController : Controller
    {
        // GET: Vlasnik
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MojiFitnesCentri()
        {
            return View("VlasnikCentri");
        }
        public ActionResult DodajFitnesCentar()
        {
            return View("DodajCentar");
        }
        public ActionResult DodajCentar(string Naziv="", string Adresa = "", int Godina=1, int CenaMes=0, int CenaGod = 0, int CenaDan = 0, int CenaGrupa = 0, int CenaPersonal = 0)
        {
            Korisnik vlasnik = (Korisnik)Session["Korisnik"];
            if (string.IsNullOrEmpty(Naziv) || string.IsNullOrEmpty(Adresa)||  Godina ==1 || CenaMes == 0 || CenaGod == 0 || CenaDan == 0 || CenaGrupa == 0 || CenaPersonal==0)
            {
                ViewBag.Message = "Popunite sva polja";
                return View("DodajCentar");

            }
            FitnesCentar centar = new FitnesCentar(Naziv, Adresa, Godina,vlasnik, CenaMes, CenaGod, CenaDan, CenaGrupa, CenaPersonal);
            if(FitnesCentarData.DodajFitnesCentar(centar) == false)
            {
                ViewBag.Message = "Fitnes Centar sa unetim nazivom vec postoji";
                return View("DodajCentar");
            }
            return View("VlasnikCentri");
        }
        public ActionResult ObrisiCentar(string naziv)
        {
            FitnesCentar centar = (FitnesCentarData.GetAllFitnesCentri()).Find(x => x.Naziv == naziv);
            centar.Obrisan = true;
            FitnesCentarData.UrediFitnesCentar(centar);
            return View("VlasnikCentri");
        }
        
        public ActionResult UrediCentar(string naziv)
        {
            FitnesCentar centar = (FitnesCentarData.GetAllFitnesCentri()).Find(x => x.Naziv == naziv);
            return View("UrediCentar", centar);
        }
        public ActionResult UrediFitnesCentar(string Naziv = "", string Adresa = "", int Godina = 1, int CenaMes = 0, int CenaGod = 0, int CenaDan = 0, int CenaGrupa = 0, int CenaPersonal = 0)
        {
            Korisnik vlasnik = (Korisnik)Session["Korisnik"];
            if (string.IsNullOrEmpty(Naziv) || string.IsNullOrEmpty(Adresa) || Godina == 1 || CenaMes == 0 || CenaGod == 0 || CenaDan == 0 || CenaGrupa == 0 || CenaPersonal == 0)
            {
                ViewBag.Message = "Popunite sva polja";
                return UrediCentar(Naziv);
            }
            FitnesCentar centar = new FitnesCentar(Naziv, Adresa, Godina, vlasnik, CenaMes, CenaGod, CenaDan, CenaGrupa, CenaPersonal);
            FitnesCentarData.UrediFitnesCentar(centar);
            return View("VlasnikCentri");
        }
    }
}