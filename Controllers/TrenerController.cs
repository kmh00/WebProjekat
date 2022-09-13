using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProjekat.Models.Data;
using WebProjekat.Models;

namespace WebProjekat.Controllers
{
    public class TrenerController : Controller
    {
        // GET: Trener
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TreninziTrener()
        {
            Korisnik korisnik = (Korisnik)Session["Korisnik"];
            List<GrupniTrening> treninzi = new List<GrupniTrening>();
            List<GrupniTrening> list = new List<GrupniTrening>();
            if (korisnik.Uloga == Uloga.posetilac)
                list = korisnik.GrupniTren1;
            else if (korisnik.Uloga == Uloga.trener)
                list = korisnik.Trenira;
            foreach (var v in list)
            {
                treninzi.Add(GrupniTreningData.GetAllGT().Find(x => x.Naziv == v.Naziv));
            }
            
            return View("TrenerTreninzi",treninzi);
        }

        public ActionResult DodajTrening()
        {
            return View("DodajTrening");
        }
        public ActionResult UpisiTrening(string Naziv, int Trajanje, int Max, Tip Tip, DateTime Vreme)
        {
            Korisnik trener = (Korisnik)Session["Korisnik"];
            if (string.IsNullOrEmpty(Naziv) ||
                Trajanje == 0 ||
                Max == 0 ||
                Vreme < DateTime.Now)
            {
                ViewBag.Message = "Molimo ispunite sva polja";
                return View("DodajTrening");
            }
            List<Korisnik> korisnici = new List<Korisnik>();
            GrupniTrening trening = new GrupniTrening(Naziv, Tip, Trajanje, Vreme, Max, korisnici, trener.FitnesCentar);
            
            if(!GrupniTreningData.AddGT(trening))
            {
                ViewBag.Message = "Trening vec postoji";
                return View("DodajTrening");
            }
            trener.Trenira.Add(trening);
            KorisnikData.Uredikorisnika(trener);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Sortiranje(string Sortiraj)
        {
            Korisnik korisnik = (Korisnik)Session["Korisnik"];
            List<GrupniTrening> treninzi = new List<GrupniTrening>();
            List<GrupniTrening> list = new List<GrupniTrening>();
            List<GrupniTrening> sortirano = new List<GrupniTrening>();
            if (korisnik.Uloga == Uloga.posetilac)
                list = korisnik.GrupniTren1;
            else if (korisnik.Uloga == Uloga.trener)
                list = korisnik.Trenira;
            foreach (var v in list)
            {
                treninzi.Add(GrupniTreningData.GetAllGT().Find(x => x.Naziv == v.Naziv));
            }

            if (Sortiraj == "nazivOp")
            {
                sortirano = treninzi.OrderBy(x => x.Naziv).Reverse().ToList();
            }
            else if (Sortiraj == "nazivRA")
            {
                sortirano = treninzi.OrderBy(x => x.Naziv).ToList();
            }
            else if (Sortiraj == "tipOP")
            {
                sortirano = treninzi.OrderBy(x => x.Tip).Reverse().ToList();
            }
            else if (Sortiraj == "tipRA")
            {
                sortirano = treninzi.OrderBy(x => x.Tip).ToList(); ;
            }
            else if (Sortiraj == "datumOP")
            {
                sortirano = treninzi.OrderBy(x => x.Vreme).Reverse().ToList();
            }
            else if (Sortiraj == "datumRA")
            {
                sortirano = treninzi.OrderBy(x => x.Vreme).ToList();
            }
          
            return View("TrenerTreninzi", sortirano);
        }

        public ActionResult ObrisiTrening(string Naziv)
        {
            GrupniTrening gt = GrupniTreningData.GetAllGT().Find(x => x.Naziv == Naziv);
            if(gt.Posjetioci.Count > 0)
            {
                ViewBag.Message = "Ne mozete da izbrisete tening na kom su prijavljeni posjetioci";
                return RedirectToAction("Index", "Home");
            }
            else if(gt.Vreme < DateTime.Now)
            {
                ViewBag.Message = "Ne mozete da izbrisete tening koji je vec odrzan";
                return RedirectToAction("Index", "Home");
            }

            gt.Obrisan = true;
            GrupniTreningData.UrediGT(gt);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult UrediTrening(string Naziv)
        {
            GrupniTrening trening = GrupniTreningData.GetAllGT().Find(x => x.Naziv == Naziv);
            if(trening.Vreme< DateTime.Now)
            {
                ViewBag.Message = "Ne mozete da menjate tening koji je vec odrzan";
                return RedirectToAction("Index", "Home");
            }
            return View("UrediTrening",trening);
        }

        public ActionResult Uredi(string Naziv, int Trajanje, int Max, Tip Tip, DateTime Vreme)
        {
            Korisnik trener = (Korisnik)Session["Korisnik"];
            if (string.IsNullOrEmpty(Naziv) ||
                Trajanje == 0 ||
                Max == 0 ||
                Vreme < DateTime.Now)
            {
                ViewBag.Message = "Molimo ispunite sva polja";
                return View("DodajTrening");
            }

            List<Korisnik> korisnici = new List<Korisnik>();
            GrupniTrening trening = new GrupniTrening(Naziv, Tip, Trajanje, Vreme, Max, korisnici, trener.FitnesCentar);

           
            GrupniTreningData.UrediGT(trening);
            

            return RedirectToAction("Index", "Home");
            
        }
    }
}