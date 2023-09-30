using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Generos
    {
        public int GeneroId { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Peliculas> Peliculas { get; set; }
    }
}
