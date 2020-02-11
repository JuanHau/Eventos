using System.Collections.Generic;

namespace Eventos.Utilerias.Interfaces
{
    public interface IProcesadorString
    {
        List<Contenedor> ProcesarString(List<string> eventos, char separador);
    }
}
