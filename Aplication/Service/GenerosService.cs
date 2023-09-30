using Aplication.Interface;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Aplication.Service
{
    public class GenerosService
    {
        private readonly IGenerosCommand _command;
        private readonly IGenerosQuerys _query;

        public GenerosService(IGenerosCommand command, IGenerosQuerys query)
        {
            _command = command;
            _query = query;
        }

        public async Task<Generos> CreateGenero(Generos gen)
        {
            var genero = new Generos
            {
                Nombre = gen.Nombre,
            };
            await _command.InsertGeneros(genero);
            return genero;
        }
        public void DeleteGenero(int genId)
        {
            _command.RemoveGeneros(genId);
        }
        public List<Generos> GetAll()
        {
            var genero = _query.GetListGeneros();
            return genero;
        }
        public Generos GetById(int genId)
        {
            var genero = _query.GetGenerosById(genId);
            return genero;
        }

        public void ImprimirNombre(int id)
        {
            Console.WriteLine("Generos: {0}",(this.GetById(id)).Nombre );
        }
    }
}
