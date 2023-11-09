
using Aplication.DTO;
using Aplication.Interface;
using Aplication.Interface_Service;
using Domain.Entities;

namespace Aplication.Service
{
    public class TicketsService : ITicketsService
    {
        private readonly ITicketsCommand _command;
        private readonly ITicketsQuerys _query;

        public TicketsService(ITicketsCommand command, ITicketsQuerys query)
        {
            _command = command;
            _query = query;
        }

        public async Task<Tickets> CreatTickets(int id,TicketDTO tic)
        {
            var tickets = new Tickets
            {
                FuncionId = id,
                Usuario = tic.usuario,
            };
            await _command.InsertTickets(tickets);
            return tickets;
        }
        public void DeleteTickets(Guid ticId)
        {
            _command.RemoveTickets(ticId);
        }
        public async Task <List<Tickets>> GetAll(int id)
        {
            var tickets = _query.GetListTickets(id);
            return tickets;
        }
        public Tickets GetById(Guid ticId)
        {
            var ticket = _query.GetTicketsById(ticId);
            return ticket;
        }
    }
}
