using Aplication.Interface;
using Aplication.Interface_Service;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Service
{
    public class FiltrosService : IFIltrosService
    {
        private readonly IFiltrosQuerys _query;

        public FiltrosService(IFiltrosQuerys query)
        {
            _query = query;
        }

        public async Task<List<Funciones>> ListaFunciones(string? dia, string? titulo)
        {
            int IdPelicula = -1;
            List<Funciones> funciones = null;

            if (titulo != null) 
            {
                var pelis = await _query.GetPeliculas();
                IdPelicula = pelis
                             .Where(p => p.Titulo.ToLower() == titulo.ToLower())
                             .Select(p => p.PeliculaId)
                             .FirstOrDefault();
                //IdPeliculas = idsDePeliculas;
            }
            var fun = await _query.GetFunciones();
            funciones =  fun
                        .Where(p =>(IdPelicula != -1 && p.PeliculaId == IdPelicula))
                        .Where(p => (dia != null && p.Horario.ToString("MM-dd") == dia))
                        .ToList();
            //funciones = ListaFunciones;
            return funciones;
        }
    }
}
