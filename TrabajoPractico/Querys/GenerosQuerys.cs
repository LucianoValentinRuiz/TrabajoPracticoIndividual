using Aplication.Interface;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoPractico;

namespace Aplication.Querys
{
        public class GenerosQuerys : IGenerosQuerys
        {
            private readonly CineDBContext _context;

            public GenerosQuerys(CineDBContext context)
            {
                _context = context;
            }

            public Generos GetGenerosById(int id)
            {
            IQueryable<Generos> query = _context.Generos;
            var gen = (Generos)query.FirstOrDefault(x => x.GeneroId == id);
            return gen;
            }

            public List<Generos> GetListGeneros()
            {
            IQueryable<Generos> query = _context.Generos;
            var gen = query.ToList();
            return gen;
            }
        }
}
