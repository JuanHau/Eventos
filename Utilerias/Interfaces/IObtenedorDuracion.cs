using System;

namespace Eventos.Utilerias.Interfaces
{
    public interface IObtenedorDuracion
    {
        int ObtenerDuracion(DateTime actual, DateTime fecha, EscalaTiempo escala);
    }
}
