using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Models
{
    public class CreateFuncionRequest 
    {
        public int funcionId { get; set; }
        public DateTime fecha { get; set; }
        public TimeSpan horario { get; set; }
    }
}
