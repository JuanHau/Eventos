using Eventos.Utilerias;
using System;

namespace Eventos.TipoEventos.Interfaces
{
    public interface IEvento
    {
        string Nombre { get; set; }
        int Duracion { get; set; }
        EscalaTiempo Escala { get; set; }
    }
}
