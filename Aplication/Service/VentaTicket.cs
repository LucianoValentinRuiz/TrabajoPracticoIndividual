using Aplication.DTO;
using Aplication.Interface_Service;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Service
{
    public class VentaTicket : IVentaTicket
    {
        private readonly ITicketsService _services;
        private readonly IFuncionesService _funcionesService;
        private readonly ISalasService _salasService;

        public VentaTicket(ITicketsService services, IFuncionesService funcionesService, ISalasService salasService)
        {
            _services = services;
            _funcionesService = funcionesService;
            _salasService = salasService;
        }

        public async Task<Tickets> Vender(int id,TicketDTO tic)
        {
            int cantidadDisponible = await this.TicketDisponibles(id);
            Tickets result;
            if ( cantidadDisponible < tic.cantidad || _funcionesService.GetById(tic.funcionId) == null)
            {
                return result = null;
            }
            else
            {
                result = await _services.CreatTickets(tic);
                return result;
            }
        }
        public async Task<int> TicketDisponibles(int id)
        {
            int cantidad;
            List<Tickets> lista = await _services.GetAll(id);
            Funciones fun = await _funcionesService.GetById(id);
            Salas sala = await _salasService.GetById(fun.SalaId);
            return cantidad = sala.Capacidad - lista.Count;

        }
    }
}
