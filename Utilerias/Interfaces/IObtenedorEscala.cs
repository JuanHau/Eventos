using System;

namespace Eventos.Utilerias.Interfaces
{
    public interface IObtenedorEscala
    {
        EscalaTiempo ObtenerEscalaTiempo(DateTime actual, DateTime fecha);
    }
}
