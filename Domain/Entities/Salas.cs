using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Salas
    {
        public int SalaId { get; set; }
        public string Nombre { get; set; }
        public int Capacidad { get; set; }
        public virtual ICollection<Funciones> Funciones { get; set; }
    }
}
