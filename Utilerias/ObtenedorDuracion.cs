using Eventos.Utilerias.Interfaces;
using System;

namespace Eventos.Utilerias
{
    public class ObtenedorDuracion : IObtenedorDuracion
    {
        public int ObtenerDuracion(DateTime actual, DateTime fecha, EscalaTiempo escala)
        {
            int duracionEscala = 0;
            TimeSpan duracion = actual - fecha;

            switch (escala)
            {
                case EscalaTiempo.Mes:
                    duracionEscala = (int)Math.Abs(duracion.TotalDays / 30.436875);
                    break;
                case EscalaTiempo.Dia:
                    duracionEscala = (int)Math.Abs(duracion.TotalDays);
                    break;
                case EscalaTiempo.Hora:
                    duracionEscala = (int)Math.Abs(duracion.TotalHours);
                    break;
                case EscalaTiempo.Minuto:
                    duracionEscala = (int)Math.Abs(duracion.TotalMinutes);
                    break;
            }

            return duracionEscala;
        }
    }
}
