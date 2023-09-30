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
    public class TicketsQuerys : ITicketsQuerys
    {
        private readonly CineDBContext _context;
        public TicketsQuerys(CineDBContext context)
        {
            _context = context;
        }

        public List<Tickets> GetListTickets()
        {
            IQueryable<Tickets> query = _context.Tickets;
            var tic = query.ToList();
            return tic;
        }

        public Tickets GetTicketsById(Guid id)
        {
            IQueryable<Tickets> query = _context.Tickets;
            var tic = (Tickets)query.FirstOrDefault(x => x.TicketId == id);
            return tic;
        }
    }
}
