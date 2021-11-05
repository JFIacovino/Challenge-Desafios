using Dapper;
using Oracle.ManagedDataAccess.Client;
using System.IO;
using System;
using System.Net.Http;
using System.Net;
using System.Xml;
using System.Data;
using System.Text;

using System.IO.Compression;

using System.Transactions;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
using System.Data.SqlClient;
using System.Xml.Linq;
using Aspose.Pdf;
using System.Configuration;
using System.Text.Encodings;
using WebAPI___Integracion.Models;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Cryptography;


using Renci.SshNet;
using System.Runtime.Serialization;
 using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Extensions.Options;
using WebAPI___Integracion.Models;

namespace WebAPI___Integracion.Repositories
{
    

    public class ProcesoRepository : IProcesoRepository
    {


        private readonly IOptions<PaisesConf> _config;
        
       
        public ProcesoRepository( IOptions<PaisesConf> config)
        {
            
            _config = config;

        }
        




        public string ProcesarCodigo(String PAIS)
            {
            List<String> ListaError = _config.Value.PaisesError.Split(";").ToList<string>();
            List<String> ListaOK = _config.Value.PaisesOK.Split(";").ToList<string>();

            if (ListaError.Contains(PAIS))
            {
                return "error 401 unauthorized de http";
            }
            else
            {
                if (ListaOK.Contains(PAIS))
                {
                    return EjecutarWS(PAIS);
                }
                else
                {
                    return "PAIS NO CONTEMPLADO";
                }
            
            }

          


        }

        public string EjecutarWS(string Pais)
        {
            var url = $"https://api.mercadolibre.com/classified_locations/countries/{Pais}";
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string resp = reader.ReadToEnd();

            return resp;

        }

    }
}

