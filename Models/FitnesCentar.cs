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
        int godina;
        Korisnik vlasnik;
        int cenaMes;
        int cenaGod;
        int cenaDan;
        int cenaGrupa;
        int cenaPersonal;

        public FitnesCentar(string naziv, string adresa, int godina, Korisnik vlasnik, int cenaMes, int cenaGod, int cenaDan, int cenaGrupa, int cenaPersonal)
        {
            this.naziv = naziv;
            this.adresa = adresa;
            this.godina = godina;
            this.vlasnik = vlasnik;
            this.cenaMes = cenaMes;
            this.cenaGod = cenaGod;
            this.cenaDan = cenaDan;
            this.cenaGrupa = cenaGrupa;
            this.cenaPersonal = cenaPersonal;
        }
        public FitnesCentar() { }

        public string Naziv { get => naziv; set => naziv = value; }
        public string Adresa { get => adresa; set => adresa = value; }
        public Korisnik Vlasnik { get => vlasnik; set => vlasnik = value; }
        public int CenaMes { get => cenaMes; set => cenaMes = value; }
        public int CenaGod { get => cenaGod; set => cenaGod = value; }
        public int CenaDan { get => cenaDan; set => cenaDan = value; }
        public int CenaGrupa { get => cenaGrupa; set => cenaGrupa = value; }
        public int CenaPersonal { get => cenaPersonal; set => cenaPersonal = value; }
        public int Godina { get => godina; set => godina = value; }
    }
}