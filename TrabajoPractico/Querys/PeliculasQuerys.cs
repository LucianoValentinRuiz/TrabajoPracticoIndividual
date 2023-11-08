using Aplication.Interface;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoPractico;

namespace Infraestructure.Querys
{
    public class PeliculasQuerys : IPeliculasQuerys
    {
        private readonly CineDBContext _context;
        public PeliculasQuerys(CineDBContext context)
        {
            _context = context;
        }

        public List<Peliculas> GetListPeliculas()
        {
            IQueryable<Peliculas> query = _context.Peliculas;
            var pel = query.ToList();
            return pel;
        }

        public Peliculas GetPeliculaById(int id)
        {
            IQueryable<Peliculas> query = _context.Peliculas;
            var pel = (Peliculas)query.FirstOrDefault(x => x.PeliculaId == id);
            return pel;
        }
    }
}