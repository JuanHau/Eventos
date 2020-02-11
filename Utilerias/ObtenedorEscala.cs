using Eventos.Utilerias.Interfaces;
using System;

namespace Eventos.Utilerias
{
    public class ObtenedorEscala : IObtenedorEscala
    {
        public EscalaTiempo ObtenerEscalaTiempo(DateTime actual, DateTime fecha)
        {
            TimeSpan duracion = actual - fecha;
            EscalaTiempo escala = EscalaTiempo.NoEscala;

            if (Math.Abs(duracion.TotalDays / 30.436875) >= 1)
            {
                return EscalaTiempo.Mes;
            }

            if (Math.Abs(duracion.TotalDays) >= 1)
            {
                return EscalaTiempo.Dia;
            }

            if (Math.Abs(duracion.TotalHours) >= 1)
            {
                return EscalaTiempo.Hora;
            }

            if (Math.Abs(duracion.TotalMinutes) >= 1)
            {
                return EscalaTiempo.Minuto;
            }

            return escala;
        }
    }
}
