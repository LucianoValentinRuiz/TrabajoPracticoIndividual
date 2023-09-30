using Aplication.Interface;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Service
{
    public class PeliculasService
    {
        private readonly IPeliculasCommand _command;
        private readonly IPeliculasQuerys _query;

        public PeliculasService(IPeliculasCommand command, IPeliculasQuerys query)
        {
            _command = command;
            _query = query;
        }

        public async Task<Peliculas> CreatePeliculas(Peliculas fun_request)
        {
            var pelicula = new Peliculas
            {
                //Titulo = fun_request.Titulo,
                //Sinopsis = fun_request.Sinopsis,
                //Poster = fun_request.Poster,
                //Trailer = fun_request.Trailer,
                //GenerosID = fun_request.GenerosID,
            };
            await _command.InsertPeliculas(pelicula);
            return pelicula;
        }
        public void DeletePeliculas(int pelId)
        {
            _command.RemovePeliculas(pelId);
        }
        public List<Peliculas> GetAll()
        {
            var pelicula = _query.GetListPeliculas();
            return pelicula;
        }
        public Peliculas GetById(int pelId)
        {
            var pelicula = _query.GetPeliculaById(pelId);
            return pelicula;
        }
        public bool PeliculaExiste(int pelId, string titulo)//retorna una lista de peliculas
        {                                                              //con el mismo id y string ingresados
            var peliculas = _query.GetPeliculasByIdAndTitulo(pelId, titulo);
            if (peliculas.Count == 0) { return false; }
            else { return true; }
        }
        public void ImprimirPeliculas(int id)//imprime datos utiles para el usuario
        {                                                       //sobre las peliculas
            Peliculas pel = this.GetById(id);
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - -");
                Console.WriteLine("ID: {0}", pel.PeliculaId);   //imprimo el Id
                Console.WriteLine("Titulo {0}",pel.Titulo);     //imprimo el titulo
                //new GenerosService().ImprimirNombre(pel.Genero);//invoco GenerosService para imprimir el genero
                Console.WriteLine("Sinopsis: {0} ",pel.Sinopsis);//imprimo la sinopsis
                Console.WriteLine();
        }
        public void ImprimirTitulo(int id)   //imprime solo el titulo
        {
                Console.WriteLine("Titulo: {0}",this.GetById(id).Titulo);
        }

    }
}
