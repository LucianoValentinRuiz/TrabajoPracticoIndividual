
using Aplication.Interface;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Service
{
    public class TicketsService
    {
        private readonly ITicketsCommand _command;
        private readonly ITicketsQuerys _query;

        public TicketsService(ITicketsCommand command, ITicketsQuerys query)
        {
            _command = command;
            _query = query;
        }

        public async Task<Tickets> CreatTickets(Tickets tic)
        {
            var tickets = new Tickets
            {
                Usuario = tic.Usuario,
            };
            await _command.InsertTickets(tickets);
            return tickets;
        }
        public void DeleteTickets(Guid ticId)
        {
            _command.RemoveTickets(ticId);
        }
        public List<Tickets> GetAll()
        {
            var tickets = _query.GetListTickets();
            return tickets;
        }
        public Tickets GetById(Guid ticId)
        {
            var ticket = _query.GetTicketsById(ticId);
            return ticket;
        }
    }
}
