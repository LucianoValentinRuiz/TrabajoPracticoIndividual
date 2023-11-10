using Aplication.Interface;
using Aplication.Interface_Service;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        public async Task<List<Funciones>> FuncionesFiltro(DateTime dia, string? titulo, Int32? genero)
        {
            if (titulo == null)
                titulo = "";
            if (genero == null)
                genero = 0;
            if (dia == null)
                dia = DateTime.MinValue;

                var pelis = await _query.GetPeliculas();
                List<int> ListaIdPeliculas = pelis
                             .Where(p => (titulo == "" || p.Titulo.ToLower().StartsWith(titulo.ToLower())))
                             .Where(p => (genero == 0 || p.Genero == genero))
                             .Select(p => p.PeliculaId)
                             .ToList();

            var fun = await _query.GetFunciones();
            List<Funciones> funciones = fun
                        .Where(f =>(ListaIdPeliculas.Count == 0 || ListaIdPeliculas.Contains(f.PeliculaId)) 
                        &&(dia == DateTime.MinValue || (f.Fecha.Year == dia.Year && f.Fecha.Month == dia.Month && f.Fecha.Day == dia.Day))).ToList();
            return funciones;
        }
        public async Task<Funciones> FuncionesFiltroUltimaSala(int idSala)
        {
            var fun = await _query.GetFunciones();
            Funciones funciones = fun
                        .Where(f => f.SalaId == idSala)
                        .OrderByDescending(f => f.FuncionId)
                        .FirstOrDefault();
            return funciones;
        }

    }
}
