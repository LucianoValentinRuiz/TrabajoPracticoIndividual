
using Domain.Entities;
using Aplication.Interface;
using Aplication.DTO;
using Aplication.Interface_Service;

namespace Aplication.Service
{
    public class FuncionesService : IFuncionesService
    {
        private readonly IFuncionesCommand _command;
        private readonly IFuncionesQuerys _query;

        public FuncionesService(IFuncionesCommand command, IFuncionesQuerys query)
        {
            _command = command;
            _query = query;
        }

        public async Task CreateFuncion(FuncionDTO fun_request) {
            Funciones funciones = new Funciones
            {
                PeliculaId = fun_request.PeliculaId,
                SalaId = fun_request.SalaId,
                Fecha = fun_request.Fecha,
                Horario = fun_request.Horario,
            };
            Console.WriteLine("- - - - - - - - - - - - - - - - - ");
            if (funciones.PeliculaId == 0 || funciones.SalaId == 0 || funciones.Fecha == DateTime.MinValue || funciones.Horario == TimeSpan.Zero)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("*No se logro registrar la nueva Funcion*");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("*Funcion registrada exitosamente*");
                Console.ResetColor();
                _command.InsertFuncion(funciones);
            }
        }
        public void DeleteFuncion(int funId) {
            _command.RemoveFuncion(funId);
        }
        public List<Funciones> GetAll() {
            var funcion = _query.GetListFunciones();
            return funcion;       
         }
        public async Task <Funciones> GetById (int funId) {
            var funcion =  _query.GetFuncionById(funId);
            return funcion;
        }

        public void ImprimirFunciones_Peliculas(string titulo)
        {
            //PeliculasService peliserv = new PeliculasService();
            //List<Funciones> lista = new List<Funciones>();
            //foreach (Funciones fun in this.GetAll())
            //{
            //    if (peliserv.PeliculaExiste(fun.PeliculaId, titulo))
            //    {
            //        lista.Add(fun);
            //    }
            //}
            //if (lista.Count != 0)
            //{
            //    Console.ForegroundColor = ConsoleColor.Green;
            //    Console.WriteLine("Las funciones para la pelicula ´´{0}´´ son:", titulo.ToUpper());
            //    Console.ResetColor();
            //    foreach (Funciones fun in lista)
            //        this.ImprimirFuncion(fun);
            //}
            //else 
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine("No se encontraron Funciones.");
            //    Console.ResetColor();
            //}
        }

        public void ImprimirFunciones_Horarios(DateTime dia)
        {
            //List<Funciones> lista = new List<Funciones>();
            //foreach (Funciones fun in this.GetAll())
            //{
            //    if (fun.Fecha == dia)
            //    {
            //        lista.Add(fun);
            //    }
            //}
            //if (lista.Count != 0)
            //{
            //    Console.ForegroundColor = ConsoleColor.Green;
            //    Console.WriteLine("Las funciones para el dia ´´{0}´´ son:", dia.ToString("ddd,dd,MM"));
            //    Console.ResetColor();
            //    foreach (Funciones fun in lista)
            //        this.ImprimirFuncion(fun);
            //}
            //else
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine("No se encontraron Funciones.");
            //    Console.ResetColor();
            //}
        }
    }
}