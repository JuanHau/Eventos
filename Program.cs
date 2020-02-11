using Eventos.Configuracion;
using Eventos.TipoEventos.Interfaces;
using Eventos.Utilerias;
using Eventos.Utilerias.Interfaces;
using System;

namespace Eventos
{
    public static class Program
    {
        static void Main(string[] args)
        {
            IObtenedorEscala obtenedorEscala = new ObtenedorEscala();
            IObtenedorTipoEvento obtenedorTipoEvento = new ObtenedorTipoEvento();
            IObtenedorDuracion obtenedorDuracion = new ObtenedorDuracion();
            IConvertidorFecha convertidorFecha = new ConvertidorFecha();

            IProcesadorString procesadorString = new ProcesadorString(
                obtenedorEscala,
                obtenedorTipoEvento,
                obtenedorDuracion,
                convertidorFecha);

            ILectorArchivo lectorArchivo = new LectorArchivo();

            IProcesadorEvento procesadorEvento = new ProcesadorEvento(lectorArchivo, procesadorString);

            foreach (IEvento evento in procesadorEvento.ProcesarEvento(ConfiguracionGeneral.RutaArchivo, ConfiguracionGeneral.CaracterSeparacion))
            {
                Console.WriteLine(evento.ToString());
            }

            Console.ReadLine();
        }
    }
}
