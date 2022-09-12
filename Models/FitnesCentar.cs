using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProjekat.Models
{
    public class FitnesCentar
    {
        string naziv;
        string adresa;
        Korisnik vlasnik;
        int cenaMes;
        int cenaGod;
        int cenaDan;
        int cenaGrupa;
        int cenaPersonal;

        public FitnesCentar(string naziv, string adresa, Korisnik vlasnik, int cenaMes, int cenaGod, int cenaDan, int cenaGrupa, int cenaPersonal)
        {
            this.Naziv = naziv;
            this.Adresa = adresa;
            this.Vlasnik = vlasnik;
            this.CenaMes = cenaMes;
            this.CenaGod = cenaGod;
            this.CenaDan = cenaDan;
            this.CenaGrupa = cenaGrupa;
            this.CenaPersonal = cenaPersonal;
        }

        public string Naziv { get => naziv; set => naziv = value; }
        public string Adresa { get => adresa; set => adresa = value; }
        public Korisnik Vlasnik { get => vlasnik; set => vlasnik = value; }
        public int CenaMes { get => cenaMes; set => cenaMes = value; }
        public int CenaGod { get => cenaGod; set => cenaGod = value; }
        public int CenaDan { get => cenaDan; set => cenaDan = value; }
        public int CenaGrupa { get => cenaGrupa; set => cenaGrupa = value; }
        public int CenaPersonal { get => cenaPersonal; set => cenaPersonal = value; }
    }
}