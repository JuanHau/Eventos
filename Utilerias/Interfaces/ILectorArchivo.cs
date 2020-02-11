using System.Collections.Generic;

namespace Eventos.Utilerias.Interfaces
{
    public interface ILectorArchivo
    {
        List<string> LeerArchivo(string ruta);
    }
}
