using Eventos.Utilerias.Interfaces;
using System;

namespace Eventos.Utilerias
{
    public class ConvertidorFecha : IConvertidorFecha
    {
        public DateTime ConvertirFecha(string fecha)
        {
            DateTime.TryParse(fecha, out DateTime fechaEvento);

            if (fechaEvento == DateTime.MinValue)
            {
                throw new ArgumentException("Formato de fecha incorrecto");
            }

            return fechaEvento;
        }
    }
}
