using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebProjekat.Models.Data
{
    public class KorisnikData
    {
        static string filename = "C:/Users/simce/source/repos/WebProjekat/App_Data/Korisnici.XML";
        public static List<Korisnik> GetAllKorisnici()
        {
            List<Korisnik> korisnici;
            XmlSerializer xml = new XmlSerializer(typeof(List<Korisnik>));
            using (var streamWriter = new StreamReader(filename))
            {
                korisnici = (List<Korisnik>)xml.Deserialize(streamWriter);
            }
            return korisnici;
        }
        public static void DodajKorisnika(Korisnik korisnik)
        {
            List<Korisnik> korisnici = GetAllKorisnici();
            korisnici.Add(korisnik);
            XmlSerializer xml = new XmlSerializer(typeof(List<Korisnik>));
            using (var streamWriter = File.Create(filename))
            {
                xml.Serialize(streamWriter, korisnici);
            }
        }

        public static void Uredikorisnika(Korisnik korisnik)
        {
            List<Korisnik> korisnici = GetAllKorisnici();
            Korisnik korisnik1 = korisnici.Find(k => k.KorIme == korisnik.KorIme);
            korisnici.Remove(korisnik1);
            korisnici.Add(korisnik);
            XmlSerializer xml = new XmlSerializer(typeof(List<Korisnik>));
            using (var streamWriter = File.Create(filename))
            {
                xml.Serialize(streamWriter, korisnici);
            }
        }
    }
        
}