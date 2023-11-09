using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplication.DTO;
using Domain.Entities;

namespace Aplication.Interface_Service
{
    public interface IVentaTicketService
    {
        public Task<Tickets> Vender(int id, TicketDTO tic);
        public Task<int> TicketDisponibles(int id);
    }
}
