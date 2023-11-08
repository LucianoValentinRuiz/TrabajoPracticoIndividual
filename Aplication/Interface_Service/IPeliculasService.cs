
using Domain.Entities;
using Aplication.DTO;

namespace Aplication.Interface_Service
{
    public interface IPeliculasService
    {
        Task<Peliculas> CreatePeliculas(PeliculaDTO pel_DTO);
        void DeletePeliculas(int pelId);
        List<Peliculas> GetAll();
        Task <Peliculas> GetById(int pelId);
        public Task<Peliculas> ModificarPelicula(int id, PeliculaDTO pelDTO);
    }
}
