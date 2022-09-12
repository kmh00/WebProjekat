using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProjekat.Models
{
    public enum Tip {yoga, kardio, bodyPump }
    public class GrupniTrening
    {
        string naziv;
        Tip tip;
        int trajanje;
        DateTime vreme;
        int maxPosjetilaca;
        List<Korisnik> posjetioci;

        public GrupniTrening(string naziv, Tip tip, int trajanje, DateTime vreme, int maxPosjetilaca, List<Korisnik> posjetioci)
        {
            this.Naziv = naziv;
            this.Tip = tip;
            this.Trajanje = trajanje;
            this.Vreme = vreme;
            this.MaxPosjetilaca = maxPosjetilaca;
            this.Posjetioci = posjetioci;
        }

        public string Naziv { get => naziv; set => naziv = value; }
        public Tip Tip { get => tip; set => tip = value; }
        public int Trajanje { get => trajanje; set => trajanje = value; }
        public DateTime Vreme { get => vreme; set => vreme = value; }
        public int MaxPosjetilaca { get => maxPosjetilaca; set => maxPosjetilaca = value; }
        public List<Korisnik> Posjetioci { get => posjetioci; set => posjetioci = value; }
    }
}