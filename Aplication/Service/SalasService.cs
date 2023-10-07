using Aplication.Interface;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Aplication.Interface_Service;

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

        public async Task<Salas> CreateSalas(Salas sal)
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
