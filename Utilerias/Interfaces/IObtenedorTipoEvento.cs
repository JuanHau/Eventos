using Eventos.TipoEventos;
using System;

namespace Eventos.Utilerias.Interfaces
{
    public interface IObtenedorTipoEvento
    {
        TipoEvento ObtenerTipoEvento(DateTime actual, DateTime fecha);
    }
}
