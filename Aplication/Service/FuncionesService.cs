using Domain.Entities;
using Aplication.Interface;
using Aplication.DTO;
using Aplication.Interface_Service;

namespace Aplication.Service
{
    public class FuncionesService : IFuncionesService
    {
        private readonly IFuncionesCommand _command;
        private readonly IFuncionesQuerys _query;

        public FuncionesService(IFuncionesCommand command, IFuncionesQuerys query)
        {
            _command = command;
            _query = query;
        }

        public async Task<Funciones> CreateFuncion(FuncionDTO fun_dto) {
            var funciones = new Funciones
            {
                PeliculaId = fun_dto.PeliculaId,
                SalaId = fun_dto.SalaId,
                Fecha = fun_dto.Fecha,
                Horario =fun_dto.Horario,
            };

            return await _command.InsertFuncion(funciones);

        }
        public async Task<Funciones> DeleteFuncion(int funId) {
            return await _command.RemoveFuncion(funId);
        }
        public List<Funciones> GetAll() {
            var funcion = _query.GetListFunciones();
            return funcion;       
         }
        public async Task <Funciones> GetById (int funId) {
            var funcion =  _query.GetFuncionById(funId);
            return funcion;
        }
    }
}