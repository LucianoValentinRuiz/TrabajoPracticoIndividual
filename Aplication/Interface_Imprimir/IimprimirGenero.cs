using Aplication.Interface_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interface_Imprimir
{
    public interface IimprimirGenero
    {
        Task Imprimir_Genero(IGenerosService gen_serv, int id);
    }
}
