using Eventos.TipoEventos;
using Eventos.Utilerias.Interfaces;
using System;

namespace Eventos.Utilerias
{
    public class ValidadorFecha : IValidadorFecha
    {
        public Contenedor ValidarFecha(DateTime fecha)
        {
            Contenedor contenedor = new Contenedor();

            TimeSpan duracion = new DateTime(2020, 01, 01) - fecha;

            if(Math.Abs(duracion.Days / 30.436875) >= 1)
            {
                int _duracion = (int)(duracion.Days / 30.436875);

                contenedor.Escala = EscalaTiempo.Mes;
                contenedor.Tipo = _duracion >= 1 ? TipoEvento.Pasado : TipoEvento.Futuro; 
                contenedor.Duracion = _duracion >= 1 ? _duracion : _duracion * -1;

                return contenedor;
            }

            if (Math.Abs(duracion.Days) >= 1)
            {
                contenedor.Escala = EscalaTiempo.Dia;
                contenedor.Tipo = duracion.Days >= 1 ? TipoEvento.Pasado : TipoEvento.Futuro;
                contenedor.Duracion = duracion.Days >= 1 ? duracion.Days : duracion.Days * -1;

                return contenedor;
            }

            if (Math.Abs(duracion.Hours) >= 1)
            {
                contenedor.Escala = EscalaTiempo.Hora;
                contenedor.Tipo = duracion.Hours >= 1 ? TipoEvento.Pasado : TipoEvento.Futuro;
                contenedor.Duracion = duracion.Hours >= 1 ? duracion.Hours : duracion.Hours * -1;

                return contenedor;
            }

            if (Math.Abs(duracion.Minutes) >= 1)
            {
                contenedor.Escala = EscalaTiempo.Minuto;
                contenedor.Tipo = duracion.Minutes >= 1 ? TipoEvento.Pasado : TipoEvento.Futuro;
                contenedor.Duracion = duracion.Minutes >= 1 ? duracion.Minutes : duracion.Minutes * -1;

                return contenedor;
            }

            if (Math.Abs(duracion.Seconds) >= 1)
            {
                contenedor.Escala = EscalaTiempo.Segundo;
                contenedor.Tipo = duracion.Seconds >= 1 ? TipoEvento.Pasado : TipoEvento.Futuro;
                contenedor.Duracion = duracion.Seconds >= 1 ? duracion.Seconds : duracion.Seconds * -1;

                return contenedor;
            }

            return null;
        }
    }
}
