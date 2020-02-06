using Eventos.Utilerias;
using System;

namespace Eventos.TipoEventos.Interfaces
{
    public interface IEvent
    {
        string Nombre { get; set; }
        int Duracion { get; set; }
        Escala Escala { get; set; }
    }
}
