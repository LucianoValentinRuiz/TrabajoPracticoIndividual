using Aplication.Interface_Validation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Validation
{
    public class ValidationDateTime : IValidationDatetime
    {
        public DateTime IngresarFecha(string dia)
        {
            DateTime date;

            if (DateTime.TryParseExact(dia, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                return date;
            }
            else
            {
                return DateTime.MinValue;
            }

        }
    }
}
