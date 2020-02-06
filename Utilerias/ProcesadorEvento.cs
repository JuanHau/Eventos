using Eventos.TipoEventos;
using Eventos.TipoEventos.Interfaces;
using Eventos.Utilerias.Interfaces;
using System.Collections.Generic;

namespace Eventos.Utilerias
{
    public class ProcesadorEvento : IProcesadorEvento
    {
        protected ILectorArchivo _lectorArchivo;

        public ProcesadorEvento(ILectorArchivo lectorArchivo)
        {
            _lectorArchivo = lectorArchivo;
        }

        public List<IEvento> ProcesarEvento()
        {
            List<Contenedor> resultado = _lectorArchivo.LeerArchivo();
            List<IEvento> eventos = new List<IEvento>();

            foreach (Contenedor contenedor in resultado)
            {
                IEvento evento = null;
                switch (contenedor.Tipo)
                {
                    case TipoEvento.Futuro:
                        evento = new EventoFuturo(contenedor.Nombre, contenedor.Duracion, contenedor.Escala);
                        break;
                    case TipoEvento.Pasado:
                        evento = new EventoPasado(contenedor.Nombre, contenedor.Duracion, contenedor.Escala);
                        break;
                }

                eventos.Add(evento);
            }

            return eventos;
        }
    }
}
