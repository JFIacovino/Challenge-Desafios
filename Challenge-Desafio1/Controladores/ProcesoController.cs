using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI___Integracion.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Xml;
using WebAPI___Integracion.Models;
using System.Text.Json.Serialization;
using Newtonsoft.Json;


namespace WebAPI___Integracion.Controladores
{
    [Produces("application/xml")]
    
    [Route("MyRestFulApp/")]
    public class ProcesoController : Controller
    {
        IProcesoRepository ProcesoRepository;
        public ProcesoController(IProcesoRepository _ProcesoRepository)
        {
            ProcesoRepository = _ProcesoRepository;
        }

      

        [HttpGet("Paises/{PAIS}")]


        public string ProcesarCodigo(String PAIS)
        {
            try
            {
          
                string result = ProcesoRepository.ProcesarCodigo(PAIS);



                //return new ContentResult

                //{
                //    ContentType = "application/xml",
                //    Content = result.ToString(),
                //    StatusCode = 200

                //};
                return result.ToString();
            }
            catch (Exception ex)
            { return "Error"; }




        }


      




       






       



        


    }
}
