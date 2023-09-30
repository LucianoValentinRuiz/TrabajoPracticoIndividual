using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interface
{
    public interface ITicketsCommand
    {
        public Task InsertTickets(Tickets tic);
        public Task RemoveTickets(Guid ticId);
    }
}
