using Aplication.Interface_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Imprimir
{
    public class ImprimirFuncion
    {
        public async Task Imprimir_Funcion(IFuncionesService fun_serv,int id,IPeliculasService pel_serv,
                                     IGenerosService gen_serv,ISalasService sal_serv)
        {
            var fun = await fun_serv.GetById(id);

            ImprimirPelicula impr_pel = new ImprimirPelicula();
            ImprimirSala impr_sal = new ImprimirSala();

            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            Console.WriteLine("Fecha: {0}", fun.Fecha.ToString("ddd,dd,MM"));
            Console.WriteLine("Horario: {0}", fun.Horario);
            Console.WriteLine("Sala: {0}",impr_sal.Imprimir_Sala(sal_serv,fun.SalaId));
            Console.WriteLine("Pelicula: {0}",impr_pel.Imprimir_Peliculas(pel_serv,fun.PeliculaId,gen_serv));
            Console.WriteLine();
        }
    }
}
