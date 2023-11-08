using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interface
{
    public interface IFuncionesCommand
    {
        public Task<Funciones> InsertFuncion(Funciones fun);
        public Task<Funciones> RemoveFuncion(int funId);
    }
}
