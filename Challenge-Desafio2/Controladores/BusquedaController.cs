using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Challenge_Desafio2.Repository;

using Newtonsoft.Json;
namespace Challenge_Desafio2.Controladores
{
   
    [Produces("application/json")]

    [Route("MyRestFulApp/")]
    public class BusquedaController : Controller
    {
        IBusquedaRepository BusquedaRepository;
        public BusquedaController(IBusquedaRepository _ProcesoRepository)
        {
            BusquedaRepository = _ProcesoRepository;
        }



        [HttpGet("Busqueda/{TERMINO}")]


        public IActionResult ProcesarCodigo(String TERMINO)
        {
            try
            {

                object result = BusquedaRepository.ProcesarBusqueda(TERMINO);
                return Ok(result);
            }
            catch (Exception ex)
            { return Ok ("Error"); }




        }





















    }
}
