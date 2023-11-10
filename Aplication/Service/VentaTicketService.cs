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
    public class VentaTicketService : IVentaTicketService
    {
        private readonly ITicketsService _services;
        private readonly IFuncionesService _funcionesService;
        private readonly ISalasService _salasService;

        public VentaTicketService(ITicketsService services, IFuncionesService funcionesService, ISalasService salasService)
        {
            _services = services;
            _funcionesService = funcionesService;
            _salasService = salasService;
        }

        public async Task<Tickets> Vender(int id,TicketDTO tic)
        {
            int cantidadDisponible = await this.TicketDisponibles(id);
            Tickets result= null;
            if ( cantidadDisponible < tic.cantidad || tic.cantidad == 0)
            {
                return result ;
            }
            else
            {
                for (int i = 0; i < tic.cantidad; i++)
                {
                    Tickets ticketNuevo = await _services.CreatTickets(id, tic);
                    result = ticketNuevo;
                }
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
