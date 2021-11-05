using System;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Configuration;


namespace Challenge_Desafio4
{
  public  class Program
    {

       
        public  static void Main(string[] args)
        {
            
            string JSON = EjecutarAPI.EjecutarWSCurrency();
            dynamic json = JsonConvert.DeserializeObject(JSON);
            JToken JsonFinal = RecorrerJSON(json);
            //GRABAR JON
            var Json = Configuration.GrabarJSON.Instance;
            Json.Save(JsonFinal.ToString());
            Console.WriteLine("Proceso Finalizado");
        }

        public static JToken RecorrerJSON(JToken token)
        {
            List<string> RatioList = new List<string>();
            List<JToken> AddList = new List<JToken>();
            JContainer container = token as JContainer;
            if (container == null) return token;
            foreach (JToken el in container.Children())
            {
                JContainer Hijos = el as JContainer;
                foreach (JToken prop in Hijos.Children())
                {
                    JProperty p = prop as JProperty;
                    if (p.Name == "id")
                    {
                        JProperty P1 = ObtenerToDolar(p.Value.ToString());
                        if (P1!=null)
                        {
                            AddList.Add(P1);
                            
                             RatioList.Add(P1.Value.ToString());
                           
                        }
 
                    }
                
                }
                foreach (JToken el2 in AddList)
                {
                    Hijos.Add(el2);
                }
                AddList.Clear();
              
            }
            var CSV = Configuration.GrabarCSV.Instance;
            CSV.Save(RatioList);
            return token;
        }

        public static JProperty ObtenerToDolar(string COD)
        {
            JProperty p=null;

            

            string JSON = EjecutarAPI.EjecutarWSCurrencyConverter(COD);
            if (JSON == null)
            {
                return p;
            }

            dynamic json = JsonConvert.DeserializeObject(JSON);
            JContainer container = json as JContainer;
            foreach (JToken prop in container.Children())
            {
                 p = prop as JProperty;
                if (p.Name == "ratio")
                {
                    //GRABAR RATIO EN CSV
                    return p;
                }

            }

            return p;
              
        }

    }
}
