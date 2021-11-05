using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
namespace Challenge_Desafio2.Repository
{
   public interface IBusquedaRepository
    {

        JToken ProcesarBusqueda(String Termino);
        JToken RemoveFields( JToken token, List<string> fields,string Padre);
    }
}
