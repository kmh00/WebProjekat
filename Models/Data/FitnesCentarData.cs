using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebProjekat.Models.Data
{
    public class FitnesCentarData
    {
        static string filename = "C:/Users/simce/source/repos/WebProjekat/App_Data/FitnesCentri.XML";
        public static List<FitnesCentar> GetAllFitnesCentri()
        {
            List<FitnesCentar> fitnesCentri;
            XmlSerializer xml = new XmlSerializer(typeof(List<FitnesCentar>));
            using (var streamWriter = new StreamReader(filename))
            {
                fitnesCentri = (List<FitnesCentar>)xml.Deserialize(streamWriter);
            }
            return fitnesCentri;
        }
        public static bool DodajFitnesCentar(FitnesCentar centar)
        {
            List<FitnesCentar> centri = GetAllFitnesCentri();
            FitnesCentar f = centri.Find(x => x.Naziv == centar.Naziv);
            if(f!= null)
            {
                return false;
            }
            centri.Add(centar);
            XmlSerializer xml = new XmlSerializer(typeof(List<FitnesCentar>));
            using (var streamWriter = File.Create(filename))
            {
                xml.Serialize(streamWriter, centri);
            }
            return true;
        }
        public static void UrediFitnesCentar(FitnesCentar centar)
        {
            List<FitnesCentar> centri = GetAllFitnesCentri();
            FitnesCentar k = centri.Find(x => x.Naziv == centar.Naziv);
            
            centri.Remove(k);
            centri.Add(centar);
            XmlSerializer xml = new XmlSerializer(typeof(List<FitnesCentar>));
            using (var streamWriter = File.Create(filename))
            {
                xml.Serialize(streamWriter, centri);
            }
            ;
        }

    }
}