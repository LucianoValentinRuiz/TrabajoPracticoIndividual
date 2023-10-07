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
            List<Funciones> funciones = await query.ToListAsync();

            if (funciones.Count == 0)
            {
                throw new InvalidOperationException("No se encontraron Funciones Existentes");
            }

            // Devuelve la lista de datos en lugar de la consulta IQueryable.
            return funciones.AsQueryable();
        }

        public async Task <IQueryable<Peliculas>> GetPeliculas()
        {
            IQueryable<Peliculas> query =  _context.Peliculas;
            List<Peliculas> peliculas = await query.ToListAsync();

            if (peliculas.Count == 0)
            {
                throw new InvalidOperationException("No se encontraron Peliculas Existentes");
            }

            // Devuelve la lista de datos en lugar de la consulta IQueryable.
            return peliculas.AsQueryable();
        }

    }
}
