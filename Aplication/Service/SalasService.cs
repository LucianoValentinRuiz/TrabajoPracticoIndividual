using Aplication.Interface;
using Domain.Entities;
using Aplication.Interface_Service;
using Aplication.DTO;

namespace Aplication.Service
{
    public class SalasService : ISalasService
    {
        private readonly ISalasCommand _command;
        private readonly ISalasQuerys _query;

        public SalasService(ISalasCommand command, ISalasQuerys query)
        {
            _command = command;
            _query = query;
        }

        public async Task<Salas> CreateSalas(SalaDTO sal)
        {
            var salas = new Salas
            {
                Nombre= sal.Nombre,
                Capacidad = sal.Capacidad,
            };
            await _command.InsertSalas(salas);
            return salas;
        }
        public void DeleteGenero(int salId)
        {
            _command.RemoveSalas(salId);
        }
        public List<Salas> GetAll()
        {
            var salas = _query.GetListSalas();
            return salas;
        }
        public async Task <Salas> GetById(int salId)
        {
            var salas = _query.GetSalasById(salId);
            return salas;
        }
    }
}
