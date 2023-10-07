using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interface
{
    public interface IFiltrosQuerys
    {
        public Task<IQueryable<Funciones>> GetFunciones();
        public Task<IQueryable<Peliculas>> GetPeliculas();
    }
}
