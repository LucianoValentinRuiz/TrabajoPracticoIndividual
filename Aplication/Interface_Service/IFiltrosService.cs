using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interface_Service
{
    public interface IFIltrosService
    {
        public Task<List<Funciones>> FuncionesFiltro(DateTime? dia, string? titulo, Int32? genero);
    }
}
