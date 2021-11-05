using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using WebAPI___Integracion.Models;
using System.IO;
namespace WebAPI___Integracion.Repositories
{
  public   interface IProcesoRepository
    {
      

        string ProcesarCodigo(String CodProceso);

    }
}
