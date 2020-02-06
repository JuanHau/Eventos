using Eventos.TipoEventos.Interfaces;
using Eventos.Utilerias;
using Eventos.Utilerias.Interfaces;
using System;

namespace Eventos
{
    public class Program
    {
        static void Main(string[] args)
        {
            IValidadorFecha validadorFecha = new ValidadorFecha();
            IConvertidorFecha convertidorFecha = new ConvertidorFecha();
            ILectorArchivo lectorArchivo = new LectorArchivo(validadorFecha, convertidorFecha);

            IProcesadorEvento procesadorEvento = new ProcesadorEvento(lectorArchivo);

            foreach (IEvento evento in procesadorEvento.ProcesarEvento())
            {
                Console.WriteLine(evento.ToString());
            }

            Console.ReadLine();
        }
    }
}
