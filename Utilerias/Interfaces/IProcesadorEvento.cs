using Eventos.TipoEventos.Interfaces;
using System.Collections.Generic;

namespace Eventos.Utilerias.Interfaces
{
    public interface IProcesadorEvento
    {
        List<IEvento> ProcesarEvento(string ruta, char separador);
    }
}
