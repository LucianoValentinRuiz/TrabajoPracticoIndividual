using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Aplication.Interface_Service
{
    public interface IFuncionesService
    {
        Task<Funciones> CreateFuncion(Funciones fun_request);
        Task<Funciones> DeleteFuncion(int funId);
        public List<Funciones> GetAll();
        public Task <Funciones> GetById(int funId);

    }
}
