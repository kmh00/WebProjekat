﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebProjekat.Models.Data
{
    public class GrupniTreningData
    {
        static string filename = "C:/Users/simce/source/repos/WebProjekat/App_Data/GrupniTreninzi.XML";

        public static List<GrupniTrening> TreninziFitnesCentar(string FitnesCentar)
            {
            List<GrupniTrening> list;
            List<GrupniTrening> treninzi = new List<GrupniTrening>();
            XmlSerializer xml = new XmlSerializer(typeof(List<GrupniTrening>));
            using (var streamWriter = new StreamReader(filename))
            {
                list = (List<GrupniTrening>)xml.Deserialize(streamWriter);
            }
            foreach (var i in list)
            {
                if (i.FitnesCentar.Naziv == FitnesCentar)
                    treninzi.Add(i);
            }

            return treninzi;
            }
    }
}