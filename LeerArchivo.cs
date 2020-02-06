using System;
using System.IO;

namespace Eventos
{
    public class LeerArchivo
    {
        protected readonly string _direccion = "C:\\BLUE OCEAN\\CAPACITACIÓN\\Eventos\\eventos.txt";

        protected ValidarEvento _validarEvento = new ValidarEvento();

        public void Leer()
        {
            //Referencia 01 de enero de 2020 00:00:00
            try
            {
                if (!File.Exists(_direccion))
                {
                    throw new ArgumentException("El archivo no existe");
                }

                using (StreamReader stream = new StreamReader(_direccion))
                {
                    while (stream.Peek() > -1)
                    {
                        string evento = stream.ReadLine();

                        Console.WriteLine(_validarEvento.FormatoMensaje(evento));

                    }
                }

                Console.ReadLine();
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Ocurrió el siguiente error al leer el archivo: " + Ex.Message);
            }
        }
    }
}
