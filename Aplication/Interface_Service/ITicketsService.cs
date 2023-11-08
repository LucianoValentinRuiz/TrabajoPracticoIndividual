using Aplication.DTO;
using Domain.Entities;

namespace Aplication.Interface_Service
{
    public interface ITicketsService
    {
        public  Task<Tickets> CreatTickets(TicketDTO tic);
        public void DeleteTickets(Guid ticId);
        public Task <List<Tickets>> GetAll(int id);
        public Tickets GetById(Guid ticId);

    }
}
