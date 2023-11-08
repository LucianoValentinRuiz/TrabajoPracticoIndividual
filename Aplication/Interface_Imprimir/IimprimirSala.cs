using Aplication.Interface_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interface_Imprimir
{
    public interface IimprimirSala
    {
        Task Imprimir_Sala(ISalasService sal_serv, int id);
    }
}
