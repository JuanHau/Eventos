using Eventos.TipoEventos;
using Eventos.Utilerias.Interfaces;
using System;
using System.Collections.Generic;

namespace Eventos.Utilerias
{
    public class ProcesadorString : IProcesadorString
    {
        protected IObtenedorEscala _obtenedorEscala;
        protected IObtenedorTipoEvento _obtenedorTipoEvento;
        protected IObtenedorDuracion _obtenedorDuracion;
        protected IConvertidorFecha _convertidorFecha;

        public ProcesadorString(
            IObtenedorEscala obtenedorEscala,
            IObtenedorTipoEvento obtenedorTipoEvento,
            IObtenedorDuracion obtenedorDuracion,
            IConvertidorFecha convertidorFecha)
        {
            _obtenedorEscala = obtenedorEscala;
            _obtenedorTipoEvento = obtenedorTipoEvento;
            _obtenedorDuracion = obtenedorDuracion;
            _convertidorFecha = convertidorFecha;
        }

        public List<Contenedor> ProcesarString(List<string> eventos, char separador)
        {
            List<Contenedor> contenedores = new List<Contenedor>();

            foreach(string evento in eventos)
            {
                string[] contenido = evento.Split(separador);

                if (contenido.Length == 2)
                {
                    DateTime fechaActual = new DateTime(2020,01,01); //DateTime.Now
                    DateTime fechaEvento = _convertidorFecha.ConvertirFecha(contenido[1]);

                    TipoEvento tipo = _obtenedorTipoEvento.ObtenerTipoEvento(fechaActual, fechaEvento);
                    EscalaTiempo escala = _obtenedorEscala.ObtenerEscalaTiempo(fechaActual, fechaEvento);
                    int duracionEvento = _obtenedorDuracion.ObtenerDuracion(fechaActual, fechaEvento, escala);

                    Contenedor contenedor = new Contenedor()
                    {
                        Tipo = tipo,
                        Escala = escala,
                        Duracion = duracionEvento,
                        Nombre = contenido[0]
                    };

                    contenedores.Add(contenedor);
                }
            }

            return contenedores;
        }
    }
}
