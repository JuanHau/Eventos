using Eventos.TipoEventos.Interfaces;
using Eventos.Utilerias;
using System;
using System.Collections.Generic;

namespace Eventos
{
    public class Program
    {
        static void Main(string[] args)
        {
            Fabrica.Fabrica fabrica = new Fabrica.Fabrica();
            fabrica.Iniciar();


            List<Contenedor> contenedors = fabrica.LeerArchivo.Leer();

            foreach(Contenedor contenedor in contenedors)
            {
                IEvent evento = fabrica.CrearInstancia(contenedor);
                Console.WriteLine(evento.ToString());
            }

            Console.ReadLine();
        }
    }
}
