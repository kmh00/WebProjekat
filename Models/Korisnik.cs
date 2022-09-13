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
        string korIme;
        string lozinka;
        string ime;
        string prezime;
        Pol pol;
        string email;
        DateTime datumRodj;
        Uloga uloga;
        List<GrupniTrening> GrupniTren;
        List<GrupniTrening> trenira;
        FitnesCentar fitnesCentar;
        List<FitnesCentar> vlasnik;
        bool blokiran;
        public Korisnik() { }

        public Korisnik(string korIme, string lozinka, string ime, string prezime, Pol pol, string email, DateTime datumRodj, Uloga uloga)
        {
            this.KorIme = korIme;
            this.Lozinka = lozinka;
            this.Ime = ime;
            this.Prezime = prezime;
            this.Pol = pol;
            this.Email = email;
            this.DatumRodj = datumRodj;
            this.Uloga = uloga;
            this.blokiran = false;
            
            if(uloga == Uloga.posetilac)
            {
                List<GrupniTrening> GrupniTren = new List<GrupniTrening>();
            }
            else if(uloga == Uloga.trener)
            {
                List<GrupniTrening> trenira = new List<GrupniTrening>();
                this.FitnesCentar = null;
            }
            if(uloga == Uloga.vlasnik)
            {
                List<FitnesCentar> vlasnik = new List<FitnesCentar>();
            }
            

        }

        public string KorIme { get => korIme; set => korIme = value; }
        public string Lozinka { get => lozinka; set => lozinka = value; }
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public Pol Pol { get => pol; set => pol = value; }
        public string Email { get => email; set => email = value; }
        public DateTime DatumRodj { get => datumRodj; set => datumRodj = value; }
        public Uloga Uloga { get => uloga; set => uloga = value; }
        public List<GrupniTrening> GrupniTren1 { get => GrupniTren; set => GrupniTren = value; }
        public List<GrupniTrening> Trenira { get => trenira; set => trenira = value; }
        public FitnesCentar FitnesCentar { get => fitnesCentar; set => fitnesCentar = value; }
        public List<FitnesCentar> Vlasnik { get => vlasnik; set => vlasnik = value; }
        public bool Blokiran { get => blokiran; set => blokiran = value; }
    }
}