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
        public ActionResult Login(string korIme, string lozinka)
        {
            List<Korisnik> korisnici = KorisnikData.GetAllKorisnici();
            Korisnik korisnik = korisnici.Find(k => k.KorIme.Equals(korIme) && k.Lozinka.Equals(lozinka));

            if (korisnik == null)
            {
                ViewBag.Message = $"Korisnik ne postoji!";
                return View("Login");
            }
            Session["Korisnik"] = korisnik;
            return RedirectToAction("Index");
            
        }
        public ActionResult Login1()
        {
            return View("Login");
        }

        public ActionResult Logout()
        {
            Session["Korisnik"] = null;
            return RedirectToAction("Index");
        }
        public ActionResult Register(string KorIme,string Lozinka, string Ime, string Prezime, string Email,Pol pol, DateTime DatRodj )
        {
            List<Korisnik> korisnici = KorisnikData.GetAllKorisnici();

            if (KorIme == null || Lozinka == null || Ime == null || Prezime == null || Email == null || DatRodj == null)
            {
                ViewBag.Message = $"Molimo popunite polja.";
                return View("Registracija");
            }

            foreach (Korisnik k in korisnici)
            {
                if (k.KorIme == KorIme)
                {
                    ViewBag.Message = $"Korisnik sa unesenim korisnickim imenom vec postoji.";
                    return View("Register");
                }
            }

            if (KorIme.Length < 3)
            {
                ViewBag.Message = $"Korsinicko ime mora imati vise od 3 karaktera.";
                return View("Register");
            }
            if (Lozinka.Length < 6)
            {
                ViewBag.Message = $"Lozinka mora da ima bar 6 karaktera.";
                return View("Register");
            }
            if (!Email.Contains("@"))
            {
                ViewBag.Message = $"Nepostojeci email.";
                return View("Register");
            }
            if (DatRodj > DateTime.Now)
            {
                ViewBag.Message = $"Unesite ispravan datum rodjenja.";
                return View("Register");
            }

            Korisnik korisnik = new Korisnik(KorIme, Lozinka, Ime, Prezime, pol, Email, DatRodj, Uloga.posetilac);

            KorisnikData.DodajKorisnika(korisnik);
            Session["Korisnik"] = korisnik;
            return RedirectToAction("Index");
        }
        public ActionResult Registration()
        {
            return View("Register");
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