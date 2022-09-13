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
            List<Korisnik> korinici = KorisnikData.GetAllKorisnici();
            foreach (Korisnik korisnik in korinici)
            {
                if(korisnik.Uloga == Uloga.trener)
                {
                    if(korisnik.FitnesCentar.Naziv == naziv)
                    {
                        Blokiraj(korisnik.KorIme);
                    }
                }
            }
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

        public ActionResult Treneri(string naziv)
        {
            List<Korisnik> korisnici = KorisnikData.GetAllKorisnici();
            List<Korisnik> treneri = new List<Korisnik>();
            foreach (Korisnik i in korisnici)
            {
                if(i.Uloga== Uloga.trener && i.FitnesCentar.Naziv== naziv)
                {
                    treneri.Add(i);
                }
            }
            return View("Treneri",treneri);
        }

        public ActionResult DodajTrenera()
        {
            Korisnik vlasnik = (Korisnik)Session["Korisnik"];
            List<FitnesCentar> centri = FitnesCentarData.GetAllCentriByVlasnik(vlasnik);
            return View("DodajTrenera", centri);
        }
        public ActionResult UpisiTrenera(string KorIme, string Lozinka, string Ime, string Prezime,string FitnesCentri, string Email, Pol pol, DateTime DatRodj)
        {
            List<Korisnik> korisnici = KorisnikData.GetAllKorisnici();
            
            
            if (KorIme == null || Lozinka == null || Ime == null || Prezime == null || Email == null || DatRodj == null || FitnesCentri==null)
            {
                ViewBag.Message = $"Molimo popunite polja.";
                    return DodajTrenera();
            }

            foreach (Korisnik k in korisnici)
            {
                if (k.KorIme == KorIme)
                {
                    ViewBag.Message = $"Korisnik sa unesenim korisnickim imenom vec postoji.";
                    return DodajTrenera();
                }
            }

            if (KorIme.Length < 3)
            {
                ViewBag.Message = $"Korsinicko ime mora imati vise od 3 karaktera.";
                return DodajTrenera();
            }
            if (Lozinka.Length < 6)
            {
                ViewBag.Message = $"Lozinka mora da ima bar 6 karaktera.";
                return DodajTrenera();
            }
            if (!Email.Contains("@"))
            {
                ViewBag.Message = $"Nepostojeci email.";
                return DodajTrenera();
            }
            if (DatRodj > DateTime.Now)
            {
                ViewBag.Message = $"Unesite ispravan datum rodjenja.";
                return DodajTrenera();
            }

            Korisnik korisnik = new Korisnik(KorIme, Lozinka, Ime, Prezime, pol, Email, DatRodj, Uloga.trener);
            List<FitnesCentar> centri = FitnesCentarData.GetAllFitnesCentri();
            FitnesCentar fc = centri.Find(k => k.Naziv.Equals(FitnesCentri));
            korisnik.FitnesCentar = fc;
            KorisnikData.DodajKorisnika(korisnik);
            return View("VlasnikCentri");
        }
        public ActionResult Blokiraj(string KorIme)
        {
            List<Korisnik> korisnici = KorisnikData.GetAllKorisnici();
            Korisnik korisnik = korisnici.Find(k=> k.KorIme.Equals(KorIme));
            korisnik.Blokiran = true;
            KorisnikData.Uredikorisnika(korisnik);
            return View("VlasnikCentri");
            
        }
    }
}