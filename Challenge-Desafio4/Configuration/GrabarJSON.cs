using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Configuration;
namespace Challenge_Desafio4.Configuration
{
    class GrabarJSON
    {
        private readonly static GrabarJSON _instance = new GrabarJSON();
        private string _path = ConfigurationManager.AppSettings["PathJson"];
        public static GrabarJSON Instance
        {
            get
            { return _instance; }
        
        }
        private GrabarJSON()
        { 
        
        }

        public void Save(string message)
        {
            File.AppendAllText(_path, message);
        }
    }
}
