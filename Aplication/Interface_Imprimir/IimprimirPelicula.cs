using Aplication.Interface_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interface_Imprimir
{
    public interface IimprimirPelicula
    {
        Task Imprimir_Peliculas(IPeliculasService pel_serv, int id, IGenerosService gen_serv);
    }
}
