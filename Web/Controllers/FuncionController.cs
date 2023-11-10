using Aplication.DTO;
using Aplication.Models;
using Aplication.Interface;
using Aplication.Interface_Mappers;
using Aplication.Interface_Service;
using Aplication.Interface_Validation;
using Aplication.Service;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Aplication.Validation;

namespace Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FuncionController : ControllerBase
    {
        private readonly IPeliculasService _peliculasService;
        private readonly ISalasService _salasService;
        private readonly IGenerosService _generosService;
        private readonly IFuncionesService _funcionesService;
        private readonly IValidationDatetime _validation;
        private readonly IFIltrosService _filtrosService;
        private readonly IVentaTicketService _ventaTicketService;
        private readonly IFuncionMapper _funcionMapper;
        private readonly ITicketMapper _ticketMapper;

        public FuncionController(IPeliculasService peliculasService, ISalasService salasService, IGenerosService generosService, IFuncionesService funcionesService, IValidationDatetime validation, IFIltrosService filtrosService, IVentaTicketService ventaTicketService, IFuncionMapper funcionMapper, ITicketMapper ticketMapper)
        {
            _peliculasService = peliculasService;
            _salasService = salasService;
            _generosService = generosService;
            _funcionesService = funcionesService;
            _validation = validation;
            _filtrosService = filtrosService;
            _ventaTicketService = ventaTicketService;
            _funcionMapper = funcionMapper;
            _ticketMapper = ticketMapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string? fecha, string? titulo, int? genero)
        {
            List<Funciones> funciones = new List<Funciones>();
            funciones = await _filtrosService.FuncionesFiltro(_validation.IngresarFecha(fecha), titulo, genero);
            if (funciones.Count != 0)
            {
                var resultados = new List<CreateFuncionCompletaRequest>();
                foreach (Funciones fun in funciones)
                {
                    var pelicula = await _peliculasService.GetById(fun.PeliculaId);
                    var sala = await _salasService.GetById(fun.SalaId);
                    var gen = await _generosService.GetById(pelicula.Genero);
                    var result = await _funcionMapper.createResponse(fun, pelicula, sala, gen);
                    resultados.Add(result);
                }
                return Ok(resultados);
            }
            else
            {
                var result = new
                {
                    message = "No se encontraron funciones que cumplan con los datos ingresados."
                };
                return BadRequest(result);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateFuncion(FuncionDTO funDTO)
        {
            var pelicula = await _peliculasService.GetById(funDTO.pelicula);
            var sala = await _salasService.GetById(funDTO.sala);
            var genero = await _generosService.GetById(pelicula.Genero);
            ValidationTimeSpan validador = new ValidationTimeSpan();
            TimeSpan horario = validador.validarHorario(funDTO.horario);
            if (pelicula == null || sala == null || genero == null || horario == TimeSpan.Zero)
            {
                var result = new
                {
                    message = "Los datos ingresados no son validos"
                };
                return BadRequest(result);
            }
            else
            {
                Funciones funComparar = await _filtrosService.FuncionesFiltroUltimaSala(funDTO.sala);
                var horaDiferencia = funComparar.Horario - horario;
                var horaReglamentaria = TimeSpan.FromHours(2) + TimeSpan.FromMinutes(30);
                if ( funComparar == null || (funComparar.Fecha.Date == funDTO.fecha.Date && horaReglamentaria >= horaDiferencia) )
                {
                    var funcion = await _funcionesService.CreateFuncion(funDTO);
                    var resultado = await _funcionMapper.createResponse(funcion, pelicula, sala, genero);
                    return new JsonResult(resultado) { StatusCode = 201 };
                }
                else
                {
                    var result = new
                    {
                        message = "El horario y sala seleccionada causan conflictos en el sistema."
                    };
                    return Conflict(result);
                }
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFuncion(int id)
        {
            var funcion = await _funcionesService.GetById(id);
            if (funcion != null)
            {
                var pelicula = await _peliculasService.GetById(funcion.PeliculaId);
                var sala = await _salasService.GetById(funcion.SalaId);
                var genero = await _generosService.GetById(pelicula.Genero);

                var result = await _funcionMapper.createResponse(funcion, pelicula, sala, genero);
                return Ok(result);
            }
            return NotFound("No se encontraron funciones el id especificado");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuncion(int id)
        {
            Funciones fun = await _funcionesService.GetById(id);
            if (fun == null)
            {
                var result = new
                {
                    message = "Funcion Ingresada no encontrada."
                };
                return NotFound(result);
            }
            var sala = await _salasService.GetById(fun.SalaId);
            if (await _ventaTicketService.TicketDisponibles(id) == sala.Capacidad)
            {
                var funcion = await _funcionesService.DeleteFuncion(id);
                var result = new
                {
                    funcionId = funcion.FuncionId,
                    fecha = funcion.Fecha,
                    horario = funcion.Horario
                };
                return Ok(result);
            }
            else
            {
                var result = new
                {
                    message = "No se puede eliminar Funciones con Tickets vendidos."
                };
                return BadRequest(result);
            }
        }
        [HttpGet("{id}/tickets")]
        public async Task<IActionResult>VerTickets(int id)
        {
            if (await _funcionesService.GetById(id) == null)
            {
                var mensaje = new
                {
                    message = "Funcion Ingresada no encontrada."
                };
                return NotFound(mensaje);
            }
            int ticketsDisponibles = await _ventaTicketService.TicketDisponibles(id);
            var result = new
            {
                cantidad = ticketsDisponibles
            };
            return Ok(result);
        }
        [HttpPost("{id}/tickets")]
        public async Task<IActionResult>VenderTickets(int id, TicketDTO ticket)
        {
            if ( await _funcionesService.GetById(id) == null)
            {
                var result = new
                {
                    message = "Funcion Ingresada no encontrada."
                };
                return NotFound(result);
            }
            else
            {
                Tickets tic = await _ventaTicketService.Vender(id, ticket);
                if (tic == null)
                {
                    var result = new
                    {
                        message = "La cantidad de Tickets solicitados no esta permitida"
                    };
                    return Conflict(result);
                }
                else
                {
                    Funciones funcion = await _funcionesService.GetById(id);
                    var pelicula = await _peliculasService.GetById(funcion.PeliculaId);
                    var sala = await _salasService.GetById(funcion.SalaId);
                    var genero = await _generosService.GetById(pelicula.Genero);
                    var result = await _ticketMapper.createResponse(tic, funcion, pelicula, sala, genero);
                    return Ok(result);
                }
            }
        }

    }
}
