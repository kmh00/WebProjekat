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

    }
}