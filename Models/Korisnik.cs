using Antlr.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProjekat.Models
{
    public enum Uloga { posetilac, trener, vlasnik}
    public enum Pol { Muski, Zenski}
    public class Korisnik
    {
        string KorIme;
        string lozinka;
        string ime;
        string prezime;
        Pol pol;
        string email;
        DateTime datumRodj;
        Uloga uloga;
        List<string> GrupniTren;
        List<string> trenira;
        FitnesCentar fitnesCentar;
        FitnesCentar vlasnik;
        public Korisnik() { }

        public Korisnik(string korIme, string lozinka, string ime, string prezime, Pol pol, string email, DateTime datumRodj, Uloga uloga)
        {
            this.KorIme1 = korIme;
            this.Lozinka = lozinka;
            this.Ime = ime;
            this.Prezime = prezime;
            this.Pol = pol;
            this.Email = email;
            this.DatumRodj = datumRodj;
            this.Uloga = uloga;
            
            if(uloga == Uloga.posetilac)
            {
                List<string> GrupniTren = new List<string>();
            }
            else if(uloga == Uloga.trener)
            {
                List<string> trenira = new List<string>();
            }

        }

        public string KorIme1 { get => KorIme; set => KorIme = value; }
        public string Lozinka { get => lozinka; set => lozinka = value; }
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public Pol Pol { get => pol; set => pol = value; }
        public string Email { get => email; set => email = value; }
        public DateTime DatumRodj { get => datumRodj; set => datumRodj = value; }
        public Uloga Uloga { get => uloga; set => uloga = value; }
        public List<string> GrupniTren1 { get => GrupniTren; set => GrupniTren = value; }
        public List<string> Trenira { get => trenira; set => trenira = value; }
        public FitnesCentar FitnesCentar { get => fitnesCentar; set => fitnesCentar = value; }
        public FitnesCentar Vlasnik { get => vlasnik; set => vlasnik = value; }
    }
}