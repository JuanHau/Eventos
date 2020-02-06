using System;

namespace Eventos.Utilerias.Interfaces
{
    public interface IValidaFecha
    {
        DateTime ConvertirFecha(string fecha);
        Contenedor ValidarTipo(DateTime fecha);
    }
}
