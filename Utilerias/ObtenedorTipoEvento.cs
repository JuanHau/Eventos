using Eventos.TipoEventos;
using Eventos.Utilerias.Interfaces;
using System;

namespace Eventos.Utilerias
{
    public class ObtenedorTipoEvento : IObtenedorTipoEvento
    {
        public TipoEvento ObtenerTipoEvento(DateTime actual, DateTime fecha)
        {
            if(actual > fecha)
            {
                return TipoEvento.Pasado;
            }
            else
            {
                return TipoEvento.Futuro;

            }
        }
    }
}
