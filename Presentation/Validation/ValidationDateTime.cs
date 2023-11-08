using Aplication.Interface_Validation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Validation
{
    public class ValidationDatetime : IValidationDatetime
    {
        public DateTime IngresarFecha(string dia)
        {
            if (dia != null)
            {
                DateTime fecha = DateTime.ParseExact(dia, "dd-MM", CultureInfo.InvariantCulture);
                return fecha;
            }
            else return DateTime.MinValue;
        }
    }
}
