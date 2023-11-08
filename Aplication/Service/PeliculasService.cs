using Aplication.Interface;
using Aplication.Interface_Service;
using Domain.Entities;
using Aplication.DTO;

namespace Aplication.Service
{
    public class PeliculasService : IPeliculasService
    {
        private readonly IPeliculasCommand _command;
        private readonly IPeliculasQuerys _query;

        public PeliculasService(IPeliculasCommand command, IPeliculasQuerys query)
        {
            _command = command;
            _query = query;
        }

        public async Task<Peliculas> CreatePeliculas(PeliculaDTO fun)
        {
            var pelicula = new Peliculas
            {
                Titulo = fun.Titulo,
                Sinopsis = fun.Sinopsis,
                Poster = fun.Poster,
                Trailer = fun.Trailer,
                Genero = fun.Genero,
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
        public async Task <Peliculas> GetById(int pelId)
        {
            var pelicula = _query.GetPeliculaById(pelId);
            return pelicula;
        }
        public async Task<Peliculas> ModificarPelicula(int id, PeliculaDTO pelDTO)
        {
            Peliculas pelicula = await _command.UpdatePeliculas(id, pelDTO);
            return pelicula;
        }
    }
}
