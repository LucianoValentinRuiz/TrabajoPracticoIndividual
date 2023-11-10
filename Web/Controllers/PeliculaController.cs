using Aplication.DTO;
using Aplication.Interface_Mappers;
using Aplication.Interface_Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PeliculaController : ControllerBase
    {
        private readonly IPeliculasService _peliculasService;
        private readonly IGenerosService _generosService;
        private readonly IFIltrosService _filtrosService;
        private readonly IPeliculaMapper _peliculaMapper;

        public PeliculaController(IPeliculasService peliculasService, IGenerosService generosService, IFIltrosService filtrosService ,IPeliculaMapper peliculaMapper)
        {
            _peliculasService = peliculasService;
            _generosService = generosService;
            _filtrosService = filtrosService;
            _peliculaMapper = peliculaMapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPeliculaById(int id)
        {

            var pel = await _peliculasService.GetById(id);
            if (pel != null)
            {
                var gen = await _generosService.GetById(pel.Genero);
                var objeto = await _peliculaMapper.createResponse(pel, gen,_filtrosService);
                return Ok (objeto);
            }
            else
            {
                var result = new
                {
                    message = "La pelicula seleccionada no se encontro."
                };
                return NotFound(result);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePelicula(int id, PeliculaDTO peliDTO)
        {
            if (await _peliculasService.GetById(id) != null)
            {
                var pel = await _peliculasService.ModificarPelicula(id, peliDTO, _generosService);
                if (pel != null)
                {
                    var gen = await _generosService.GetById(pel.Genero);
                    var result = await _peliculaMapper.createResponse(pel, gen, _filtrosService);
                    return Ok(result);
                }
                else
                {
                    var result = new
                    {
                        message = "Los datos ingresados no son validos."
                    };
                    return BadRequest(result);
                }
            }
            else
            {
                var result = new
                {
                    message = "La pelicula seleccionada no se encontro."
                };
                return NotFound(result); 
            }
        }
    }
}
