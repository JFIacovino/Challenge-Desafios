using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Configuration;
namespace Challenge_Desafio4.Configuration
{
    class GrabarCSV
    {
        private readonly static GrabarCSV _instance = new GrabarCSV();
        

        private string _path = ConfigurationManager.AppSettings["PathCSV"];
        public static GrabarCSV Instance
        {
            get
            { return _instance; }

        }
        private GrabarCSV()
        {

        }
        public void Save(List<string> RatioList)
        {

            
            string csv = String.Join(",", RatioList.Select(x => x.ToString().Replace(",",".")).ToArray());
            File.AppendAllText(_path, csv);
        }
    }
}
