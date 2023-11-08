using Domain.Entities;
using Aplication.DTO;

namespace Aplication.Interface_Service
{
    public interface IGenerosService
    {
        public  Task<Generos> CreateGenero(GeneroDTO gen);
        public void DeleteGenero(int genId);
        public List<Generos> GetAll();
        public Task <Generos> GetById(int genId);
    }
}
