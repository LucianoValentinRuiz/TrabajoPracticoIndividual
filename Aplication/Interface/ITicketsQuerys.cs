using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interface
{
    public interface ITicketsQuerys
    {
        public List<Tickets> GetListTickets(int id);
        public Tickets GetTicketsById(Guid id);
    }
}
