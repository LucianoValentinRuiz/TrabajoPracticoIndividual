using Aplication.DTO;
using Aplication.Interface_Mappers;
using Aplication.Interface_Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
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
            if (id < 0)
            {
                return BadRequest("ID de película no válido");
            }

            var pel = await _peliculasService.GetById(id);
            if (pel != null)
            {
                var gen = await _generosService.GetById(pel.Genero);
                var result = _peliculaMapper.createResponse(pel, gen,_filtrosService);
                return new JsonResult(result);
            }
            else
            {
                return NotFound("No se encontro ninguna pelicula con la ID ingresada");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePelicula(int id, PeliculaDTO peliDTO)
        {
            var Pelicula_edit = new PeliculaDTO
            {
                Titulo = peliDTO.Titulo,
                Poster = peliDTO.Poster,
                Trailer = peliDTO.Trailer,
                Sinopsis = peliDTO.Sinopsis,
                Genero = peliDTO.Genero
            };
            if (id < 0 || id.GetType() != typeof(int))
            {
                return BadRequest("ID de película no válido");
            }
            var pel = await _peliculasService.ModificarPelicula(id, peliDTO);
            var gen = await _generosService.GetById(pel.Genero);
            if (pel != null)
            {
                var result = _peliculaMapper.createResponse(pel, gen,_filtrosService);
                return new JsonResult(result);
            }
            else
            {
                return NotFound("No se encontro ninguna pelicula con la ID ingresada");
            }
        }
    }
}
