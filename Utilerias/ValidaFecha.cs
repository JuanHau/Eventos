using Eventos.TipoEventos;
using Eventos.Utilerias.Interfaces;
using System;

namespace Eventos.Utilerias
{
    public class ValidaFecha : IValidaFecha
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

        public Contenedor ValidarTipo(DateTime fecha)
        {
            Contenedor contenedor = new Contenedor();

            TimeSpan duracion = new DateTime(2020, 01, 01) - fecha;

            if(Math.Abs(duracion.Days / 30.436875) >= 1)
            {
                int _duracion = (int)(duracion.Days / 30.436875);

                contenedor.Escala = Escala.Mes;
                contenedor.Tipo = _duracion >= 1 ? Tipo.Pasado : Tipo.Futuro; 
                contenedor.Duracion = _duracion >= 1 ? _duracion : _duracion * -1;

                return contenedor;
            }

            if (Math.Abs(duracion.Days) >= 1)
            {
                contenedor.Escala = Escala.Dia;
                contenedor.Tipo = duracion.Days >= 1 ? Tipo.Pasado : Tipo.Futuro;
                contenedor.Duracion = duracion.Days >= 1 ? duracion.Days : duracion.Days * -1;

                return contenedor;
            }

            if (Math.Abs(duracion.Hours) >= 1)
            {
                contenedor.Escala = Escala.Hora;
                contenedor.Tipo = duracion.Hours >= 1 ? Tipo.Pasado : Tipo.Futuro;
                contenedor.Duracion = duracion.Hours >= 1 ? duracion.Hours : duracion.Hours * -1;

                return contenedor;
            }

            if (Math.Abs(duracion.Minutes) >= 1)
            {
                contenedor.Escala = Escala.Minuto;
                contenedor.Tipo = duracion.Minutes >= 1 ? Tipo.Pasado : Tipo.Futuro;
                contenedor.Duracion = duracion.Minutes >= 1 ? duracion.Minutes : duracion.Minutes * -1;

                return contenedor;
            }

            if (Math.Abs(duracion.Seconds) >= 1)
            {
                contenedor.Escala = Escala.Segundo;
                contenedor.Tipo = duracion.Seconds >= 1 ? Tipo.Pasado : Tipo.Futuro;
                contenedor.Duracion = duracion.Seconds >= 1 ? duracion.Seconds : duracion.Seconds * -1;

                return contenedor;
            }

            return null;
        }
    }
}
