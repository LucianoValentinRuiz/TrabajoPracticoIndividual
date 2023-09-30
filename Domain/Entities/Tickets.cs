using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Tickets
    {
        public  Guid TicketId { get; set; } 
        public int FuncionId { get; set; }
        public string Usuario { get; set; }
        public virtual Funciones Funciones { get; set; }
    }
}
