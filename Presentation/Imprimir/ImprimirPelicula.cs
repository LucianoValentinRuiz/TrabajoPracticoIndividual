using Aplication.Interface_Service;
using Aplication.Interface_Imprimir;

namespace Presentation.Imprimir
{
    public class ImprimirPelicula :IimprimirPelicula
    {
        public async Task Imprimir_Peliculas(IPeliculasService pel_serv, int id,IGenerosService gen_serv)
        {
            var pel = await pel_serv.GetById(id);
            ImprimirGenero impr_gen = new ImprimirGenero();
            Console.WriteLine("ID: {0}      Titulo: {1}", pel.PeliculaId,pel.Titulo);
            Console.WriteLine("Sinopsis: {0} ", pel.Sinopsis);
            Console.Write("Genero: " );
            impr_gen.Imprimir_Genero(gen_serv, pel.Genero);
            Console.WriteLine();
        }
    }
}
