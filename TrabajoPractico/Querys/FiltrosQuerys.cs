using Aplication.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoPractico;

namespace Infrastructure.Querys
{
    public class FiltrosQuerys : IFiltrosQuerys
    {
        private readonly CineDBContext _context;
        public FiltrosQuerys(CineDBContext context)
        {
            _context = context;
        }
        public async Task <IQueryable<Funciones>> GetFunciones()
        {
            IQueryable<Funciones> query = _context.Funciones;
            return query;
        }

        public async Task <IQueryable<Peliculas>> GetPeliculas()
        {
            IQueryable<Peliculas> query =  _context.Peliculas;
            return query;
        }

    }
}
