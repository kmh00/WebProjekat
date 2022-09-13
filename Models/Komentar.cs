using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProjekat.Models
{
    public class Komentar
    {
        Korisnik posetilac;
        FitnesCentar fitnesCentar;
        string tekst;
        int ocena;

        public Komentar(Korisnik posetilac, FitnesCentar fitnesCentar, string tekst, int ocena)
        {
            this.Posetilac = posetilac;
            this.FitnesCentar = fitnesCentar;
            this.Tekst = tekst;
            this.Ocena = ocena;
        }

        public Korisnik Posetilac { get => posetilac; set => posetilac = value; }
        public FitnesCentar FitnesCentar { get => fitnesCentar; set => fitnesCentar = value; }
        public string Tekst { get => tekst; set => tekst = value; }
        public int Ocena { get => ocena; set => ocena = value; }
    }
}