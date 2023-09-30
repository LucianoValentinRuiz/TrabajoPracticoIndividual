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
    public class SalasQuerys : ISalasQuerys
    {
        private readonly CineDBContext _context;
        public SalasQuerys(CineDBContext context)
        {
            _context = context;
        }

        public List<Salas> GetListSalas()
        {
            IQueryable<Salas> query = _context.Salas;
            var sal = query.ToList();
            return sal;
        }

        public Salas GetSalasById(int id)
        {
            IQueryable<Salas> query = _context.Salas;
            var tic = (Salas)query.FirstOrDefault(x => x.SalaId == id);
            return tic;
        }
    }
}
