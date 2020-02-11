using Eventos.TipoEventos;
using Eventos.TipoEventos.Interfaces;
using Eventos.Utilerias.Interfaces;
using System.Collections.Generic;

namespace Eventos.Utilerias
{
    public class ProcesadorEvento : IProcesadorEvento
    {
        protected ILectorArchivo _lectorArchivo;
        protected IProcesadorString _procesadorString;

        public ProcesadorEvento(ILectorArchivo lectorArchivo, IProcesadorString procesadorString)
        {
            _lectorArchivo = lectorArchivo;
            _procesadorString = procesadorString;
        }

        public List<IEvento> ProcesarEvento(string ruta, char separador)
        {
            List<IEvento> eventos = new List<IEvento>();

            List<string> contenido = _lectorArchivo.LeerArchivo(ruta);
            List<Contenedor> contenedores = _procesadorString.ProcesarString(contenido, separador);

            foreach (Contenedor contenedor in contenedores)
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
