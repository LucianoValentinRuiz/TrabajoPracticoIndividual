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

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionController : ControllerBase
    {
        private readonly IPeliculasService _peliculasService;
        private readonly ISalasService _salasService;
        private readonly IGenerosService _generosService;
        private readonly IFuncionesService _funcionesService;
        private readonly IValidationDatetime _validation;
        private readonly IFIltrosService _filtrosService;
        private readonly IFuncionMapper _funcionMapper;
        private readonly ITicketMapper _ticketMapper;

        public FuncionController(IPeliculasService peliculasService, ISalasService salasService, IGenerosService generosService, IFuncionesService funcionesService, IValidationDatetime validation,IFIltrosService fIltrosService,IFuncionMapper funcionMapper, ITicketMapper ticketMapper)
        {
            _peliculasService = peliculasService;
            _salasService = salasService;
            _generosService = generosService;
            _funcionesService = funcionesService;
            _validation = validation;
            _filtrosService = fIltrosService;
            _funcionMapper = funcionMapper;
            _ticketMapper = ticketMapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string? dia, string? titulo, int? genero)
        {
            try
            {
                List<Funciones> funciones = new List<Funciones>();
                funciones = await _filtrosService.FuncionesFiltro(_validation.IngresarFecha(dia), titulo, genero);
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
                    return new JsonResult(resultados);
                }
                else
                    return NotFound();
            }
            catch { return BadRequest(); }
        }

        [HttpPost]
        public async Task<IActionResult> CreateFuncion(FuncionDTO funDTO)
        {
            var pelicula = await _peliculasService.GetById(funDTO.PeliculaId);
            var sala = await _salasService.GetById(funDTO.SalaId);
            var genero = await _generosService.GetById(pelicula.Genero);
            if(pelicula == null && sala == null && genero == null)
                return NotFound();
            else 
            {
                if(false)
                    return BadRequest();
                else
                {
                    var funcion = await _funcionesService.CreateFuncion(funDTO);
                    var resultado = await _funcionMapper.createResponse(funcion, pelicula, sala, genero);
                    return new JsonResult(resultado);
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
                return new JsonResult(result);
            }
            return NotFound("No se encontraron funciones con los filtros especificados");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuncion(int id)
        {
            if (_funcionesService.GetById(id) == null)
                return NotFound();
            else
            {
                var funcion = await _funcionesService.DeleteFuncion(id);
                var result = new
                {
                    funcionId = funcion.FuncionId,
                    fecha = funcion.Fecha,
                    horario = funcion.Horario
                };
                return new JsonResult(result);
            }
        }

    }
}
