using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Configuration;
namespace Challenge_Desafio4
{
   public class EjecutarAPI
    {

        public static string EjecutarWSCurrency()
        {

           // var url = "https://api.mercadolibre.com/currencies/";
            var url = ConfigurationManager.AppSettings["APICurrencys"];
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string resp = reader.ReadToEnd();



            return resp;
        }

        public static string EjecutarWSCurrencyConverter(string COD)
        {
           
           
            try
            {
                //  var url = $"{"https://api.mercadolibre.com/currency_conversions/search?from="}{COD}{"&to=USD"}";
                var url = ConfigurationManager.AppSettings["APICC1"]+ COD+"&"+ ConfigurationManager.AppSettings["APICC2"];
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "GET";
                request.ContentType = "application/x-www-form-urlencoded";
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string resp = reader.ReadToEnd();
                return resp;
            }
            catch (Exception ex)
            {
                return null;
            }

     ;



         
        }


    }
}
