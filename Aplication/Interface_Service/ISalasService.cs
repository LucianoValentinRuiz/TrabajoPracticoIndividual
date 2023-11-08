using Aplication.DTO;
using Domain.Entities;

namespace Aplication.Interface_Service
{
    public interface ISalasService
    {
        public Task<Salas> CreateSalas(SalaDTO sal);
        public void DeleteGenero(int salId);
        public List<Salas> GetAll();
        public Task <Salas> GetById(int salId);
    }
}
