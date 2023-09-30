using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interface_Service
{
    public interface ITicketsService
    {
        public  Task<Tickets> CreatTickets(Tickets tic);
        public void DeleteTickets(Guid ticId);
        public Task <List<Tickets>> GetAll(int funcionid);
        public Tickets GetById(Guid ticId);

    }
}
