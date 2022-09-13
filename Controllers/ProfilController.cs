using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProjekat.Models;
using WebProjekat.Models.Data;

namespace WebProjekat.Controllers
{
    public class ProfilController : Controller
    {
       
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UrediProfil()
        {
            return View("UrediProfil");
        }

        public ActionResult Uredi(string KorIme, string Lozinka, string Ime, string Prezime, Pol pol, string Email, DateTime DatRodj)
        {
            List<Korisnik> korisnici = KorisnikData.GetAllKorisnici();
            Korisnik korisnik = (Korisnik)Session["Korisnik"];
            if (Lozinka == null || Ime == null || Prezime == null || Email == null || DatRodj == null)
            {
                ViewBag.Message = $"Popunite sva polja.";
                return View("UrediProfil");

               
                
            }
            if (KorIme.Length < 3)
            {
                ViewBag.Message = $"Korsinicko ime mora imati vise od 3 karaktera.";
                return View("UrediProfil");
            }
            if (Lozinka.Length < 6)
            {
                ViewBag.Message = $"Lozinka mora da ima bar 6 karaktera.";
                return View("UrediProfil");
            }
            if (!Email.Contains("@"))
            {
                ViewBag.Message = $"Nepostojeci email.";
                return View("UrediProfil");
            }
            if (DatRodj > DateTime.Now)
            {
                ViewBag.Message = $"Unesite ispravan datum rodjenja.";
                return View("UrediProfil");
            }
            Korisnik k = new Korisnik(KorIme, Lozinka, Ime, Prezime, pol, Email, DatRodj, korisnik.Uloga);
            KorisnikData.Uredikorisnika(k);
            Session["Korisnik"] = k;
            return RedirectToAction("Index", "Home");
        }
    }
}