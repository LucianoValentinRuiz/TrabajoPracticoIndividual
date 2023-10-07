using System;
using Aplication.Interface_Service;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Presentation.Models;

namespace Presentation.Imprimir
{
    public class ImprimirPelicula
    {
        public async Task Imprimir_Peliculas(IPeliculasService pel_serv, int id,IGenerosService gen_serv)
        {
            var pel = await pel_serv.GetById(id);
            ImprimirGenero impr_gen = new ImprimirGenero();
            Console.WriteLine("ID: {0}", pel.PeliculaId);   //imprimo el Id
            Console.WriteLine("Titulo: {0}", pel.Titulo);   //imprimo el titulo
            Console.WriteLine("Genero:  {0}", impr_gen.Imprimir_Genero(gen_serv, pel.Genero));
            Console.WriteLine("Sinopsis: {0} ", pel.Sinopsis);//imprimo la sinopsis
            Console.WriteLine();
        }
    }
}
