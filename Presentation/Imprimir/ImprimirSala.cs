using System;
using Aplication.Interface_Service;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Imprimir
{
    public class ImprimirSala
    {
        public async Task Imprimir_Sala(ISalasService sal_serv,int id)
        {
            var sala = await sal_serv.GetById(id);
            Console.WriteLine("ID{0}     Nombre: {1}", sala.SalaId, sala.Nombre);
        }
    }
}
