using Domain.Entities;
using Aplication.Interface;
using Aplication.DTO;
using Aplication.Interface_Service;
using Aplication.Validation;
using Aplication.Interface_Validation;

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
            ValidationTimeSpan validador = new ValidationTimeSpan();
            TimeSpan horario = validador.validarHorario(fun_dto.horario);
            if (horario == TimeSpan.Zero)
                return null;
            else
            {
                var funciones = new Funciones
                {
                    PeliculaId = fun_dto.pelicula,
                    SalaId = fun_dto.sala,
                    Fecha = fun_dto.fecha,
                    Horario = horario,
                };

                return await _command.InsertFuncion(funciones);
            }

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