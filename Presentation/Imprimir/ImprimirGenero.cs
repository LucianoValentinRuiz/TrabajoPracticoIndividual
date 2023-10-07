using System;
using Aplication.Interface_Service;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Presentation.Imprimir
{
    public class ImprimirGenero
    {
        public async Task Imprimir_Genero(IGenerosService gen_serv,int id)
        {
            var genero = await gen_serv.GetById(id);
            Console.WriteLine("ID{0}     Nombre: {1}", genero.GeneroId, genero.Nombre);
        }
    }
}
