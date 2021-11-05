using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Challenge_Desafio2.Models;
using Microsoft.Extensions.Options;
namespace Challenge_Desafio2.Repository
{
    public class BusquedaRepository:IBusquedaRepository
    {


        private readonly IOptions<Conf> _config;


        public BusquedaRepository(IOptions<Conf> config)
        {

            _config = config;

        }



        public JToken ProcesarBusqueda(String Termino)
        {

            string JSON = EjecutarWS(Termino);
            dynamic json = JsonConvert.DeserializeObject(JSON);
            List<String> ListaHijos = _config.Value.Hijos.Split(",").ToList<string>();
            string Nodo = _config.Value.Padre.ToString();
            JToken JsonFinal = RemoveFields(json, ListaHijos,Nodo);

            return JsonFinal;
        
        }
        public string EjecutarWS(string Termino)
        {
            
            var url = $"{_config.Value.PathML.ToString()}{Termino}";
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string resp = reader.ReadToEnd();

           
           
            return resp;
        }
        public  JToken RemoveFields(JToken token, List<string> fields,string Padre)
        {
            JContainer container = token as JContainer;
            if (container == null) return token;
            List<JToken> removeList = new List<JToken>();
            foreach (JToken el in container.Children())
            {
                JProperty p = el as JProperty;
                if(p.Name==Padre)
                {
                   JContainer Hijos = p as JContainer;
                    foreach (JContainer GrupoArray in p.Children())
                    {
                        foreach (JContainer Array in GrupoArray.Children())
                        {
                            foreach (JToken prop in Array.Children())
                            {
                                JProperty p2 = prop as JProperty;
                                if (!fields.Contains(p2.Name))
                                { removeList.Add(prop); }
                            }
                            foreach (JToken el2 in removeList)
                            {
                                el2.Remove();
                            }
                            removeList.Clear();
                        }

                    }




                }
          
            }

            return token;
        }
    }
}
